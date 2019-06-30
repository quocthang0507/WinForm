using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math;
using AForge.Math.Geometry;
using System.IO;
using System.Xml;
using OMR;
using OMR.Enums;
using OMR.Forms; 
using OMR.helpers;

namespace OMRReader_test1
{
    //this Form may serve as a sample on how to use the main functionality of OMR reader and OMR engine
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private bool isSame(UnmanagedImage img1, UnmanagedImage img2)
        {
            int count = 0, tcount = img2.Width * img2.Height;
            for (int y = 0; y< img1.Height;y++)
                for (int x = 0; x < img1.Width; x++)
                {
                    Color c1 = img1.GetPixel(x,y), c2 = img2.GetPixel(x,y);
                    if ((c1.R + c1.G + c1.B) / 3 > (c2.R + c2.G + c2.B) / 3 - 10 && 
                        (c1.R + c1.G + c1.B) / 3 < (c2.R + c2.G + c2.B) / 3 + 10)
                        count++;
                }
            return (count * 100) / tcount >= 50;
        }
        TimeSpan ts = new TimeSpan(DateTime.Now.Ticks);
        private void showTimeStamp(string str)
        {
            statusTB.AppendText(str + ": " + (new TimeSpan(DateTime.Now.Ticks) - ts).TotalSeconds + "\r\n");
            ts = new TimeSpan(DateTime.Now.Ticks);
        }
        private System.Drawing.Point[] ToPointsArray(List<IntPoint> points)
        {
            System.Drawing.Point[] array = new System.Drawing.Point[points.Count];

            for (int i = 0, n = points.Count; i < n; i++)
            {
                array[i] = new System.Drawing.Point(points[i].X, points[i].Y);
            }

            return array;
        }
        private List<System.Drawing.Point> afPointListToSystem(List<IntPoint> points)
        {
            List<System.Drawing.Point> list_ = new List<System.Drawing.Point>();

            for (int i = 0, n = points.Count; i < n; i++)
            {
                list_.Add(new System.Drawing.Point(points[i].X, points[i].Y));
            }

            return list_;
        }


        
        private void fullProcessB_Click(object sender, EventArgs e)
        {
            ts = new TimeSpan(DateTime.Now.Ticks);
            inDepthImages = new List<System.Drawing.Image>();
            indepthMessages = new List<string>();
            inDepthListCrsr = 0;
            statusTB.Text = "";
            showTimeStamp("Process Started");
            mainImageP.BackgroundImage = System.Drawing.Image.FromFile(filenamet.Text);
            Bitmap unf = new Bitmap(mainImageP.BackgroundImage);
            OpticalReader reader = new OpticalReader();
            engine = new OMREngine(filenamet.Text, sheetAddTB.Text, sheetNameTB.Text, akTitleTB.Text);
            engine.inDepthFeedBack = true;
            engine.onInDepthProessUpdate += engine_onInDepthProessUpdate;
            engine.StartProcess();
            string readAbleResult = "";
            readAbleResult += "Total Empty blocks: " + engine.EmptyBlocks.Count.ToString() + "\r\n";
            readAbleResult += "Total Answer blocks: " + engine.AnswerBlocks.Count.ToString() + "\r\n";
            readAbleResult += "Total Number blocks: " + engine.NumberBlocks.Count.ToString() + "\r\n";
            for (int i = 0; i < engine.NumberBlocks.Count; i++)
                readAbleResult += "Value of Number Block [" + (i + 1).ToString() + "]: " + engine.NumberBlocks[i].MarkedValue.ToString() + "\r\n";
            for (int i = 0; i < engine.AnswerBlocks.Count; i++)
                readAbleResult += "Result of Answer Block [" + (i + 1).ToString() + "]: " + engine.AnswerBlocks[i].ToString() + "\r\n";

            statusTB.AppendText(readAbleResult);
            mainImageP.Invalidate();
        }

        void engine_onInDepthProessUpdate(ProgressUpdateEventArgs e)
        {
            if (e.LatestImage != null && e.IsMainImage == true)
            {
                mainImageP.BackgroundImage = new Bitmap(e.LatestImage);
            }
            else if (e.LatestImage != null)
            {
                inDepthPanel.BackgroundImage = new Bitmap(e.LatestImage);
                inDepthImages.Add(inDepthPanel.BackgroundImage);
                indepthMessages.Add(e.UpdateText);
                inDepthListCrsr++;
            }

            statusTB.AppendText(e.UpdateText + "\r\n");
            mainImageP.Invalidate();
            Application.DoEvents();
        }

        private void Reader_ProgressUpdateEvent(ProgressUpdateEventArgs e)
        {
            if (e.LatestImage != null && e.IsMainImage == true)
            {
                mainImageP.BackgroundImage = new Bitmap( e.LatestImage);
            }
            else if (e.LatestImage != null)
            {
                inDepthPanel.BackgroundImage = new Bitmap(e.LatestImage);
                inDepthImages.Add(inDepthPanel.BackgroundImage);
                indepthMessages.Add(e.UpdateText);
                inDepthListCrsr++;
            }

            statusTB.AppendText(e.UpdateText+"\r\n");
            mainImageP.Invalidate();
            Application.DoEvents();
        }
        
        private void answerKeyDesignerB_Click(object sender, EventArgs e)
        {
            omrSheetDesigner rrf = new omrSheetDesigner();
            rrf.StartPosition = FormStartPosition.CenterParent;
            rrf.ShowDialog(this);
        }

        private void testImageForExtractionB_Click(object sender, EventArgs e)
        {
            showTimeStamp("Preparing for extraciton");
            OpticalReader reader = new OpticalReader();
            mainImageP.BackgroundImage = System.Drawing.Image.FromFile(filenamet.Text);
            histoGramRawP.BackgroundImage = ImageUtilities.drawHistogram(ImageUtilities.histogram(mainImageP.BackgroundImage));
            
            histoGramSmoothP.BackgroundImage =  ImageUtilities.drawSmoothHistogramWithMaximas(mainImageP.BackgroundImage);
            mainImageP.BackgroundImage = reader.prepareForObjectDetection(new Bitmap(mainImageP.BackgroundImage), 0, false);
            showTimeStamp("Image ready");
        }
        
        /// <summary>
        /// this event is written only to check if the selected image can be loaded 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readImageB_Click(object sender, EventArgs e)
        {
            showTimeStamp("Starting Image Read");
            mainImageP.BackgroundImage = System.Drawing.Image.FromFile(filenamet.Text);
            histoGramRawP.BackgroundImage = ImageUtilities.drawHistogram(ImageUtilities.histogram(mainImageP.BackgroundImage));
            histoGramSmoothP.BackgroundImage = ImageUtilities.drawSmoothHistogramWithMaximas(mainImageP.BackgroundImage);
            showTimeStamp("Image Loaded.");
        }
        OMR.OMREngine engine;
        List<System.Drawing.Image> inDepthImages = new List<System.Drawing.Image>();
        List<string> indepthMessages = new List<string>();
        private void engineTesterB_Click(object sender, EventArgs e)
        {
            engine = new OMREngine(filenamet.Text, sheetAddTB.Text, sheetNameTB.Text, akTitleTB.Text);
            inDepthImages = new List<System.Drawing.Image>();
            asyncProgress.Value = 0;
            engine.inDepthFeedBack = true;
            engine.onAsyncProgressUpdated += Engine_onAsyncProgressUpdated;
            engine.onAsyncCompletion += Engine_onAsyncCompletion;
            engine.OnExtractionFailed += Engine_OnExtractionFailed;
            engine.onInDepthProessUpdate += Engine_onInDepthProessUpdate;
            engine.StartProcessAsync();
            asyncPrT.Enabled = true;
        }

        private void Engine_onInDepthProessUpdate(ProgressUpdateEventArgs e)
        {
            if (e.LatestImage != null && e.IsMainImage == true)
            { asImage1 = e.LatestImage; }
            else if (e.LatestImage != null && e.IsMainImage == false)
            {
                asImage2 = e.LatestImage;
                inDepthImages.Add(e.LatestImage);
                indepthMessages.Add(e.UpdateText);
                if (indepthMessages.Count >= 1)
                {
                    inDepthListCrsr = 0;
                }

            }

            asMessage2 = e.UpdateText + "\r\n";
        }

        private void Engine_OnExtractionFailed(ExtractionFailedArgs e)
        {
            asMessage += "Extraction failed: " + e.FailureException.Message + "\r\n";
        }

        private void Engine_onAsyncCompletion(CompletionEvenArgs e)
        {
            asMessage += "A sync process complete. Set a break point and diagnose the engine member for more details on the results\r\n";
            asMessage += "Total Empty blocks: " + engine.EmptyBlocks.Count.ToString() + "\r\n";
            asMessage += "Total Answer blocks: " + engine.AnswerBlocks.Count.ToString() + "\r\n";
            asMessage += "Total Number blocks: " + engine.NumberBlocks.Count.ToString() + "\r\n";
            for (int i = 0; i < engine.NumberBlocks.Count; i++)
                asMessage += "Value of Number Block [" + i.ToString() + "]: " + engine.NumberBlocks[i].MarkedValue.ToString() + "\r\n";
            for (int i = 0; i < engine.AnswerBlocks.Count; i++)
                asMessage += "Result of Answer Block [" + i.ToString() + "]: " + engine.AnswerBlocks[i].ToString() + "\r\n";
            asProgress = 0;
        }

        private void Engine_onAsyncProgressUpdated(ProgressEventArgs e)
        {
            asProgress = e.Value;
        }

        void engine_onAsyncProgressUpdated(object sender, ProgressEventArgs e)
        {
            asProgress = e.Value;
        }



        private void multiTaskB_Click(object sender, EventArgs e)
        {
            OMR.helpers.MultiThreading mtr = new MultiThreading(3, Directory.GetFiles("testImages", "*.jpg"), "omrSheet1.accdb", "A4_1");
            mtr.onProgressChanged += new AsyncProgressEventHandler(mtr_onProgressChanged);
            mtr.onThreadCompleted += new AsyncCompletionEventHandler(mtr_onThreadCompleted);
            mtr.onAllCompleted += new AsyncCompletionEventHandler(mtr_onAllCompleted);
            asyncPrT.Enabled = true;
            mtr.StartProcess();
        }

        public volatile int asProgress = 0, inDepthListCrsr = - 1;
        public volatile string asMessage = "", asMessage2;
        public volatile System.Drawing.Image asImage1, asImage2;
        private void asyncPrT_Tick(object sender, EventArgs e)
        {
            asyncProgress.Value = asProgress;
            if (asImage1 != null)
            {
                try
                {
                    mainImageP.BackgroundImage = new Bitmap(asImage1);
                }
                catch (InvalidOperationException)
                { }
                asImage1 = null;
                mainImageP.Invalidate();
                Application.DoEvents();                
            }
            if (asImage2 != null)
            {
                inDepthPanel.BackgroundImage = new Bitmap(asImage2);
                asImage2 = null;
                inDepthPanel.Invalidate();
                Application.DoEvents();
            }
            if (asMessage.Length > 0)
            {
                statusTB.Text += asMessage;
                asMessage = "";
            }
            if (asMessage2.Length> 0)
            {
                inDepthUpdates.Text += asMessage2;
                asMessage2 = "";
            }
            if (asProgress >= 100)
                asyncPrT.Enabled = false;
        }

        void mtr_onAllCompleted(CompletionEvenArgs e)
        {
            MessageBox.Show("All completed");
        }

        void mtr_onThreadCompleted(CompletionEvenArgs e)
        {
            asMessage += "Process "+ e.EngineIndex.ToString() + " completed.\r\n";
        }

        void mtr_onProgressChanged(ProgressEventArgs e)
        {
            asProgress = e.Value;
        }

        private void button10_MouseHover(object sender, EventArgs e)
        {
        }

        private void prevB_Click(object sender, EventArgs e)
        {
            inDepthListCrsr--;
            if (inDepthListCrsr < 0)
            {
                inDepthListCrsr++;
            }
            if (inDepthImages.Count > 0 && inDepthListCrsr < inDepthImages.Count)
            {
                inDepthTB.Text = indepthMessages[inDepthListCrsr];
                inDepthPanel.BackgroundImage = inDepthImages[inDepthListCrsr];
                inDepthPanel.Invalidate();
                Application.DoEvents();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OMR.Forms.answerKeyDesigner akd = new answerKeyDesigner();
            akd.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("omrConsole_classic.exe");
        }

        private void nextB_Click(object sender, EventArgs e)
        {
            inDepthListCrsr++;
            if (inDepthListCrsr >= inDepthImages.Count)
            {
                inDepthListCrsr--;
            }

            if (inDepthImages.Count > 0 && inDepthListCrsr < inDepthImages.Count)
            {
                inDepthTB.Text = indepthMessages[inDepthListCrsr];
                inDepthPanel.BackgroundImage = inDepthImages[inDepthListCrsr];
                inDepthPanel.Invalidate();
                Application.DoEvents();
            }
        }

        private void statusTB_TextChanged(object sender, EventArgs e)
        {
            statusTB.Select(0, statusTB.Text.Length);
            statusTB.ScrollToCaret();
        }

        private void inDepthUpdates_TextChanged(object sender, EventArgs e)
        {
            inDepthUpdates.Select(0, inDepthUpdates.Text.Length);
            inDepthUpdates.ScrollToCaret();
        }
    }
}
