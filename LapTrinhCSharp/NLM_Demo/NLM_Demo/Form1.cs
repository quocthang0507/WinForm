using DevExpress.XtraEditors;
using NETWORKLIST;
using System;
using System.Windows.Forms;

namespace NLM_Demo
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        CheckerInternetHelper helper;
        public Form1()
        {
            InitializeComponent();
            helper = new CheckerInternetHelper(this);
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {            
            label2.Text = "Mất kết nối mạng Internet!";
            IEnumNetworks Networks = helper.NLM.GetNetworks(NLM_ENUM_NETWORK.NLM_ENUM_NETWORK_CONNECTED);
            foreach (INetwork item in Networks)
            {
                label2.Text = "Đang kết nối mạng:" + item.GetName();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            helper.UnAdviseforNetworklistManager();
        }

        public void CountDownloadHidePopup()
        {
            timer1.Enabled = true;
        }

        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 10)
            {
                flyoutPanel1.HidePopup();
                i = 0;
                timer1.Enabled = false;
            }
        }

        private void btn_dangky_Click(object sender, EventArgs e)
        {
            helper.AdviseforNetworklistManager();
            XtraMessageBox.Show("Đã đăng ký kiểm tra kết nối mạng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_huydangky_Click(object sender, EventArgs e)
        {
            helper.UnAdviseforNetworklistManager();
            XtraMessageBox.Show("Đã hủy đăng ký kiểm tra kết nối mạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
