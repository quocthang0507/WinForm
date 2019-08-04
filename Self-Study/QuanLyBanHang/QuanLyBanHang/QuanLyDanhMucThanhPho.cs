using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class QuanLyDanhMucThanhPho : Form
    {
        string strConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QuanLyBanHang;Integrated Security=True;";
        SqlConnection conn = null;
        SqlDataAdapter daThanhPho = null;
        DataTable dtThanhPho = null;
        bool Them;

        public QuanLyDanhMucThanhPho()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                conn = new SqlConnection(strConnectionString);
                daThanhPho = new SqlDataAdapter("Select * from ThanhPho", conn);
                dtThanhPho = new DataTable();
                dtThanhPho.Clear();
                daThanhPho.Fill(dtThanhPho);
                dgv_ThanhPho.DataSource = dtThanhPho;
                dgv_ThanhPho.AutoResizeColumns();
                this.tbx_ThanhPho.ResetText();
                this.tbx_TenThanhPho.ResetText();
                this.btn_Luu.Enabled = false;
                this.btn_HuyBo.Enabled = false;
                this.panel1.Enabled = false;
                this.btn_Them.Enabled = true;
                this.btn_Sua.Enabled = true;
                this.btn_Xoa.Enabled = true;
                this.btn_TroVe.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Không lấy được nội dung trong table thành phố", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void QuanLyDanhMucThanhPho_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void QuanLyDanhMucThanhPho_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtThanhPho.Dispose();
            dtThanhPho = null;
            conn = null;
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_TroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            Them = true;
            this.tbx_ThanhPho.ResetText();
            this.tbx_TenThanhPho.ResetText();
            this.btn_Luu.Enabled = true;
            this.btn_HuyBo.Enabled = true;
            this.panel1.Enabled = true;
            this.btn_Them.Enabled = false;
            this.btn_Sua.Enabled = false;
            this.btn_Xoa.Enabled = false;
            this.btn_TroVe.Enabled = false;
            this.tbx_ThanhPho.Focus();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            Them = false;
            this.panel1.Enabled = true;
            int r = dgv_ThanhPho.CurrentCell.RowIndex;
            this.tbx_ThanhPho.Text = dgv_ThanhPho.Rows[r].Cells[0].Value.ToString();
            this.tbx_TenThanhPho.Text = dgv_ThanhPho.Rows[r].Cells[1].Value.ToString();
            this.btn_Luu.Enabled = true;
            this.btn_HuyBo.Enabled = true;
            this.btn_Them.Enabled = false;
            this.btn_Sua.Enabled = false;
            this.btn_Xoa.Enabled = false;
            this.btn_TroVe.Enabled = false;
            this.tbx_ThanhPho.Focus();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                int r = dgv_ThanhPho.CurrentCell.RowIndex;
                string strThanhPho = dgv_ThanhPho.Rows[r].Cells[0].Value.ToString();
                cmd.CommandText = System.String.Concat("Delete from ThanhPho where ThanhPho='" + strThanhPho + "'");
                cmd.ExecuteNonQuery();
                LoadData();
                MessageBox.Show("Thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xuất hiện khi thực hiện lệnh xoá", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            conn.Close();
        }

        private void btn_HuyBo_Click(object sender, EventArgs e)
        {
            tbx_ThanhPho.ResetText();
            tbx_TenThanhPho.ResetText();
            this.btn_Them.Enabled = true;
            this.btn_Sua.Enabled = true;
            this.btn_Xoa.Enabled = true;
            this.btn_TroVe.Enabled = true;
            this.btn_Luu.Enabled = false;
            this.btn_HuyBo.Enabled = false;
            this.panel1.Enabled = false;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (Them)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = System.String.Concat("Insert into ThanhPho values ('" + this.tbx_ThanhPho.Text + "','" + tbx_TenThanhPho.Text + "')");
                    cmd.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Đã thêm");
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi xuất hiện khi thực hiện lệnh thêm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                int r = dgv_ThanhPho.CurrentCell.RowIndex;
                string strThanhPho = dgv_ThanhPho.Rows[r].Cells[0].Value.ToString();
                cmd.CommandText = System.String.Concat("Update ThanhPho set TenThanhPho='" + tbx_TenThanhPho.Text + "' where ThanhPho='" + tbx_ThanhPho.Text + "'");
                cmd.ExecuteNonQuery();
                LoadData();
                MessageBox.Show("Đã sửa");
                conn.Close();
            }
        }
    }
}
