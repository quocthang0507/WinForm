using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;

namespace FakeIP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_get_Click(object sender, EventArgs e)
        {
            try
            {
                HttpRequest httpRequest = new HttpRequest();
                httpRequest.Cookies = new CookieDictionary();
                httpRequest.UserAgent = Http.ChromeUserAgent();
                httpRequest.Proxy = Socks5ProxyClient.Parse(txt_sock5.Text.Trim());
                string html = httpRequest.Get(txt_website.Text.Trim()).ToString();
                webBrowser1.DocumentText = html;
               

            }
            catch (Exception ex)
            {
                webBrowser1.DocumentText = ex.Message;
            }
        }
    }
}
