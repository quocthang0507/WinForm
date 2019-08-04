using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication1
{
	public partial class Form1 : Form
	{
		public static string n = "";

		public Form1()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (this.txtSoDia.Text == "" || this.cboNhanDia1.Text == "" || this.cboNhanDia2.Text == "" || this.cboNhanDia3.Text == "")
				MessageBox.Show("Bạn chưa nhập đủ thông tin!");
			else
			{
				int soDia = int.Parse(this.txtSoDia.Text);
				int soBuoc = 0;
				ThapHN(ref soBuoc, soDia, this.cboNhanDia1.Text, this.cboNhanDia2.Text, cboNhanDia3.Text);
				this.txtTongBuoc.Text = soBuoc.ToString();
			}
		}
		private void ThapHN(ref int soBuoc, int Sodia, string from, string inter, string to)
		{

			if (Sodia == 1)
			{
				listBox_FieldList.Items.Add("Đĩa 1 từ cọc " + from + " đến cọc " + to);
				soBuoc = soBuoc + 1;
			}
			else
			{
				ThapHN(ref soBuoc, Sodia - 1, from, to, inter);
				listBox_FieldList.Items.Add("Đĩa " + Sodia.ToString() + " từ cọc " + from + " đến cọc " + to);
				soBuoc = soBuoc + 1;
				ThapHN(ref soBuoc, Sodia - 1, inter, from, to);
			}
		}

		private void btXoaDuLieuChayLai_Click(object sender, EventArgs e)
		{
			this.txtSoDia.Text = "";
			this.cboNhanDia1.Text = "";
			this.cboNhanDia2.Text = "";
			this.cboNhanDia3.Text = "";
			this.listBox_FieldList.Items.Clear();
			this.txtTongBuoc.Text = null;
		}

		private void txtTongBuoc_TextChanged(object sender, EventArgs e)
		{

		}

		private void cboNhanDia1_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		private void cboNhanDia2_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void cboNhanDia3_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
