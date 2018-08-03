using System;
using System.Windows.Forms;

namespace ChuongTrinhThiTracNghiem
{
    public partial class Form_Welcome : Form
    {
        bool isSuccess = false;

        public Form_Welcome()
        {
            InitializeComponent();
        }

        private void tbx_ThoiGian_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
                e.Handled = false;
            else
            {
                e.Handled = true;
                return;
            }
        }

        private void Form_Welcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isSuccess)
                Application.Exit();
        }

        private void btn_Thi_Click(object sender, EventArgs e)
        {
            if (tbx_Ten.Text == "")
            {
                MessageBox.Show("Họ tên không được để trống");
                return;
            }
            else if (tbx_ThoiGian.Text == "")
            {
                MessageBox.Show("Thời gian không được để trống, mặc định sẽ là 40 phút");
                tbx_ThoiGian.Text = "40";
            }
            isSuccess = true;
            this.Hide();
        }
    }
}
