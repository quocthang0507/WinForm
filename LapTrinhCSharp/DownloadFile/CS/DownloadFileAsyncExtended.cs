using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;


using System.IO;
using System.Net;
using System.Threading;
using SampleProject;

namespace SampleProject
{
	
	//// This is the main download class.
	public class DownloadFileAsyncExtended
	{
		
#region Methods
		
		private string _URL = string.Empty;
		private string _LocalFilePath = string.Empty;
		private object _userToken = null;
		private long _ContentLenght = 0;
		private int _TotalBytesReceived = 0;
		
		//// Start the asynchronous download.
		public void DowloadFileAsync(string URL, string LocalFilePath, object userToken)
		{
			HttpWebRequest Request = default(HttpWebRequest);
			Uri fileURI = new Uri(URL); //// Will throw exception if empty or random string.
			
			//// Make sure it's a valid http:// or https:// url.
			if (fileURI.Scheme != Uri.UriSchemeHttp && fileURI.Scheme != Uri.UriSchemeHttps)
			{
				throw (new Exception("Invalid URL. Must be http:// or https://"));
			}

           

            //// Save this to private variables in case we need to resume.
            _URL = URL;
			_LocalFilePath = LocalFilePath;
			_userToken = userToken;
			
			//// Create the request.
			Request = (HttpWebRequest) (HttpWebRequest.Create(new Uri(URL)));
			Request.Credentials = Credentials;
			Request.AllowAutoRedirect = true;
			Request.ReadWriteTimeout = 30000;
			Request.Proxy = Proxy;
			Request.KeepAlive = false;
			Request.Headers = Headers; //// NOTE: Will throw exception if wrong headers supplied.
			
			//// If we're resuming, then add the AddRange header.
			if (_ResumeAsync)
			{
				FileInfo FileInfo = new FileInfo(LocalFilePath);
				if (FileInfo.Exists)
				{
					Request.AddRange(Convert.ToInt32(FileInfo.Length));
				}
			}
			
			//// Signal we're busy downloading
			_isbusy = true;
			
			//// Make sure this is set to False or the download will stop immediately.
			_CancelAsync = false;
			
			//// This is the data we're sending to the GetResponse Callback.
			HttpWebRequestState State = new HttpWebRequestState(LocalFilePath, Request, _ResumeAsync, userToken);
			
			//// Begin to get a response from the server.
			IAsyncResult result = Request.BeginGetResponse(GetResponse_Callback, State);
			
			//// Add custom 30 second timeout for connecting.
			//// The Timeout property is ignored when using the asynchronous BeginGetResponse.
			ThreadPool.RegisterWaitForSingleObject(result.AsyncWaitHandle, new WaitOrTimerCallback(TimeoutCallback), State, 30000, true);
		}
		
		//// Here we receive the response from the server. We do not check for the "Accept-Ranges"
		//// response header, in order to find out if the server supports resuming, because it MAY
		//// send the "Accept-Ranges" response header, but is not required to do so. This is
		//// unreliable, so we'll just continue and catch the exception that will occur if not
		//// supported and send it the DownloadCompleted event. We also don't check if the
		//// Content-Length is '-1', because some servers return '-1', eventhough the file/webpage
		//// you're trying to download is valid. e.ProgressPercentage returns '-1' in that case.
		private void GetResponse_Callback(IAsyncResult result)
		{
			HttpWebRequestState State = (HttpWebRequestState) result.AsyncState;
			FileStream DestinationStream = null;
			HttpWebResponse Response = null;
			Stopwatch Duration = new Stopwatch();
			byte[] Buffer = new byte[8192];
			int BytesRead = 0;
			int ElapsedSeconds = 0;
			int DownloadSpeed = 0;
			int DownloadProgress = 0;
			int BytesReceivedThisSession = 0;
			
			try
			{
				//'// Get response
				Response = (HttpWebResponse) (State.Request.EndGetResponse(result));
				
				//// Asign Response headers to ReadOnly ResponseHeaders property.
				_ResponseHeaders = Response.Headers;
				
				//// If the server does not reply with an 'OK (200)' message when starting
				//// the download or a 'PartialContent (206)' message when resuming.
				if ((int) Response.StatusCode != System.Convert.ToInt32(HttpStatusCode.OK)& (int) Response.StatusCode != System.Convert.ToInt32(HttpStatusCode.PartialContent))
				{
					//// Send error message to anyone who is listening.
					OnDownloadCompleted(new FileDownloadCompletedEventArgs(new Exception(Response.StatusCode.ToString()), false, State.userToken));
					return ;
				}
				
				//// Create/open the file to write to.
				if (State.ResumeDownload)
				{
					//// If resumed, then create or open the file.
					DestinationStream = new FileStream(State.LocalFilePath, FileMode.OpenOrCreate, FileAccess.Write);
				}
				else
				{
					//// If not resumed, then create the file, which will delete the existing file if it already exists.
					DestinationStream = new FileStream(State.LocalFilePath, FileMode.Create, FileAccess.Write);
					//// Get the ContentLength only when we're starting the download. Not when resuming.
					_ContentLenght = Response.ContentLength;
				}
				
				//// Moves stream position to beginning of the file when starting the download.
				//// Moves stream position to end of the file when resuming the download.
				DestinationStream.Seek(0, SeekOrigin.End);
				
				//// Start timer to get download duration / download speed, etc.
				Duration.Start();
				
				//// Get the Response Stream.
				using (Stream responseStream = Response.GetResponseStream())
				{
					do
					{
						//// Read some bytes.
						BytesRead = responseStream.Read(Buffer, 0, Buffer.Length);
						if (BytesRead > 0)
						{
							//// Write incoming data to the file.
							DestinationStream.Write(Buffer, 0, BytesRead);
							//// Count the total number of bytes downloaded.
							_TotalBytesReceived += BytesRead;
							//// Count the number of bytes downloaded this session (Resume).
							BytesReceivedThisSession += BytesRead;
							//// Get number of elapsed seconds (need round number to prevent 'division by zero' error).
							ElapsedSeconds = System.Convert.ToInt32(Duration.Elapsed.TotalSeconds);
							
							//// Update frequency: No Delay, every Half a Second or every Second.
							if (ProgressUpdateFrequency == UpdateFrequency.NoDelay)
							{
								//// Calculate download speed in bytes per second.
								if (ElapsedSeconds > 0)
								{
									DownloadSpeed = BytesReceivedThisSession / ElapsedSeconds;
								}
								//// Send download progress to anyone who is listening.
								OnDownloadProgressChanged(new FileDownloadProgressChangedEventArgs(_TotalBytesReceived, (int) _ContentLenght, ElapsedSeconds, DownloadSpeed, State.userToken));
							}
							else if (ProgressUpdateFrequency == UpdateFrequency.HalfSecond)
							{
								if (System.Convert.ToInt32(Duration.ElapsedMilliseconds - DownloadProgress) >= 500)
								{
									DownloadProgress = (int) Duration.ElapsedMilliseconds;
									//// Calculate download speed in bytes per second.
									if (ElapsedSeconds > 0)
									{
										DownloadSpeed = BytesReceivedThisSession / ElapsedSeconds;
									}
									//// Send download progress to anyone who is listening.
									OnDownloadProgressChanged(new FileDownloadProgressChangedEventArgs(_TotalBytesReceived, (int) _ContentLenght, ElapsedSeconds, DownloadSpeed, State.userToken));
								}
							}
							else if (ProgressUpdateFrequency == UpdateFrequency.Second)
							{
								if (System.Convert.ToInt32(Duration.ElapsedMilliseconds - DownloadProgress) >= 1000)
								{
									DownloadProgress = (int) Duration.ElapsedMilliseconds;
									//// Calculate download speed in bytes per second.
									if (ElapsedSeconds > 0)
									{
										DownloadSpeed = BytesReceivedThisSession / ElapsedSeconds;
									}
									//// Send download progress to anyone who is listening.
									OnDownloadProgressChanged(new FileDownloadProgressChangedEventArgs(_TotalBytesReceived, (int) _ContentLenght, ElapsedSeconds, DownloadSpeed, State.userToken));
								}
							}
							
							//// Exit loop when paused.
							if (_CancelAsync)
							{
								break;
							}
							
						}
					} while (!(BytesRead == 0));
				}
				
				
				//// Send download progress once more. If the UpdateFrequency has been set to
				//// HalfSecond or Second, then the last percentage returned might be 98% or 99%.
				//// This makes sure it's 100%.
				OnDownloadProgressChanged(new FileDownloadProgressChangedEventArgs(_TotalBytesReceived, (int) _ContentLenght, System.Convert.ToInt32(Duration.Elapsed.TotalSeconds), DownloadSpeed, State.userToken));
				
				if (_CancelAsync)
				{
					//// Send completed message (Paused) to anyone who is listening.
					OnDownloadCompleted(new FileDownloadCompletedEventArgs(null, true, State.userToken));
				}
				else
				{
					//// Send completed message (Finished) to anyone who is listening.
					OnDownloadCompleted(new FileDownloadCompletedEventArgs(null, false, State.userToken));
				}
			}
			catch (Exception ex)
			{
				//// Send completed message (Error) to anyone who is listening.
				OnDownloadCompleted(new FileDownloadCompletedEventArgs(ex, false, State.userToken));
			}
			finally
			{
				//// Close the file.
				if (DestinationStream != null)
				{
					DestinationStream.Flush();
					DestinationStream.Close();
					DestinationStream = null;
				}
				//// Stop and reset the duration timer.
				Duration.Reset();
				Duration = null;
				//// Signal we're not downloading anymore.
				_isbusy = false;
			}
		}
		
		//// Here we will abort the download if it takes more than 30 seconds to connect, because
		//// the Timeout property is ignored when using the asynchronous BeginGetResponse.
		private void TimeoutCallback(object State, bool TimedOut)
		{
			if (TimedOut)
			{
				HttpWebRequestState RequestState = (HttpWebRequestState) State;
				if (RequestState != null)
				{
					RequestState.Request.Abort();
				}
			}
		}
		
		//// Cancel the asynchronous download.
		private bool _CancelAsync = false;
		public void CancelAsync()
		{
			_CancelAsync = true;
		}
		
		//// Resume the asynchronous download.
		private bool _ResumeAsync = false;
		public void ResumeAsync()
		{
			//// Throw exception if download is already in progress.
			if (_isbusy)
			{
				throw (new Exception("Download is still busy. Use IsBusy property to check if download is already busy."));
			}
			
			//// Throw exception if URL or LocalFilePath is empty, which means
			//// the download wasn't even started yet with DowloadFileAsync.
			if (string.IsNullOrEmpty(_URL) && string.IsNullOrEmpty(_LocalFilePath))
			{
				throw (new Exception("Cannot resume a download which hasn't been started yet. Call DowloadFileAsync first."));
			}
			else
			{
				//// Set _ResumeDownload to True, so we know we need to add
				//// the Range header in order to resume the download.
				_ResumeAsync = true;
				//// Restart (Resume) the download.
				DowloadFileAsync(_URL, _LocalFilePath, _userToken);
			}
		}
		
#endregion
		
#region Properties
		
		public enum UpdateFrequency
		{
			NoDelay = 0,
			HalfSecond = 1,
			Second = 2
		}
		
		//// Progress Update Frequency.
		public UpdateFrequency ProgressUpdateFrequency {get; set;}
		
		//// Proxy.
		public IWebProxy Proxy {get; set;}
		
		//// Credentials.
		public ICredentials Credentials {get; set;}

        //// Headers.
        public WebHeaderCollection Headers { get { return new WebHeaderCollection(); }}

        //// Is download busy.
        private bool _isbusy = false;
		public bool IsBusy
		{
			get
			{
				return _isbusy;
			}
		}
		
		//// ResponseHeaders.
		private WebHeaderCollection _ResponseHeaders = null;
		public WebHeaderCollection ResponseHeaders
		{
			get
			{
				return _ResponseHeaders;
			}
		}
		
		//// SynchronizingObject property to marshal events back to the UI thread.
		private System.ComponentModel.ISynchronizeInvoke _synchronizingObject;
		public System.ComponentModel.ISynchronizeInvoke SynchronizingObject
		{
			get
			{
				return this._synchronizingObject;
			}
			set
			{
				this._synchronizingObject = value;
			}
		}

        #endregion

        #region Events
        public event EventHandler<FileDownloadProgressChangedEventArgs> DownloadProgressChanged;
  //      public EventHandler<FileDownloadProgressChangedEventArgs> DownloadProgressChangedEvent;
		//public event EventHandler<FileDownloadProgressChangedEventArgs> DownloadProgressChanged;
		private delegate void DownloadProgressChangedEventInvoker(FileDownloadProgressChangedEventArgs e);
		protected virtual void OnDownloadProgressChanged(FileDownloadProgressChangedEventArgs e)
		{
            if (this.SynchronizingObject != null && this.SynchronizingObject.InvokeRequired)
            {
                //Marshal the call to the thread that owns the synchronizing object.
                this.SynchronizingObject.Invoke(new DownloadProgressChangedEventInvoker(OnDownloadProgressChanged), new object[] { e });
            }
            else
            {
                DownloadProgressChanged(this, e);
                //RaiseEvent DownloadProgressChanged(Me, e);
                //if (DownloadProgressChangedEvent != null)
                //    DownloadProgressChangedEvent(this, e);
            }
        }

        public event EventHandler<FileDownloadCompletedEventArgs> DownloadCompleted;
  //      public EventHandler<FileDownloadCompletedEventArgs> DownloadCompletedEvent;
		//public event EventHandler<FileDownloadCompletedEventArgs> DownloadCompleted;
		private delegate void DownloadCompletedEventInvoker(FileDownloadCompletedEventArgs e);
		protected virtual void OnDownloadCompleted(FileDownloadCompletedEventArgs e)
		{
			if (this.SynchronizingObject != null && this.SynchronizingObject.InvokeRequired)
			{
				//Marshal the call to the thread that owns the synchronizing object.
				this.SynchronizingObject.Invoke(new DownloadCompletedEventInvoker(OnDownloadCompleted), new object[] {e});
			}
			else
			{
                DownloadCompleted(this, e);
				//if (DownloadCompletedEvent != null)
				//	DownloadCompletedEvent(this, e);
			}
		}
		
#endregion
		
	}
	
	
	//// This class is passed as a parameter to the GetResponse Callback,
	//// so we can work with the data in the Response Callback.
	public class HttpWebRequestState
	{
		private string _LocalFilePath;
		private HttpWebRequest _Request;
		private bool _ResumeDownload;
		private object _userToken;
		
		public HttpWebRequestState(string LocalFilePath, HttpWebRequest Request, bool ResumeDownload, object userToken)
		{
			_LocalFilePath = LocalFilePath;
			_Request = Request;
			_ResumeDownload = ResumeDownload;
			_userToken = userToken;
		}
		
		public string LocalFilePath
		{
			get
			{
				return _LocalFilePath;
			}
		}
		
		public HttpWebRequest Request
		{
			get
			{
				return _Request;
			}
		}
		
		public bool ResumeDownload
		{
			get
			{
				return _ResumeDownload;
			}
		}
		
		public object userToken
		{
			get
			{
				return _userToken;
			}
		}
	}
	
	
	//// This is the data returned to the user for each download in the
	//// Progress Changed event, so you can update controls with the progress.
	public class FileDownloadProgressChangedEventArgs : System.EventArgs
	{
		
		private int _BytesReceived;
		private int _TotalBytesToReceive;
		private int _DownloadTime;
		private long _DownloadSpeed;
		private object _userToken;
		
		public FileDownloadProgressChangedEventArgs(int BytesReceived, int TotalBytesToReceive, int DownloadTime, long DownloadSpeed, object userToken)
		{
			_BytesReceived = BytesReceived;
			_TotalBytesToReceive = TotalBytesToReceive;
			_DownloadTime = DownloadTime;
			_DownloadSpeed = DownloadSpeed;
			_userToken = userToken;
		}
		
		public int BytesReceived
		{
			get
			{
				return _BytesReceived;
			}
		}
		
		public int TotalBytesToReceive
		{
			get
			{
				return _TotalBytesToReceive;
			}
		}
		
		public int ProgressPercentage
		{
			get
			{
				if (_TotalBytesToReceive > 0)
				{
					return (int) (Math.Ceiling((decimal) (((double) _BytesReceived / _TotalBytesToReceive) * 100)));
				}
				else
				{
					return -1;
				}
			}
		}
		
		public int DownloadTimeSeconds
		{
			get
			{
				return _DownloadTime;
			}
		}
		
		public int RemainingTimeSeconds
		{
			get
			{
				if (DownloadSpeedBytesPerSec > 0)
				{
					return (int) (Math.Ceiling((decimal) ((double) (_TotalBytesToReceive - _BytesReceived) / DownloadSpeedBytesPerSec)));
				}
				else
				{
					return 0;
				}
			}
		}
		
		public long DownloadSpeedBytesPerSec
		{
			get
			{
				return _DownloadSpeed;
			}
		}
		
		public object userToken
		{
			get
			{
				return _userToken;
			}
		}
	}
	
	
	//// This is the data returned to the user for each download in the
	//// Download Completed event, so you can update controls with the result.
	public class FileDownloadCompletedEventArgs : System.EventArgs
	{
		
		private Exception _ErrorMessage;
		private bool _Cancelled;
		private object _userToken;
		
		public FileDownloadCompletedEventArgs(Exception ErrorMessage, bool Cancelled, object userToken)
		{
			_ErrorMessage = ErrorMessage;
			_Cancelled = Cancelled;
			_userToken = userToken;
		}
		
		public Exception ErrorMessage
		{
			get
			{
				return _ErrorMessage;
			}
		}
		
		public bool Cancelled
		{
			get
			{
				return _Cancelled;
			}
		}
		
		public object userToken
		{
			get
			{
				return _userToken;
			}
		}
	}
}
