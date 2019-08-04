using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grayScale_image
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        public  Bitmap MakeGrayscale(Bitmap original)
        {           
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);           
            Graphics g = Graphics.FromImage(newBitmap);

           
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
               });
           
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);
            
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
          
            g.Dispose();
            return newBitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog dlg = new OpenFileDialog()) {
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(dlg.FileName);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = MakeGrayscale((Bitmap)pictureBox1.Image);
        }
    }
}
