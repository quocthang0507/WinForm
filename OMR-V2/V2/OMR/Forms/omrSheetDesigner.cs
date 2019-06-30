using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using OMR.helpers;

namespace OMR.Forms
{
    public partial class omrSheetDesigner : Form
    {
        public omrSheetDesigner()
        {
            InitializeComponent();
        }
        int indexForDeletion = -1;
        Graphics g;
        bool globalSheetEditEnableFlag = true;
        List<Panel> blocks = new List<Panel>();
        List<Graphics> gElements = new List<Graphics>();
        double drawingScale = 1;
        List<Point> numberings = new List<Point>();
        private void setSheetSize_Click(object sender, EventArgs e)
        {
            Size sheetSize = new Size();
            if (sheetSizeCB.SelectedIndex >= 0)
            {
                if (sheetSizeCB.SelectedIndex == 0)
                {
                    sheetSize = new Size(210 * 20, 297 * 20);
                    sheet.Size = new Size(424, 600);
                    this.Size = new Size(739, 654);
                }
                else if (sheetSizeCB.SelectedIndex == 1)
                {
                    sheetSize = new Size(297 * 20, 210 * 20);
                    sheet.Size = new Size(700, 495);
                    this.Size = new Size(1020, 555);
                }
                else if (sheetSizeCB.SelectedIndex == 2)
                {
                    sheetSize = new Size(297 * 20 / 2, 210 * 20);
                    sheet.Size = new Size(424, 600);
                    this.Size = new Size(739, 654);
                }
                else if (sheetSizeCB.SelectedIndex == 3)
                {
                    sheetSize = new Size(210 * 20, 297 * 20 / 2);
                    sheet.Size = new Size(700, 495);
                    this.Size = new Size(1020, 555);
                }
                if (sheetSizeCB.SelectedIndex > 1)
                    sheetSize = new System.Drawing.Size(sheetSize.Width / 2, sheetSize.Height / 2);
                sheet.BackgroundImage = new Bitmap(sheetSize.Width / 20, sheetSize.Height / 20);
                g = Graphics.FromImage(sheet.BackgroundImage);
                allControls.Enabled = true;
                redrawSheetImage(false);
                help.Text = "Add an object.";
                drawingScale = (double)sheet.BackgroundImage.Width * 20 / (double)sheet.Width;
            }
        }
        private void browsBkB_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                bkImageTB.Text = openFile.FileName;

            }

        }

        private void setBckB_Click(object sender, EventArgs e)
        {
            if (SystemUtils.checkGS()) redrawSheetImage(false);
        }

        bool ImageIsFullSize = false;
        private void redrawSheetImage(bool fullSize)
        {
            string bkUp = help.Text;

            if (fullSize != ImageIsFullSize)
            {
                if (fullSize)
                    sheet.BackgroundImage = new Bitmap(sheet.BackgroundImage.Width * (ImageIsFullSize ? 1 : 20), sheet.BackgroundImage.Height * (ImageIsFullSize ? 1 : 20));
                else
                    sheet.BackgroundImage = new Bitmap(sheet.BackgroundImage.Width / (ImageIsFullSize ? 20 : 1), sheet.BackgroundImage.Height / (ImageIsFullSize ? 20 : 1));

                ImageIsFullSize = fullSize;
                g = Graphics.FromImage(sheet.BackgroundImage);
            }
            help.Text = "Please Select a PDF file whose first page will become the background.";
            Cursor = Cursors.AppStarting;
            g.Clear(Color.White);
            Image bk;
            try
            {
                if (bkImageTB.Text == "")
                    throw new Exception("Select a file first");

                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo("pdfToJPG.exe", bkImageTB.Text);
                p.Start();
                p.WaitForExit();
                bk = Image.FromFile("tempPdfSave.bmp");
                g.DrawImage(bk, 0, 0, sheet.BackgroundImage.Width, sheet.BackgroundImage.Height);
            }
            catch
            {
                help.Text = "Conversion failed";
            }
            finally
            {
                help.Text = bkUp;
            }
            int markLength = 150 / (fullSize ? 1 : 20), margin = 100 / (fullSize ? 1 : 20), wid = sheet.BackgroundImage.Width, hei = sheet.BackgroundImage.Height;
            Size markSize = new System.Drawing.Size(markLength, markLength);

            g.DrawImage(Image.FromFile("LC Prints.jpg"), new Rectangle(new Point(margin, margin), markSize));
            g.DrawImage(Image.FromFile("LC Prints.jpg"), new Rectangle(new Point(margin, hei - margin - markLength), markSize));
            g.DrawImage(Image.FromFile("RC Prints.jpg"), new Rectangle(new Point(wid - margin - markLength, margin), markSize));
            g.DrawImage(Image.FromFile("RC Prints.jpg"), new Rectangle(new Point(wid - margin - markLength, hei - margin - markLength), markSize));
            sheet.Invalidate();
            Cursor = Cursors.Default;

            if (!fullSize)
            {
                MessageBox.Show("The background image has been optimized for performance. Don't worry if it looks ugly. It will look better in final output.");
            }
        }

        private void omrSheetDesigner_Load(object sender, EventArgs e)
        {
            if (!SystemUtils.checkGS()) MessageBox.Show("PDF creation and reading will be disabled.");
            sheetSizeCB.SelectedIndex = 0;
            optCharCB.SelectedIndex = 0;

            this.Location = new Point(100, 10);
            this.Size = new System.Drawing.Size(311, 424);
            help.Text = "Select sheet size first.";
            sheetSizeCB.SelectedIndex = 0;
        }
        //add new block
        //add ind to ansBlock list
        private void addBubbleBlock_Click(object sender, EventArgs e)
        {
            if (globalSheetEditEnableFlag)
            {
                addNewBlock(makeBubbleSheet(new Size(80, 150)));
                answerBlocks.Add(sheet.Controls.Count - 1);
            }
        }

        private void addRegBlock_Click(object sender, EventArgs e)
        {
            if (globalSheetEditEnableFlag)
            {
                addNewBlock(makeRegBlock(3));
                regBlocks.Add(sheet.Controls.Count - 1);
            }
        }
        private void addTextBlock_Click(object sender, EventArgs e)
        {
            if (globalSheetEditEnableFlag)
            {
                addNewBlock(Image.FromFile("textInputTile.jpg"));
                emptyBlocks.Add(sheet.Controls.Count - 1);
                sheet.Controls[sheet.Controls.Count - 1].BackgroundImageLayout = ImageLayout.Tile;
                sheet.Controls[sheet.Controls.Count - 1].Size = new Size(100, 100);
            }
        }
        private void addNewBlock(Image img)
        {
            int i = blocks.Count;
            blocks.Add(new Panel());
            sheet.Controls.Add(blocks[i]);
            blocks[i].BackgroundImage = img;
            blocks[i].MouseEnter += new EventHandler(blocks_MouseEnter);
            blocks[i].MouseLeave += new EventHandler(block_MouseLeave);
            blocks[i].MouseClick += new MouseEventHandler(block_MouseClick);
            blocks[i].MouseMove += new MouseEventHandler(blocks_MouseMove);
            blocks[i].MouseDown += new MouseEventHandler(blocks_MouseDown);
            blocks[i].MouseUp += new MouseEventHandler(blocks_MouseUp);
            blocks[i].BackgroundImageLayout = ImageLayout.Zoom;
            blocks[i].Size = new Size((int)Math.Round((double)blocks[i].BackgroundImage.Width / drawingScale), (int)Math.Round((double)blocks[i].BackgroundImage.Height / drawingScale));
            blocks[i].ContextMenuStrip = blockContextStrip;
        }

        List<int> answerBlocks = new List<int>();
        List<int> imgBlocks = new List<int>();
        List<int> emptyBlocks = new List<int>();
        List<int> regBlocks = new List<int>();

        int SelectedBlockInd
        {
            get
            {
                Point crsr = PositionInPanel;
                return indexByPosition(crsr, 0);
            }
        }
        int blockEditAction = 0;
        int fixedEditBlockInd = -1;
        int underMoveIndex = -1;
        Point lastLocation = new Point(),
        //only used for move op
        locationAtEntry = new Point();
        Point PositionInPanel { get { return new Point(this.PointToClient(Cursor.Position).X - sheet.Location.X, this.PointToClient(Cursor.Position).Y - sheet.Location.Y); } }

        //this should define:
        //edit operation going to be performed, 
        //"If Any"
        //fix editBlockInd
        //fix cursor in accordance to operation
        //help out edit op by giving init info (if any)
        void blocks_MouseDown(object sender, MouseEventArgs e)
        {
            if (globalSheetEditEnableFlag)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 1)
                {
                    Point position = PositionInPanel;
                    int i = indexByPosition(position, 0);
                    int j = indexByPosition(position, 5);
                    //define edit type
                    switch (typeOfBlock(i))
                    {
                        #region Bubble Block
                        case 1:
                            {
                                int right = sheet.Controls[i].Bounds.X + sheet.Controls[i].Bounds.Width;
                                int down = sheet.Controls[i].Bounds.Y + sheet.Controls[i].Bounds.Height;
                                if (position.X < right && position.X > right - 5)
                                {
                                    blockEditAction = 1;
                                    locationAtEntry = PositionInPanel;
                                    Cursor = Cursors.SizeWE;
                                }
                                else if (position.Y < down && position.Y > down - 5)
                                {
                                    blockEditAction = 2;
                                    locationAtEntry = PositionInPanel;
                                    Cursor = Cursors.SizeNS;
                                }
                                else
                                {
                                    blockEditAction = 3;
                                    Cursor = Cursors.NoMove2D;
                                    locationAtEntry = PositionInPanel;
                                    lastLocation = sheet.Controls[i].Location;
                                }
                            }
                            break;
                        #endregion
                        #region Reg Block
                        case 2:
                            {
                                int right = sheet.Controls[i].Bounds.X + sheet.Controls[i].Bounds.Width;
                                int down = sheet.Controls[i].Bounds.Y + sheet.Controls[i].Bounds.Height;
                                if (position.Y < down && position.Y > down - 5)
                                {
                                    blockEditAction = 4;
                                    locationAtEntry = sheet.Controls[i].Location;
                                    Cursor = Cursors.SizeNS;
                                }
                                else
                                {
                                    blockEditAction = 5;
                                    Cursor = Cursors.NoMove2D;
                                    locationAtEntry = PositionInPanel;
                                    lastLocation = sheet.Controls[i].Location;
                                }
                            }
                            break;
                        #endregion
                        #region Empty Block
                        case 3:
                            {
                                int right = sheet.Controls[i].Bounds.X + sheet.Controls[i].Bounds.Width;
                                int down = sheet.Controls[i].Bounds.Y + sheet.Controls[i].Bounds.Height;
                                if ((position.X < right && position.X > right - 5) && (position.Y < down && position.Y > down - 5))
                                {
                                    blockEditAction = 9;
                                    locationAtEntry = PositionInPanel;
                                    lastLocation = sheet.Controls[i].Location;
                                    Cursor = Cursors.SizeNWSE;
                                }
                                else if (position.X < right && position.X > right - 5)
                                {
                                    blockEditAction = 6;
                                    locationAtEntry = PositionInPanel;
                                    lastLocation = sheet.Controls[i].Location;
                                    Cursor = Cursors.SizeWE;
                                }
                                else if (position.Y < down && position.Y > down - 5)
                                {
                                    blockEditAction = 7;
                                    locationAtEntry = PositionInPanel;
                                    lastLocation = sheet.Controls[i].Location;
                                    Cursor = Cursors.SizeNS;
                                }
                                else
                                {
                                    blockEditAction = 8;
                                    Cursor = Cursors.NoMove2D;
                                    locationAtEntry = PositionInPanel;
                                    lastLocation = sheet.Controls[i].Location;
                                }
                            }
                            break;
                        #endregion
                        default: fixedEditBlockInd = -1; blockEditAction = 0; break;
                    }

                    //freeze index
                    if (blockEditAction > 0)
                        fixedEditBlockInd = i;
                }
            }
        }

        //clear edit operation
        //if any
        //snap to grid
        void blocks_MouseUp(object sender, MouseEventArgs e)
        {
            if (globalSheetEditEnableFlag)
            {
                if (blockEditAction == 3 || blockEditAction == 5 || blockEditAction == 8)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        int divider = 1;
                        if (gridBigRB.Checked == true) divider = 16;
                        else if (gridSmallRB.Checked == true) divider = 8;
                        int j = fixedEditBlockInd;
                        if (sheet.Controls[j].Location.X % divider != 0)
                        {
                            if (sheet.Controls[j].Location.X % divider >= divider / 2) // snap forward
                            {
                                sheet.Controls[j].Location = new Point(
                                    sheet.Controls[j].Location.X + divider - sheet.Controls[j].Location.X % divider,
                                    sheet.Controls[j].Location.Y);
                            }
                            else
                            {
                                sheet.Controls[j].Location = new Point(
                                   sheet.Controls[j].Location.X - sheet.Controls[j].Location.X % divider,
                                   sheet.Controls[j].Location.Y);
                            }
                        }

                        if (sheet.Controls[j].Location.Y % divider != 0)
                        {
                            if (sheet.Controls[j].Location.Y % divider > divider / 2)
                            {
                                sheet.Controls[j].Location = new Point(
                                    sheet.Controls[j].Location.X,
                                    sheet.Controls[j].Location.Y + divider - sheet.Controls[j].Location.Y % divider);
                            }
                            else
                            {
                                sheet.Controls[j].Location = new Point(
                                      sheet.Controls[j].Location.X,
                                      sheet.Controls[j].Location.Y - sheet.Controls[j].Location.Y % divider);
                            }
                        }
                    }
                }
                blockEditAction = 0;
            }
        }

        //when no action is being performed, must define cursor shape
        //register entring position
        //get type of block from "int typeOfBlock(int ind)" method
        //in case of regBlock, ans block, 
        //> estimate block parameteres by size
        //> perform snapped edit operation
        //> unsnapped move operation
        //> care for maximum/minimum block size
        //> redraw to fit bubbles
        //in case of other imgBlock
        //> perform unsnapped move/edit
        //> care for Min Size
        //> redraw to maintain line thickness
        //In case of img block, redraw with Zoom. Not stretch
        void blocks_MouseMove(object sender, MouseEventArgs e)
        {
            if (globalSheetEditEnableFlag)
            {
                int i = 0;
                indexForDeletion = indexByPosition(PositionInPanel, 0);
                switch (blockEditAction)
                {
                    #region idleCursorChanges
                    case 0: // no edit operation in action
                        Point position = PositionInPanel;
                        i = indexByPosition(position, 0);
                        switch (typeOfBlock(i))
                        {
                            case 1:
                            case 3:
                                {
                                    int right = sheet.Controls[i].Bounds.X + sheet.Controls[i].Bounds.Width;
                                    int down = sheet.Controls[i].Bounds.Y + sheet.Controls[i].Bounds.Height;
                                    if (typeOfBlock(i) == 3 && (position.X < right && position.X > right - 5) && (position.Y < down && position.Y > down - 5))
                                    {
                                        Cursor = Cursors.SizeNWSE;
                                    }
                                    else if (position.X < right && position.X > right - 5)
                                    {
                                        Cursor = Cursors.SizeWE;
                                    }
                                    else if (position.Y < down && position.Y > down - 5)
                                    {
                                        Cursor = Cursors.SizeNS;
                                    }
                                    else
                                    {
                                        Cursor = Cursors.NoMove2D;
                                    }
                                }
                                break;
                            case 2:
                                {
                                    int right = sheet.Controls[i].Bounds.X + sheet.Controls[i].Bounds.Width;
                                    int down = sheet.Controls[i].Bounds.Y + sheet.Controls[i].Bounds.Height;

                                    if (position.Y < down && position.Y > down - 5)
                                    {
                                        Cursor = Cursors.SizeNS;
                                    }
                                    else
                                    {
                                        Cursor = Cursors.NoMove2D;
                                    }
                                }
                                break;

                        }
                        break;
                    #endregion
                    #region ansBlockOps
                    case 1: // increase No of Opt in answer Block
                        {
                            i = fixedEditBlockInd;
                            Point currentCrsr = PositionInPanel;
                            Size currentSize = sizeOfBlock(sheet.Controls[i].Size, false);
                            Rectangle newToBeRect = new Rectangle(
                                sheet.Controls[i].Location,
                                new System.Drawing.Size(currentCrsr.X - locationAtEntry.X + sheet.Controls[i].Width, sheet.Controls[i].Height));
                            Size newWantedSize = sizeOfBlock(newToBeRect.Size, false);
                            if (newWantedSize.Width >= 2 && newWantedSize.Width <= 6 && newWantedSize.Width != currentSize.Width)
                            {
                                sheet.Controls[i].BackgroundImage = makeBubbleSheet(newToBeRect.Size, i, true);
                                sheet.Controls[i].Size = new Size(
                                    (int)Math.Round((double)sheet.Controls[i].BackgroundImage.Width / drawingScale),
                                    (int)Math.Round((double)sheet.Controls[i].BackgroundImage.Height / drawingScale));
                                locationAtEntry = currentCrsr;
                            }
                        }
                        break;
                    case 2: // increase No of answer in Answers block
                        {
                            i = fixedEditBlockInd;
                            Point currentCrsr = PositionInPanel;
                            Size currentSize = sizeOfBlock(sheet.Controls[i].Size, false);
                            Rectangle newToBeRect = new Rectangle(
                                sheet.Controls[i].Location,
                                new System.Drawing.Size(sheet.Controls[i].Width, currentCrsr.Y - locationAtEntry.Y + sheet.Controls[i].Height));
                            Size newWantedSize = sizeOfBlock(newToBeRect.Size, false);
                            if (newWantedSize.Height % 5 == 0 && newWantedSize.Height >= 5 && newWantedSize.Height <= 40 && newWantedSize.Height != currentSize.Height)
                            {
                                sheet.Controls[i].BackgroundImage = makeBubbleSheet(newToBeRect.Size, i, true);
                                sheet.Controls[i].Size = new Size(
                                    (int)Math.Round((double)sheet.Controls[i].BackgroundImage.Width / drawingScale),
                                    (int)Math.Round((double)sheet.Controls[i].BackgroundImage.Height / drawingScale));
                                locationAtEntry = currentCrsr;
                                refreshAnswerBlocks();
                            }
                        }
                        break;
                    #endregion
                    #region all blocks move op
                    case 3: // all blocks move op
                    case 5:
                    case 8:
                        {
                            i = fixedEditBlockInd;
                            Point newCursor = PositionInPanel;
                            Cursor = Cursors.NoMove2D;
                            Point refAtEntry = new Point(locationAtEntry.X - lastLocation.X, locationAtEntry.Y - lastLocation.Y);
                            sheet.Controls[i].Location = new Point(
                                newCursor.X - refAtEntry.X, newCursor.Y - refAtEntry.Y);
                        }
                        break;
                    #endregion
                    #region regBlockOps
                    case 4: // increase No of digits in reg block
                        {
                            i = fixedEditBlockInd;
                            Point currentCrsr = PositionInPanel;
                            Size currentSize = sizeOfBlock(sheet.Controls[i].Size, true);
                            Rectangle newToBeRect = new Rectangle(
                                sheet.Controls[i].Location,
                                new Size(sheet.Controls[i].Width, currentCrsr.Y - locationAtEntry.Y));
                            Size newWantedSize = sizeOfBlock(newToBeRect.Size, true);
                            if (newWantedSize.Height >= 1 && newWantedSize.Height <= 10 && newWantedSize.Height != currentSize.Height)
                            {
                                sheet.Controls[i].BackgroundImage = makeRegBlock(newWantedSize.Height);
                                sheet.Controls[i].Size = new Size(
                                    (int)Math.Round((double)sheet.Controls[i].BackgroundImage.Width / drawingScale),
                                    (int)Math.Round((double)sheet.Controls[i].BackgroundImage.Height / drawingScale));
                            }
                        }
                        break;
                    #endregion
                    #region Empty Block Ops
                    case 6: // increase  width
                        {
                            i = fixedEditBlockInd;
                            Point currentCrsr = PositionInPanel;
                            Size newSize = new Size(currentCrsr.X - lastLocation.X, sheet.Controls[i].Height);
                            sheet.Controls[i].Size = newSize;
                        }
                        break;
                    case 7: // increase  Height
                        {
                            i = fixedEditBlockInd;
                            Point currentCrsr = PositionInPanel;
                            Size newSize = new Size(sheet.Controls[i].Width, currentCrsr.Y - lastLocation.Y);
                            sheet.Controls[i].Size = newSize;
                        }
                        break;
                    case 9: // increase  both
                        {
                            i = fixedEditBlockInd;
                            Point currentCrsr = PositionInPanel;
                            Size newSize = new Size(currentCrsr.X - lastLocation.X, currentCrsr.Y - lastLocation.Y);
                            sheet.Controls[i].Size = newSize;
                        }
                        break;
                    #endregion
                }
            }
        }

        //C
        //Not Planned any action for this yet
        void block_MouseClick(object sender, MouseEventArgs e)
        {
            if (globalSheetEditEnableFlag)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {

                }

            }
        }

        //C
        // assures cursor shape changes back
        void block_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        //C
        //not planned any action for this yet
        void blocks_MouseEnter(object sender, EventArgs e)
        {

        }

        //C
        //glitch fix
        private void sheet_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
        }

        //C
        //not planned any action for this yet
        private void sheet_MouseLeave(object sender, EventArgs e)
        {
        }

        //C
        //
        /// <summary>
        /// defines type of block according to ind group lists maintained by add/delete operation
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        int typeOfBlock(int ind)
        {
            if (answerBlocks.Contains(ind))
                return 1;
            else if (regBlocks.Contains(ind))
                return 2;
            else if (emptyBlocks.Contains(ind))
                return 3;
            else if (imgBlocks.Contains(ind))
                return 4;
            else
                return 0;
        }

        //C
        //
        /// <summary>
        /// Return absolute index position undisturbed by moving mouse
        /// </summary>
        /// <param name="crsr"></param>
        /// <param name="inflation"></param>
        /// <returns></returns>
        int indexByPosition(Point crsr, int inflation)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < sheet.Controls.Count; i++)
            {
                Rectangle rect = blocks[i].Bounds;
                rect.Inflate(-inflation, -inflation);
                if (rect.Contains(crsr))
                    indices.Add(i);
            }
            if (indices.Count == 0) return -1;
            else
                return indices.Max();
        }

        //C
        //
        /// <summary>
        /// Gives size of reg block based on size of panel
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        private Size sizeOfBlock(int ind)
        {
            Size pSize = sheet.Controls[ind].Size;
            Bitmap bmp = new Bitmap(sheet.Controls[ind].BackgroundImage);
            int lineStart = 0;
            for (int i = 0; i < bmp.Width; i++)
            {
                if (bmp.GetPixel(i, 0).R < 128)
                    i = bmp.Width;
                else
                    lineStart++;
            }
            int indWid = (int)Math.Round((double)lineStart / (double)bmp.Width * (double)pSize.Width);
            int options = (int)Math.Round((double)(pSize.Width - indWid) / 16.5);
            int answers = (int)Math.Round((double)(pSize.Height) / 15.24);
            Size size = new Size(options, answers);
            return size;
        }
        private int bubblesWidthInBlock(int ind)
        {
            Bitmap bmp = new Bitmap(sheet.Controls[ind].BackgroundImage);
            int lineStart = 0;
            for (int i = 0; i < bmp.Width; i++)
            {
                if (bmp.GetPixel(i, 0).R < 128)
                    i = bmp.Width;
                else
                    lineStart++;
            }
            return lineStart;
        }
        private Size sizeOfBlock(Size sz, bool isRegBlock)
        {
            int options = (int)Math.Round((double)(sz.Width - 14) / 16.5);
            int answers = (int)Math.Round((double)(sz.Height) / 15.24);
            return new Size(options, answers);
        }

        private Image makeTextBlock(string text, int fontHeight, int lineLength)
        {
            text += ":";
            Image img = new Bitmap(1, 1);
            Graphics g2 = Graphics.FromImage(img);
            SizeF sz = g2.MeasureString(text, new Font("Arial", (int)Math.Round(fontHeight * drawingScale)));
            img = new Bitmap((int)Math.Round(sz.Width + lineLength * drawingScale), (int)Math.Round(sz.Height));
            g2 = Graphics.FromImage(img);
            g2.Clear(Color.White);
            g2.DrawString(text, new Font("ARIAL", (int)Math.Round(drawingScale * fontHeight)), Brushes.Black, new PointF(0, 0));
            return img;
        }
        private Image makeRegBlock(int digits)
        {
            return makeBubbleSheet(0, 10, digits, '0', 1);
        }

        //C
        //
        /// <summary>
        /// Makes new bubble sheet according to size of panel given
        /// </summary>
        /// <param name="panelSize"></param>
        /// <returns></returns>
        private Image makeBubbleSheet(Size panelSize, int excludeIndex, bool isForExclusion)
        {
            Size sizeOfAnsBlock = sizeOfBlock(panelSize, false);
            int i = 1;
            foreach (int ind in answerBlocks)
            {
                if (ind < excludeIndex)
                    i += sizeOfBlock(ind).Height;
            }
            return makeBubbleSheet((isForExclusion ? i : excludeIndex), sizeOfAnsBlock.Width, sizeOfAnsBlock.Height, optCharCB.SelectedItem.ToString()[0], 1);
        }
        //C
        //
        /// <summary>
        /// Makes new bubble sheet according to size of panel given
        /// </summary>
        /// <param name="panelSize"></param>
        /// <returns></returns>
        private Image makeBubbleSheet(Size panelSize)
        {
            Size sizeOfAnsBlock = sizeOfBlock(panelSize, false);
            int i = 1;
            foreach (int ind in answerBlocks)
            {
                i += sizeOfBlock(ind).Height;
            }
            return makeBubbleSheet(i, sizeOfAnsBlock.Width, sizeOfAnsBlock.Height, optCharCB.SelectedItem.ToString()[0], 1);
        }
        //C
        //
        /// <summary>
        /// draws image block bound to number of info.
        /// if indexing start is zero, block will be converted to reg Block
        /// </summary>
        /// <param name="indexingStart"></param>
        /// <param name="NumberOfChoices"></param>
        /// <param name="NumberOfLines"></param>
        /// <param name="OptionChar"></param>
        /// <param name="Scale"></param>
        /// <returns></returns>
        private Image makeBubbleSheet(int indexingStart, int NumberOfChoices, int NumberOfLines, char OptionChar, double Scale)
        {
            int indBlockXSpacing = 5, indBlockWid = 0, circleSize = 100, spacing = 50, lineWidth = 2;
            Font labelFont = new Font("Arial", (circleSize * 50) / 100);
            Font indexingFont = new Font("Arial", (circleSize * 50) / 70);
            Image tBmp = (Image)new Bitmap(1, 1);
            Graphics g2 = Graphics.FromImage(tBmp);
            int maxWid = 0;
            if (indexingStart > 0)
            {
                for (int i = 0; i < NumberOfLines; i++)
                {
                    int tw = (int)g2.MeasureString((i + indexingStart).ToString(), indexingFont).Width;
                    if (tw > maxWid)
                        maxWid = tw;
                }
            }
            indBlockWid = maxWid + indBlockXSpacing;


            tBmp = new Bitmap(indBlockWid + NumberOfChoices * (circleSize + spacing) + spacing, NumberOfLines * (circleSize + spacing) + spacing);
            g2 = Graphics.FromImage(tBmp);
            g2.Clear(Color.White);

            g2.DrawRectangle(new Pen(Brushes.Black, lineWidth * 2), new Rectangle(indBlockWid, 0, tBmp.Width - indBlockWid, tBmp.Height));

            //Only used in case of boxes
            int boxWid = (int)Math.Round((double)(tBmp.Width - indBlockWid) / NumberOfChoices);
            double lineToMargin = 0.6;
            int lineMargin = (int)Math.Round(boxWid * (1 - lineToMargin)) / 2;
            int boxHei = (int)Math.Round((double)tBmp.Height / NumberOfLines);
            int lineHei = (int)Math.Round(boxHei * lineToMargin);

            for (int j = 0; j < NumberOfLines; j++)
            {
                if (boxesRB.Checked && j < NumberOfLines - 1)
                {
                    g2.DrawLine(new Pen(Brushes.Black, lineWidth), indBlockWid + 1, boxHei * (j + 1), tBmp.Width - 1, boxHei * (j + 1));
                }
                for (int i = 0; i < NumberOfChoices; i++)
                {
                    if (circlesRB.Checked)
                    {
                        g2.DrawEllipse(new Pen(Brushes.Black, lineWidth),
                            new Rectangle(indBlockWid + (circleSize + spacing) * i + spacing, (circleSize + spacing) * j + spacing, circleSize, circleSize));
                        if (OptionChar != 0 && OptionChar != 'N')
                        {
                            string num = ((char)(OptionChar + i)).ToString();
                            int numX = (circleSize - (int)g2.MeasureString(num, labelFont).Width) / 2;
                            Point numLoc = new Point(indBlockWid + (circleSize + spacing) * i + spacing + numX, (circleSize + spacing) * j + spacing + numX);
                            if (OptionChar == 'a' || OptionChar == '1' || OptionChar == '0')
                                numLoc = new Point(numLoc.X, numLoc.Y - circleSize / 15);
                            g2.DrawString(num, labelFont, Brushes.Black, numLoc);
                        }
                    }
                    else 
                    {
                        if (i < NumberOfChoices - 1)
                        {
                            g2.DrawLine(new Pen(Brushes.Black, lineWidth),
                                new PointF(indBlockWid + (i + 1) * boxWid, boxHei * j + lineMargin),
                                new PointF(indBlockWid + (i + 1) * boxWid, boxHei * j + lineMargin + lineHei));
                        }
                        if (OptionChar != 0 && OptionChar != 'N')
                        {
                            string num = ((char)(OptionChar + i)).ToString();
                            Size numSz = g2.MeasureString(num, labelFont).ToSize();

                            Point numLoc = new Point(indBlockWid + (boxWid - numSz.Width) / 2 + boxWid * i, boxHei * j + (boxHei - numSz.Height) / 2);

                            g2.DrawString(num, labelFont, Brushes.Black, numLoc);
                        }
                    }
                }
                if (indexingStart > 0)
                {
                    string ansNum = (indexingStart + j).ToString();
                    int length = (int)g2.MeasureString(ansNum, indexingFont).Width;
                    int indX = indBlockWid - length - indBlockXSpacing;
                    int indTextY = ((circleSize + spacing) - indexingFont.Height) / 2;
                    g2.DrawString(ansNum, indexingFont, Brushes.Black, new Point(indX, indTextY + (circleSize + spacing) * j + spacing / 2));
                }
            }


           
            return tBmp;
        }

        private void deleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you realy want to delete the block? this cannot be undone.", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                sheet.Controls.RemoveAt(indexForDeletion);
                blocks.RemoveAt(indexForDeletion);

                int tobforDeletion = typeOfBlock(indexForDeletion);

                answerBlocks.Remove(indexForDeletion);
                regBlocks.Remove(indexForDeletion);
                emptyBlocks.Remove(indexForDeletion);

                for (int j = 0; j < answerBlocks.Count; j++)
                {
                    if (answerBlocks[j] > indexForDeletion)
                        answerBlocks[j]--;
                }
                for (int j = 0; j < regBlocks.Count; j++)
                {
                    if (regBlocks[j] > indexForDeletion)
                        regBlocks[j]--;
                }
                for (int j = 0; j < emptyBlocks.Count; j++)
                {
                    if (emptyBlocks[j] > indexForDeletion)
                        emptyBlocks[j]--;
                }
                if (tobforDeletion == 1)
                {
                    refreshAnswerBlocks();
                }
            }
        }
        private void refreshAnswerBlocks()
        {
            Size lastSz = new Size(5, 1);
            foreach (int i in answerBlocks)
            {
                blocks[i].BackgroundImage = makeBubbleSheet(blocks[i].Size, lastSz.Height, false);
                lastSz = new Size(5, lastSz.Height + sizeOfBlock(i).Height);
            }
        }
        private void blockContextStrip_Opening(object sender, CancelEventArgs e)
        {
            
            string typeOB = "";
            if (typeOfBlock(indexForDeletion) == 1)
                typeOB = "Bubbles Block";
            else if (typeOfBlock(indexForDeletion) == 2)
                typeOB = "Number Block";
            else if (typeOfBlock(indexForDeletion) == 3)
                typeOB = "Written input Block";
            deleteMI.Text = "Delete " + typeOB;
        }

        private void resterize_Click(object sender, EventArgs e)
        {
            if (continueWithSave())
            {
                if (!File.Exists(dbAddressTB.Text))
                    File.Copy("omrSheetEmpty.accdb", dbAddressTB.Text);
                initiateSheetSaveProcedure();
                sheet.Enabled = false;
                allControls.Enabled = false;
            }
            else
            {
                MessageBox.Show("Can't proceed with the file save. There are errors with file name/sheet name/write permissions etc. Kindly fix these errors before continuing with the save.");
            }
        }

        private void answerKeyDesigner_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                File.Delete("tempPdfSave.bmp");
            }
            catch { }
        }

        private bool nameIsValid(string str)
        {
            System.CodeDom.Compiler.CodeDomProvider provider = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("C#");
            return provider.IsValidIdentifier(str);
        }
        private bool continueWithSave()
        {
            if (nameIsValid(sheetNameTB.Text) && dbAddressTB.Text != "")
            {
                if (!File.Exists(dbAddressTB.Text))
                {
                    MessageBox.Show("A new file will be created.");
                    return true;
                }
                else if (((DataSet)OMR.helpers.dbOps.rawSelectCommand("SELECT sheetName FROM sheets WHERE sheetName = \"" + sheetNameTB.Text + "\";", dbAddressTB.Text)).Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Sheet name already exists. Try another file or delete the entry first.");
                }
                else if (nameIsValid(sheetNameTB.Text))
                {
                    help.Text = "Sheet name is valid";
                    return true;
                }
            }
            else MessageBox.Show("Enter a valid text");
            return false;
        }
        private void checkNameB_Click(object sender, EventArgs e)
        {
            if (continueWithSave())
            {
                MessageBox.Show("Everything looks fine with the name and files.");
            }
            else
            {
                MessageBox.Show("Can't proceed with the file save");
            }
        }

        private void dbBrowseB_Click(object sender, EventArgs e)
        {
            if (saveDB.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                dbAddressTB.Text = saveDB.FileName;
            
        }

        private void initiateSheetSaveProcedure()
        {
            progressStatus.Visible = true;
            help.Text = "Sheet creation started.";
            Application.DoEvents();

            help.Text = "Rendering High Resolution Background.";
            Application.DoEvents();
            try
            {
                g.Flush();
            }
            catch { }
            g.Dispose();
            redrawSheetImage(true);
            g.Flush();
            g.Dispose();
            progressStatus.Value = 10;
            sheet.Invalidate();
            Application.DoEvents();

            help.Text = "Creating new sheet and writing parameters.";

            dbOps.newSheet(sheetNameTB.Text, dbAddressTB.Text);

            progressStatus.Value += 5;
            Application.DoEvents();

            int margin = 175;
            double omrImgScale = 0.15;
            dbOps.saveProperty(Enums.sheetProperties.SheetBounds, new Size(
                (int)Math.Round(omrImgScale * ((int)Math.Round(sheet.Width * drawingScale) - margin * 2)),
                (int)Math.Round(omrImgScale * ((int)Math.Round(sheet.Height * drawingScale) - margin * 2))),
                sheetNameTB.Text, dbAddressTB.Text, typeof(Size));

            double bSizeTol = .68;
            double tempRatio = 23700.6 / (double)(sheet.BackgroundImage.Width * sheet.BackgroundImage.Height) * (1 + bSizeTol);
            dbOps.saveProperty(Enums.sheetProperties.maxBlobSizeRatio,
                tempRatio,
                sheetNameTB.Text, dbAddressTB.Text, typeof(double));

            dbOps.saveProperty(Enums.sheetProperties.minBlobSizeRatio,
                23700.6 / (double)(sheet.BackgroundImage.Width * sheet.BackgroundImage.Height) * (1 - bSizeTol),
                sheetNameTB.Text, dbAddressTB.Text, typeof(double));

            help.Text = "Saving blocks information.";
            Application.DoEvents();
            int pLeft = 100 - progressStatus.Value;
            int answerBlockInd = 0, regBlockInd = 0, emptyBlockInd = 0, answerBlockNumbering = 1;
            for (int i = 0; i < blocks.Count; i++)
            {
                switch (typeOfBlock(i))
                {
                    case 1:
                        int emptyWidth = bubblesWidthInBlock(i);
                        var ansBlock = new sheetObjectTypes.answerBlock()
                        {
                            BlockID = answerBlockInd,
                            NumberOfLines = sizeOfBlock(i).Height,
                            Options = sizeOfBlock(i).Width,
                            StartOfInd = answerBlockNumbering,
                            gRectangle = new RectangleF(
                           (float)Math.Round(omrImgScale * ((float)(blocks[i].Location.X * drawingScale) - margin + emptyWidth)),
                           (float)Math.Round(omrImgScale * ((float)(blocks[i].Location.Y * drawingScale) - margin)),
                           (float)Math.Round(omrImgScale * ((float)(blocks[i].Size.Width * drawingScale) - emptyWidth)),
                           (float)Math.Round(omrImgScale * ((float)(blocks[i].Size.Height * drawingScale)))
                           )
                        };
                        answerBlockNumbering += ansBlock.NumberOfLines;
                        answerBlockInd++;

                        dbOps.saveProperty(Enums.sheetProperties.AnswerBlock, ansBlock, sheetNameTB.Text, dbAddressTB.Text, typeof(sheetObjectTypes.answerBlock));
                        break;
                    case 2:
                        var regBlock = new sheetObjectTypes.numberBlock()
                        {
                            BlockID = answerBlockInd,
                            Digits = sizeOfBlock(i).Height,
                            gRectangle = new RectangleF(
                               (float)Math.Round(omrImgScale * ((float)(blocks[i].Location.X * drawingScale) - margin)),
                               (float)Math.Round(omrImgScale * ((float)(blocks[i].Location.Y * drawingScale) - margin)),
                               (float)Math.Round(omrImgScale * ((float)(blocks[i].Size.Width * drawingScale))),
                               (float)Math.Round(omrImgScale * ((float)(blocks[i].Size.Height * drawingScale)))
                           )
                        };
                        regBlockInd++;
                        dbOps.saveProperty(Enums.sheetProperties.NumberBlock, regBlock, sheetNameTB.Text, dbAddressTB.Text, typeof(sheetObjectTypes.numberBlock));
                        break;
                    case 3:
                        var emptyBlock = new sheetObjectTypes.emptyBlock()
                        {
                            BlockID = answerBlockInd,
                            gRectangle = new RectangleF(
                                (float)Math.Round(omrImgScale * ((float)(blocks[i].Location.X * drawingScale) - margin)),
                                (float)Math.Round(omrImgScale * ((float)(blocks[i].Location.Y * drawingScale) - margin)),
                                (float)Math.Round(omrImgScale * ((float)(blocks[i].Size.Width * drawingScale))),
                                (float)Math.Round(omrImgScale * ((float)(blocks[i].Size.Height * drawingScale)))
                            )
                        };
                        emptyBlockInd++;
                        dbOps.saveProperty(Enums.sheetProperties.EmptyBlock, emptyBlock, sheetNameTB.Text, dbAddressTB.Text, typeof(sheetObjectTypes.emptyBlock));
                        break;
                }
                progressStatus.Value += (pLeft - 30) / blocks.Count;
                Application.DoEvents();
            }
            help.Text = "Rendering Final Image.";
            Application.DoEvents();
            g = Graphics.FromImage(sheet.BackgroundImage);
            pLeft = 100 - progressStatus.Value;
            for (int i = 0; i < blocks.Count; i++)
            {
                if (typeOfBlock(i) != 3)
                    g.DrawImage(blocks[i].BackgroundImage, changeScale(blocks[i].Bounds, drawingScale));
                else // no need to save image
                    ;

                progressStatus.Value += (pLeft - 20) / blocks.Count;
                Application.DoEvents();
            }
            string file = Path.Combine(Path.GetDirectoryName(dbAddressTB.Text), sheetNameTB.Text);

            string imgFile = file + " Image.jpg";
            string pdfFile = file + " Printable.pdf";

            if (File.Exists(file))
                File.Delete(file);


            sheet.BackgroundImage.Save(imgFile, System.Drawing.Imaging.ImageFormat.Jpeg);
            progressStatus.Value++;
            if (SystemUtils.checkGS())
            {
                help.Text = "Rendering PDF File.";
                Application.DoEvents();
                double wi = 21, hi = 29.7;
                if (sheet.BackgroundImage.Height < sheet.BackgroundImage.Width)
                { wi = 29.7; hi = 21; }
                helpers.imgToPdf.toPDF(imgFile, pdfFile, wi, hi);

                help.Text = "Sheet saved successfully.";
            }
            else
                help.Text = "Sheet saved successfully. PDF Creation was aborted.";
            progressStatus.Visible = false;
            Application.DoEvents();
        }
        Rectangle changeScale(Rectangle rect, double scale)
        {
            return new Rectangle(
                (int)Math.Round(rect.X * scale),
                (int)Math.Round(rect.Y * scale),
                (int)Math.Round(rect.Width * scale),
                (int)Math.Round(rect.Height * scale));

        }
        private void optCharCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshAnswerBlocks();
        }

        private void circlesRB_CheckedChanged(object sender, EventArgs e)
        {
            if (circlesRB.Checked)
            {
                if (MessageBox.Show(this, "Boxes are recomended for better OMR reading. Do you want to revert back?", "Recomendation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    boxesRB.Checked = true;
                else
                { refreshAnswerBlocks(); }
            }
            else
            { refreshAnswerBlocks(); }
        }


    }
}
