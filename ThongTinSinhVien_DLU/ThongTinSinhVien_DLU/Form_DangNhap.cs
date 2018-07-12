using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThongTinSinhVien_DLU
{
    public partial class Form_DangNhap : Form
    {
        public string mssv = "";
        public Form_DangNhap()
        {
            InitializeComponent();
        }

        public class CookieAwareWebClient : WebClient
        {
            private int? _timeout = null;
            public int? Timeout { get { return _timeout; } set { _timeout = value; } }
            public CookieContainer CookieContainer { get; private set; }
            public CookieCollection ResponseCookies { get; set; }
            public CookieAwareWebClient() { CookieContainer = new CookieContainer(); this.ResponseCookies = new CookieCollection(); }
            public CookieAwareWebClient(CookieContainer cookies) { this.CookieContainer = cookies; }
            public void SetTimeout(int timeout) { _timeout = timeout; }
            protected override WebRequest GetWebRequest(Uri address)
            {
                var request = (HttpWebRequest)base.GetWebRequest(address);
                request.CookieContainer = CookieContainer;
                if (_timeout.HasValue) { request.Timeout = _timeout.Value; }
                return request;
            }
        }


    }
}
