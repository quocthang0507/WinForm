using SimpleWifi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manager_Wifi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private Wifi wifi;
        private IEnumerable<AccessPoint> List()
        {
            IEnumerable<AccessPoint> accessPoints = wifi.GetAccessPoints().OrderByDescending(ap => ap.SignalStrength);
            return accessPoints;
        }
        IEnumerable<AccessPoint> accessPoints;
        private void btn_findwifi_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            accessPoints = List();
            int i = 1;
            foreach (AccessPoint ap in accessPoints)
            {
                var tinhtrang = "chưa kết nối.";
                if (ap.IsConnected) { tinhtrang = "Đang kết nối."; }
                ListViewItem item = new ListViewItem(new string[] { (i++).ToString(), ap.Name, ap.SignalStrength.ToString() + "%", tinhtrang });
                listView1.Items.AddRange(new ListViewItem[] { item });
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wifi = new Wifi();
            wifi.ConnectionStatusChanged += wifi_ConnectionStatusChanged;
            Status();
            btn_findwifi_Click(sender, e);
        }

        private void Status()
        {
            if (wifi.ConnectionStatus == WifiStatus.Connected)
            {
                var accessPoints = List();
                foreach (AccessPoint ap in accessPoints)
                {
                    if (ap.IsConnected)
                    {
                        lbl_status.BeginInvoke(new Action(() =>
                        {
                            lbl_status.Text = "Bạn đang kết nối với wifi tên " + ap.Name;
                        }));

                        return;
                    }
                }


            }
            else
            {
                lbl_status.BeginInvoke(new Action(() =>
                {
                    lbl_status.Text = "Bạn chưa có kết nối đến mạng wifi.";
                }));
            }

        }
        private void wifi_ConnectionStatusChanged(object sender, WifiStatusEventArgs e)
        {
            lbl_status.BeginInvoke(new Action(() =>
            {
                lbl_status.Text = e.NewStatus.ToString();
            }));

        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            wifi.Disconnect();
            Status();

        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            var index = listView1.FocusedItem.Index;
            AccessPoint selectedAP = accessPoints.ToList()[index];

            // Auth
            AuthRequest authRequest = new AuthRequest(selectedAP);

            if (authRequest.IsPasswordRequired)
            {
                authRequest.Password = EnterPassword(selectedAP, txt_password.Text);
            }

            selectedAP.ConnectAsync(authRequest, true, OnConnectedComplete);
        }

        private string EnterPassword(AccessPoint selectedAP, string password)
        {

            bool validPassFormat = false;

            while (!validPassFormat)
            {

                validPassFormat = selectedAP.IsValidPassword(password);

                if (!validPassFormat)
                {
                    MessageBox.Show("Mật khẩu không chính xác!");
                    break;
                }

            }

            return password;
        }

        private void OnConnectedComplete(bool success)
        {
            Status();
        }

        private void ShowInfo(int selectedIndex)
        {


            if (selectedIndex > accessPoints.ToArray().Length || accessPoints.ToArray().Length == 0)
            {
                Console.Write("\r\nIndex out of bounds");
                return;
            }
            AccessPoint selectedAP = accessPoints.ToList()[selectedIndex];

            richTextBox1.Text = selectedAP.ToString();
        }



        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

            ShowInfo(e.ItemIndex);
        }
    }
}

