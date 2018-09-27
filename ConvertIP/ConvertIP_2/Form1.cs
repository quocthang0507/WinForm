using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ConvertIP_2
{
	public partial class Form1 : Form
	{
		string ip;

		public Form1()
		{
			InitializeComponent();
		}

		int Dec2Bin(int dec)
		{
			return int.Parse(Convert.ToString(dec, 2));
		}

		int Bin2Dec(string bin)
		{
			return Convert.ToInt32(bin, 2);
		}

		bool CheckValidIP(string ip)
		{
			IPAddress ipAddress;
			if (IPAddress.TryParse(ip, out ipAddress))
				return true;
			return false;
		}

		bool CheckSubnetMask(int n)
		{
			return n <= 32 && n >= 0;
		}

		string DecStr2BinStr(string s)
		{
			string[] t = s.Split('.');
			string bin = "";
			foreach (var item in t)
				bin += Dec2Bin(int.Parse(item)).ToString("D8");
			return bin;
		}

		string BinStr2DecStr(string s)
		{
			string dec = "";
			int i = 0;
			do
			{
				dec += Bin2Dec(s.Substring(i * 8, 8)).ToString();
				if (i < 3)
					dec += ".";
				i++;
			} while (i < 4);
			return dec;
		}

		private void txtSubnet_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
				e.Handled = false;
			else e.Handled = true;
		}

		private void txtIP_Leave(object sender, EventArgs e)
		{
			if (!btnReset.Focused)
				if (txtIP.Text != "")
					if (!CheckValidIP(ip = txtIP.Text.Replace(',', '.').Replace(" ", "")))
					{
						MessageBox.Show("Invalid IP address!", "Invalid IP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						txtIP.Focus();
					}
		}

		private void txtSubnet_Leave(object sender, EventArgs e)
		{
			if (txtSubnet.Text != "")
				if (!CheckSubnetMask(int.Parse(txtSubnet.Text)))
				{
					MessageBox.Show("Invalid subnet mask!", "Invalid subnet mask", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtSubnet.Focus();
				}
		}

		string[] ConvertIt(string IP, string mask)
		{
			string[] result = new string[2];
			string s = DecStr2BinStr(IP);
			string s_network = s.Substring(0, int.Parse(mask));
			string s_host = s.Substring(int.Parse(mask));
			string s_host_network = s_host.Replace('1', '0');
			string s_host_broadcast = s_host.Replace('0', '1');
			result[0] = BinStr2DecStr(s_network + s_host_network);
			result[1] = BinStr2DecStr(s_network + s_host_broadcast);
			return result;
		}

		private void btnConvert_Click(object sender, EventArgs e)
		{
			if (txtIP.Text != "" && txtSubnet.Text != "")
			{
				string[] t = ConvertIt(ip, txtSubnet.Text);
				txtNetwork.Text = t[0];
				txtBroadcast.Text = t[1];
			}
			else if (txtIP.Text == "")
				txtIP.Focus();
			else txtSubnet.Focus();
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			txtIP.Clear();
			txtSubnet.Clear();
			txtNetwork.Clear();
			txtBroadcast.Clear();
			txtIP.Focus();
		}

		string FindFile()
		{
			OpenFileDialog open_file = new OpenFileDialog();
			open_file.InitialDirectory = Directory.GetCurrentDirectory();
			open_file.Title = "Duyệt đến tập tin";
			open_file.Filter = "Text file|*.txt";
			open_file.RestoreDirectory = true;
			DialogResult r = open_file.ShowDialog();
			if (r == DialogResult.OK)
			{
				string file_path = open_file.FileName;
				file_path = new FileInfo(file_path).FullName;
				return file_path;
			}
			else
				return null;
		}

		string FixedWidth(string s, int length)
		{
			return String.Format("{0,-" + length + "}", s);
		}

		private void btnFile_Click(object sender, EventArgs e)
		{
			string path = FindFile();
			if (path == null)
				MessageBox.Show("You haven't chosen file text yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
			{
				StreamReader sr = new StreamReader(path);
				string p2 = path.Replace(".txt", "_answered.txt");
				StreamWriter sw = new StreamWriter(p2);
				string line;
				sw.WriteLine(FixedWidth("IP_Addresses/Subnetmask", 25) + FixedWidth("Network_Addresses", 25) + FixedWidth("Broadcast_Addresses", 25));
				while ((line = sr.ReadLine()) != null)
				{
					if (line.Contains("/"))
					{
						string[] temp = line.Split('/');
						temp[0] = temp[0].Replace("\t", "");
						if (CheckValidIP(temp[0]))
						{
							string[] t = ConvertIt(temp[0], temp[1]);
							sw.WriteLine(FixedWidth(temp[0] + "/" + temp[1], 25) + FixedWidth(t[0], 25) + FixedWidth(t[1], 25));
						}
					}
				}
				sr.Close();
				sw.Close();
				Process.Start(p2);
			}
		}
	}
}
