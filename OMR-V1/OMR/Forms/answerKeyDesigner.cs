using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OMR.Forms
{
    public partial class answerKeyDesigner : Form
    {
        public answerKeyDesigner()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        Image tempObject;
        List<Image> history = new List<Image>();
        int imgScale = 7;
        private void setSheetSize_Click(object sender, EventArgs e)
        {
            bool permit = false;
            if (sheet.BackgroundImage == null)
                permit = true;
            //else  if (MessageBox.Show(this, "This will clear the image.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            else 
            {
                permit = true;
            }
            if (permit)
            {
                if (sheetSize.SelectedIndex == 0)
                {
                    sheet.BackgroundImage = new Bitmap(2100, 2970);
                    imgScale = 6;
                }

                if (sheetSize.SelectedIndex == 1)
                {
                    sheet.BackgroundImage = new Bitmap(2970, 2100);
                    imgScale = 7;
                }
                if (sheetSize.SelectedIndex == 2)
                {
                    sheet.BackgroundImage = new Bitmap(1485, 2100);
                    imgScale = 5;
                }
                if (sheetSize.SelectedIndex == 3)
                {
                    sheet.BackgroundImage = new Bitmap(2100, 1485);
                    imgScale = 5;
                }
                if (sheetSize.SelectedIndex >= 0)
                {
                    sheet.Size = new Size(sheet.BackgroundImage.Width / imgScale, sheet.BackgroundImage.Height / imgScale);
                    bkpImg = (Image)new Bitmap(sheet.BackgroundImage);
                    g = Graphics.FromImage(sheet.BackgroundImage);
                    allControls.Enabled = true;
                    clearImage();
                    help.Text = "Add an object.";
                }
            }
        }


        private void clearImage()
        {
            g.Clear(Color.White);
            g.DrawRectangle(new Pen(Brushes.Black, 6), new Rectangle(
                (int)(sheet.BackgroundImage.Width * 0.025),
                (int)(sheet.BackgroundImage.Width * 0.025),
                (int)(sheet.BackgroundImage.Width - sheet.BackgroundImage.Width * 0.05),
                (int)(sheet.BackgroundImage.Height - sheet.BackgroundImage.Width * 0.05)));
            g.FillPolygon(Brushes.Black, new Point[] { 
                new Point ((int)(sheet.BackgroundImage.Width * 0.025 + 12), (int)(sheet.BackgroundImage.Width * 0.025 + 8)),
                new Point ((int)(sheet.BackgroundImage.Width * 0.025 + 12), (int)(sheet.BackgroundImage.Width * 0.025 + 8 +50)),
                new Point ((int)(sheet.BackgroundImage.Width * 0.025 + 12 + 43), (int)(sheet.BackgroundImage.Width * 0.025 +8 + 25))
            });
            g.FillPolygon(Brushes.Black, new Point[] { 
                new Point ((int)(sheet.BackgroundImage.Width * 0.975 - 12), (int)(sheet.BackgroundImage.Width * 0.025 + 8)),
                new Point ((int)(sheet.BackgroundImage.Width * 0.975 - 12), (int)(sheet.BackgroundImage.Width * 0.025 + 8 +50)),
                new Point ((int)(sheet.BackgroundImage.Width * 0.975 - 12 - 43), (int)(sheet.BackgroundImage.Width * 0.025 +8 + 25))
            });
            bkpImg = (Image)new Bitmap(sheet.BackgroundImage);
        }

        Graphics g;
        private void answerKeyDesigner_Load(object sender, EventArgs e)
        {
            help.Text = "Select sheet size first";
            sheetSize.SelectedIndex = 0;
            nOfOpts.SelectedIndex = 2;
            digitsOfRegNum.SelectedIndex = 2;
            sizeOfBlock.SelectedIndex = 0;
            typeOfOpt.SelectedIndex = 0;
        }
        Image bkpImg;
        Point objLoc = new Point(0, 0);
        private void drawTempObject()
        {
            objLoc.X = ((int)objLoc.X / 50) * 50;
            objLoc.Y = ((int)objLoc.Y / 50) * 50;
            g.Clear(Color.White);
            g.DrawImage(bkpImg, 0, 0);
            g.DrawImage(tempObject, objLoc);
            sheet.Invalidate();
        }
        private Image makeBubbleSheet(int options, int totalAnswers, char optionChar, int indexingStart)
        {
            Image tBmp = (Image)new Bitmap(1,1);
            Graphics g2 = Graphics.FromImage(tBmp);
            
            
            int circleSize = 45;
            int spacing = 20;
            int lineWidth = 5;
            int indBlockXSpacing = 10;
            int indBlockWid;
            Font opFont = new Font("Arial", (circleSize * 50) / 100);
            Font numFont = new Font("Arial", circleSize);

            indBlockWid = 0;
            if (indexingStart <= 0)
                indBlockWid = 0;
            else
            {
                int maxWid = 0;
                for (int i = 0; i < options; i++)
                {
                    int tw = (int)g2.MeasureString((i + indexingStart).ToString(), numFont).Width;
                    if (tw > maxWid)
                        maxWid = tw;
                }
                indBlockWid = maxWid + indBlockXSpacing;
            }
            tBmp = new Bitmap(indBlockWid + options * (circleSize + spacing) + spacing, totalAnswers * (circleSize + spacing) + spacing);
            g2 = Graphics.FromImage(tBmp);
            g2.Clear(Color.White);

            g2.DrawRectangle(new Pen(Brushes.Black, lineWidth * 2), new Rectangle(indBlockWid, 0,tBmp.Width - indBlockWid, tBmp.Height));

            for (int j = 0; j < totalAnswers; j++)
            {
                for (int i = 0; i < options; i++)
                {
                    g2.DrawEllipse(new Pen(Brushes.Black, lineWidth),
                        new Rectangle(indBlockWid + (circleSize + spacing) * i + spacing, (circleSize + spacing) * j + spacing, circleSize, circleSize));
                    if (optionChar != 0 && optionChar != 'N')
                    {
                        string num = ((char)(optionChar + i)).ToString();
                        int numX = (circleSize - (int)g2.MeasureString(num, opFont).Width) / 2;
                        Point numLoc = new Point(indBlockWid + (circleSize + spacing) * i + spacing + numX, (circleSize + spacing) * j + spacing + numX);
                        if (optionChar == 'a' || optionChar == '1'|| optionChar == '0')
                            numLoc = new Point(numLoc.X, numLoc.Y - circleSize / 15);
                        g2.DrawString(num, opFont, Brushes.Black, numLoc);
                    }
                }
                if (indexingStart > 0)
                {
                    string ansNum = (indexingStart + j).ToString();
                    int length = (int)g2.MeasureString(ansNum, numFont).Width;
                    int indX = indBlockWid - length - indBlockXSpacing;
                    g2.DrawString(ansNum, numFont, Brushes.Black, new Point(indX, (circleSize + spacing) * j + spacing/2));
                }
            }
            return tBmp;
        }
        private void addBubbleBlock_Click(object sender, EventArgs e)
        {
            tempObject = makeBubbleSheet(Convert.ToInt16(nOfOpts.Text), Convert.ToInt16(sizeOfBlock.Text), typeOfOpt.Text[0], startOfNum.Checked ? (int)startNum.Value : 0);
            drawTempObject();
        }

        private bool onObj(Point crsr)
        {
            Rectangle rect = new Rectangle(objLoc, tempObject.Size);

            crsr = new Point(crsr.X * imgScale, crsr.Y * imgScale);
            return rect.Contains(crsr);

        }
        private void sheet_MouseMove(object sender, MouseEventArgs e)
        {
            if (tempObject != null)
            {
                if (onObj(e.Location))
                {
                    Cursor = Cursors.Hand;
                    if (e.Button == MouseButtons.Left)
                    {
                        objLoc = new Point(e.X * imgScale - objectHandledAt.X, e.Y * imgScale - objectHandledAt.Y);
                        drawTempObject();
                    }
                }
                else
                    Cursor = Cursors.Default;
            }
        }

        Point objectHandledAt = new Point();
        private void sheet_MouseDown(object sender, MouseEventArgs e)
        {
            objectHandledAt = new Point(e.X * imgScale - objLoc.X, e.Y * imgScale - objLoc.Y);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure if you want to freeze the current image. This cannot be undone", "Can't undo.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                bkpImg = (Image)new Bitmap(sheet.BackgroundImage);
                sheet.BackgroundImage = (Image)new Bitmap(bkpImg);
                g = Graphics.FromImage(sheet.BackgroundImage);
                tempObject = null;
                sheet.Invalidate();

            }
        }

        private void addRegBlock_Click(object sender, EventArgs e)
        {
            tempObject = makeBubbleSheet(10, Convert.ToInt16(digitsOfRegNum.Text), '0', 0);
            drawTempObject();
        }

        private void addTextBlock_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This part is under construction");
            Font f =  new Font("CAMBRIA", 60);
            tempObject = new Bitmap(
                (int)g.MeasureString(richTextBox1.Text,f).Width + 10,
                (int)g.MeasureString(richTextBox1.Text, f).Height + 10
                );
            Graphics g2 = Graphics.FromImage(tempObject);
            g2.Clear(Color.White);
            g2.DrawRectangle(new Pen(Brushes.Black, 10), new Rectangle(new Point(0, 0), tempObject.Size));
            g2.DrawString(richTextBox1.Text, f, Brushes.Black, 5, 5);
            drawTempObject();
        }


    }
}
