using NETWORKLIST;
using System;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;


namespace NLM_Demo
{
    class CheckerInternetHelper: INetworkListManagerEvents
    {
        private int m_cookie = 0;
        private IConnectionPoint m_icp;
        private INetworkListManager m_nlm;
        private Form1 frm;

        public CheckerInternetHelper(Form1 frm)
        {
            m_nlm = new NetworkListManager();
            this.frm = frm;
        }

        public void SetText(string message, Color color, Color color2)
        {
            frm.label1.BeginInvoke(new Action(() => {
                frm.label1.Text = message;
                frm.label1.ForeColor = color;
                frm.label1.BackColor = color2;
                frm.flyoutPanel1.ShowPopup();
                frm.CountDownloadHidePopup();
            }));
        }

        public void ConnectivityChanged(NLM_CONNECTIVITY newConnectivity)
        {
            if (newConnectivity == NLM_CONNECTIVITY.NLM_CONNECTIVITY_DISCONNECTED)
            {
                SetText("Đã ngắt kết nối internet!", Color.White, Color.Red);
            }
            if (((int)newConnectivity & (int)NLM_CONNECTIVITY.NLM_CONNECTIVITY_IPV4_INTERNET) != 0)
            {              
                SetText("Đang kết nối thành công Internet với IPv4!", Color.White, Color.Green);
            }
            if (((int)newConnectivity & (int)NLM_CONNECTIVITY.NLM_CONNECTIVITY_IPV6_INTERNET) != 0)
            {
                SetText("Đang kết nối thành công Internet với IPv6!", Color.White, Color.Green);
            }
            if ((((int)newConnectivity & (int)NLM_CONNECTIVITY.NLM_CONNECTIVITY_IPV4_INTERNET) == 0)
                && (((int)newConnectivity & (int)NLM_CONNECTIVITY.NLM_CONNECTIVITY_IPV6_INTERNET) == 0))
            {
                SetText("Mất kết nối Internet!", Color.White, Color.Red);
            }
        }

        public INetworkListManager NLM
        {
            get
            {
                return m_nlm;
            }
        }

        public void AdviseforNetworklistManager()
        {            
            IConnectionPointContainer icpc = (IConnectionPointContainer)m_nlm;
            Guid tempGuid = typeof(INetworkListManagerEvents).GUID;
            icpc.FindConnectionPoint(ref tempGuid, out m_icp);
            m_icp.Advise(this, out m_cookie);
        }

        public void UnAdviseforNetworklistManager()
        {          
            m_icp.Unadvise(m_cookie);
        }
    }
}
