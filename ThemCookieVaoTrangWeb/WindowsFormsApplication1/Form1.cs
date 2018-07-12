using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class TrinhDuyet : Form
    {
        public TrinhDuyet()
        {
            InitializeComponent();
        }

        public Task<string> MakeAsyncRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.0.5) Gecko/2008120122 Firefox/3.0.5";
            Cookie cookie = new Cookie("psortfilter", txt_cookie.Text);
            request.CookieContainer = new CookieContainer();
            Uri uri = new Uri(url);
            request.CookieContainer.Add(uri, cookie);

            request.Method = WebRequestMethods.Http.Get;
            request.Timeout = 20000;
            request.Proxy = null;

            Task<WebResponse> task = Task.Factory.FromAsync(request.BeginGetResponse, asyncResult => request.EndGetResponse(asyncResult), (object)null);

            return task.ContinueWith(t => ReadStreamFromResponse(t.Result));
        }

        private static string ReadStreamFromResponse(WebResponse response)
        {
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader sr = new StreamReader(responseStream))
            {
                string strContent = sr.ReadToEnd();
                return strContent;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string http = tbx_address.Text;
            Uri uriResult;
            bool result = Uri.TryCreate(http, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
            if (result)
            {
                string data = MakeAsyncRequest(http).Result;
                rtx_viewCode.Text = data;
                wbr_Browser.DocumentText = data;
            }
            else
            {
                MessageBox.Show("Nhập sai địa chỉ", "Lỗi");
            }
        }
    }
}
