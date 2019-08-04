using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertIP
{
	public partial class Form1 : Form
	{
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

		string[] split(string ip)
		{
			return ip.Split('.');
		}

		bool CheckValidIP(string ip)
		{
			if (ip.Count(x => x == '.') < 3 || ip.Count(x => x == '.') > 3)
				return false;
			else
			{
				string[] t = split(ip);
				foreach (var item in t)
					if (int.Parse(item) > 255 || int.Parse(item) < 0)
						return false;
			}
			return true;
		}

		bool CheckSubnetMask(int n)
		{
			return n <= 32 && n >= 0;
		}

		private void txtIP_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 46 || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
				e.Handled = false;
			else e.Handled = true;
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
					if (!CheckValidIP(txtIP.Text))
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

		string DecStr2BinStr(string s)
		{
			string[] t = split(s);
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

		private void btnConvert_Click(object sender, EventArgs e)
		{
			if (txtIP.Text != "" && txtSubnet.Text != "")
			{
				string s = DecStr2BinStr(txtIP.Text);
				string s_network = s.Substring(0, int.Parse(txtSubnet.Text));
				string s_host = s.Substring(int.Parse(txtSubnet.Text));
				string s_host_network = s_host.Replace('1', '0');
				string s_host_broadcast = s_host.Replace('0', '1');
				txtNetwork.Text = BinStr2DecStr(s_network + s_host_network);
				txtBroadcast.Text = BinStr2DecStr(s_network + s_host_broadcast);
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
	}
}
