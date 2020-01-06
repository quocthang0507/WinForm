using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScanSubnet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdScan_Click(object sender, EventArgs e)
        {
            string subnet = txtIP.Text;
            Ping myPing;
            PingReply reply;
            IPAddress addr;
            IPHostEntry host;

            progressBar1.Maximum = 254;
            progressBar1.Value = 0;
            listVAddr.Items.Clear();


            Parallel.For(2, 255, (i) =>
            {

                Task.Factory.StartNew(new Action(() => {

                    string subnetn = "." + i.ToString();
                    myPing = new Ping();
                    reply = myPing.Send(subnet + subnetn, 300);
                    if (reply.Status == IPStatus.Success)
                    {
                        progressBar1.BeginInvoke(new Action(() => {

                            try
                            {
                                addr = IPAddress.Parse(subnet + subnetn);
                                host = Dns.GetHostEntry(addr);

                                listVAddr.Items.Add(new ListViewItem(new String[] { subnet + subnetn, host.HostName, "Up" }));
                            }
                            catch { MessageBox.Show("Couldnt retrieve hostname for " + subnet + subnetn, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                            progressBar1.Value += 1;
                            lblStatus.ForeColor = System.Drawing.Color.Green;
                            lblStatus.Text = "Scanning: " + subnet + subnetn;
                            Debug.WriteLine("Scanning: " + subnet + subnetn);
                            if (progressBar1.Value == 253)
                            {
                                cmdScan.Enabled = true;
                                cmdStop.Enabled = false;
                                txtIP.Enabled = true;
                                lblStatus.Text = "Done!";                              
                            }
                        }));

                    }
                    else
                    {
                        progressBar1.BeginInvoke(new Action(() => {
                            progressBar1.Value += 1;
                            lblStatus.ForeColor = Color.Green;
                            lblStatus.Text = "Scanning: " + subnet + subnetn;
                            Debug.WriteLine("Scanning: " + subnet + subnetn);
                           
                            //listVAddr.Items.Add(new ListViewItem(new String[] { subnet + subnetn, "", "Down" }));
                            if (progressBar1.Value == 253)
                            {
                                cmdScan.Enabled = true;
                                cmdStop.Enabled = false;
                                txtIP.Enabled = true;
                                lblStatus.Text = "Done!";                              
                            }
                        }));
                    }

                }));

            });
        }
    }
}
