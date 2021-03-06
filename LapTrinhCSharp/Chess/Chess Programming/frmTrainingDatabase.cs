using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Chess_Usercontrol;

namespace Chess_Programming
{
    public partial class frmTrainingDatabase : DevComponents.DotNetBar.Office2007Form
    {
        public frmTrainingDatabase()
        {
            InitializeComponent();
            this.btnSelect.Visible = false;
        }
        public static clsTrainingExercise exe = null;
        public frmTrainingDatabase(bool EnableSelect)
        {
            InitializeComponent();
            this.btnSelect.Visible = true;
        }

        private void frmTrainingDatabase_Load(object sender, EventArgs e)
        {
            cboType.SelectedIndex = 0;
            lblWhoMove.Text = "";
            try
            {
                dataGridViewX1.DataSource = clsTrainingDatabase.GetDataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        clsOptions obj = new clsOptions();
        private void btnPreview_Click(object sender, EventArgs e)
        {
            PreviewFEN(textBoxX1.Text);
        }

        private void btnPreview_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxX1.Clear();
            textBoxX1.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn Chưa Chọn Loại !!!");
                return;
            }

            if (PreviewFEN(textBoxX1.Text) == true)
            {
                clsTrainingExercise data = new clsTrainingExercise();

                data.ExerciseName = cboType.SelectedItem.ToString();
                data.FEN = textBoxX1.Text;

                if (cboType.SelectedIndex == 0)
                    data.MaxMoves = 10000;
                else
                    data.MaxMoves = cboType.SelectedIndex;

                DataTable tbl = clsTrainingDatabase.AddData(data);

                if (tbl != null)
                {
                    dataGridViewX1.DataSource = tbl;
                    MessageBox.Show("Thêm Thành Công !!!");
                }
            }


        }

        bool PreviewFEN(string strFEN)
        {
            try
            {
                int size = 45;
                string s = strFEN.Split(' ')[1];
                if (s.ToUpper() == "W")
                    lblWhoMove.Text = "Quân Trắng Đi Trước";
                else
                    lblWhoMove.Text = " Quân Đen Đi Trước";

                UcChessBoard board = new UcChessBoard(obj.BoardStyle, obj.PieceStyle, ChessSide.White, GameMode.VsNetWorkPlayer, size, size, false, strFEN);
                Bitmap bmp = board.TakePicture(size * 8, size * 8);
                pictureBox1.Image = bmp;
                board.Dispose();
                return true;
            }
            catch
            {
                MessageBox.Show("Dữ Liệu Không Phù Hợp !!!");
                return false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            int index = dataGridViewX1.SelectedRows[0].Index;

            if (index == -1)
            {
                MessageBox.Show("Bạn Chưa Chọn Dòng Cần Xóa !!!");
                return;
            }
            if (dataGridViewX1.RowCount == 1)
            {
                MessageBox.Show("Bạn Không Được Xóa Khi Chỉ Còn 1 Dòng !!!");
                return;
            }
            DataGridViewRow r = dataGridViewX1.SelectedRows[0];

            clsTrainingExercise data = new clsTrainingExercise();

            data.FEN = r.Cells["FEN"].Value.ToString();
            DataTable tbl = clsTrainingDatabase.DeleteData(data);

            if (tbl == null)
            {
                MessageBox.Show("Không Thể Xóa Dữ Liệu");
            }
            else
            {
                MessageBox.Show("Xóa Thành Công !!!");
                dataGridViewX1.DataSource = tbl;
            }
        }

        private void dataGridViewX1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn dòng cần copy !!!");
                return;
            }
            DataGridViewRow r = dataGridViewX1.SelectedRows[0];
            string FEN = r.Cells["FEN"].Value.ToString();
            Clipboard.SetText(FEN);
            MessageBox.Show(FEN, "Đã lưu vào ClipBoard !!!");

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn Chưa Chọn Loại !!!");
                return;
            }

            int index = dataGridViewX1.SelectedRows[0].Index;
            if (index == -1)
            {
                MessageBox.Show("Bạn Chưa Chọn Dòng Cần Cập Nhật !!!");
                return;
            }

            if (PreviewFEN(textBoxX1.Text) == true)
            {
                clsTrainingExercise data = new clsTrainingExercise();

                data.ExerciseName = cboType.SelectedItem.ToString();
                data.FEN = textBoxX1.Text;

                if (cboType.SelectedIndex == 0)
                    data.MaxMoves = 10000;
                else
                    data.MaxMoves = cboType.SelectedIndex;

                DataTable tbl = clsTrainingDatabase.UpdateData(index, data);
                if (tbl != null)
                {
                    dataGridViewX1.DataSource = tbl;
                    MessageBox.Show("Cập Nhật Thành Công !!!");
                }
                else
                {
                    MessageBox.Show("Không Thể Cập Nhật !!!");
                }
            }
        }

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewX1.SelectedRows.Count == 0)
                return;
            DataGridViewRow r = dataGridViewX1.SelectedRows[0];
            string FEN = r.Cells["FEN"].Value.ToString();
            textBoxX1.Text = FEN;
            cboType.Text = r.Cells["Name"].Value.ToString();
            PreviewFEN(FEN);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

            int index = dataGridViewX1.SelectedRows[0].Index;

            if (index == -1)
            {
                MessageBox.Show("Bạn Chưa Chọn Dòng Nào Cả !!!");
                return;
            }

            DataGridViewRow r = dataGridViewX1.SelectedRows[0];

            exe = new clsTrainingExercise();

            exe.FEN = r.Cells["FEN"].Value.ToString();
            exe.ExerciseName  = r.Cells["Name"].Value.ToString();
            exe.MaxMoves = Convert .ToInt32 ( r.Cells["Moves"].Value);

            this.Close();

        }

        private void chụpẢnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;

            clsImage img = new clsImage(pictureBox1.Image, 240,240);

            Clipboard.SetImage(img.Avatar);
            MessageBox.Show("Đã lưu vào Clipboard");
        }

        private void lưuẢnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.png|*.PNG";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(dlg.FileName+".png"); 
            }
        }


       


    }
}