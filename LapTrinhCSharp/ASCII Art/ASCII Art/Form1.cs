using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASCII_Art
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string filename;

        private void btn_browser_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    filename = dlg.FileName;
                    pictureBox1.Image = Image.FromFile(filename);
                }
            }
        }

        private void btn_convert_Click(object sender, EventArgs e)
        {
            Image img = Image.FromFile(filename);
            Bitmap bmp = new Bitmap(img, 100, 100);
            show_image(convert_image(bmp));
        }

        private unsafe StringBuilder convert_image(Bitmap bmp)
        {
            StringBuilder asciiResult = new StringBuilder();
            asciiResult.Append("");

            int bmpHeight = bmp.Height;
            int bmpWidth = bmp.Width;

            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmpWidth, bmpHeight), ImageLockMode.ReadOnly, bmp.PixelFormat);

            int bmpStride = bmpData.Stride;
            byte* currentPixel = (byte*)bmpData.Scan0;

            for (int y = 0; y < bmpHeight; y++)
            {
                for (int x = 0; x < bmpWidth; x++)
                {
                    int r = currentPixel[x * 4];
                    int g = currentPixel[x * 4 + 1];
                    int b = currentPixel[x * 4 + 2];
                    int alpha = currentPixel[x * 4 + 3];
                     asciiResult.Append($@"<span style='color: rgb({r},{ g},{ b}); '>{getAsciiChar(alpha)}</span>");

                }
                currentPixel += bmpStride;
                asciiResult.Append("<br>");

            }
            asciiResult.Append("<br>");

            bmp.UnlockBits(bmpData);
            return asciiResult;
        }

        private char getAsciiChar(int alpha)
        {
            if (alpha >= 240)
                return '@';
            if (alpha >= 200)
                return '#';
            if (alpha >= 160)
                return '$';
            if (alpha >= 120)
                return '%';
            if (alpha >= 80)
                return '8';
            if (alpha >= 40)
                return '|';

            return '.';
        }
        private void show_image(StringBuilder asciiResult)
        {
            StreamWriter sw = new StreamWriter("image.html");
            sw.Write(asciiResult.ToString());
            sw.Close();

            string html = asciiResult.ToString();
            webBrowser1.DocumentText = html;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.Document.Body.Style = "zoom:20%;";
        }
    }
}

