/*
 * Copyright (c) YinYang 2011
 * http://yinyangit.wordpress.com
 */ 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Y2_MineLand
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            this.Text = Application.ProductName + " " + Application.ProductVersion;
            
            NewGame();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }
        private void NewGame()
        {
            minesBoard1.NewGame();
            RenewForm();
        }
        private void NewGame(int rows,int cols,int mines)
        {
            minesBoard1.NewGame(rows,cols,mines);
            RenewForm();
        }
        private void RenewForm()
        {           
            button1.BackgroundImage = Properties.Resources.face1;
            this.Height = minesBoard1.Height + 100;
            this.Width = minesBoard1.Width + 20;
            UpdateMines();
        }
        void UpdateMines()
        {
            lblMines.Text = String.Format("{0:000}",minesBoard1.MinesCount - minesBoard1.FlagsCount);
            if (minesBoard1.RemainCellsCount == minesBoard1.MinesCount)
                button1.BackgroundImage = Properties.Resources.face4;
        }
        void CheckMenuItem(ToolStripMenuItem menuItem)
        {
            foreach (var item in gameToolStripMenuItem1.DropDownItems)
            {
                ToolStripMenuItem mi = item as ToolStripMenuItem;
                if(mi!=null)
                    mi.Checked= false;
            }
            menuItem.Checked = true;
        }

        private void beginnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame(9, 9, 10);
            CheckMenuItem(sender as ToolStripMenuItem);            
        }

        private void intermediateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame(16, 16, 40);
            CheckMenuItem(sender as ToolStripMenuItem);            
        }

        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame(25, 40, 200);
            CheckMenuItem(sender as ToolStripMenuItem);            
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomForm frm = new CustomForm(minesBoard1.Rows,minesBoard1.Cols,minesBoard1.MinesCount);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                NewGame(frm.Rows, frm.Cols, frm.Mines);
            }
            CheckMenuItem(sender as ToolStripMenuItem);  
            
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = minesBoard1.MaskColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                minesBoard1.MaskColor=dlg.Color;
            }
        }

        private void minesBoard1_MinesExplode(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.face3;
        }

        private void minesBoard1_CellClick(object sender, EventArgs e)
        {
            UpdateMines();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://yinyangit.wordpress.com");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void minesBoard1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void minesBoard1_MouseUp(object sender, MouseEventArgs e)
        {

        }


    }
}
