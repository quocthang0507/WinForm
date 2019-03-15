using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypingMaster
{
	public partial class form_welcome : Form
	{
		public form_welcome()
		{
			InitializeComponent();
		}

		private void btn_quit_Click(object sender, EventArgs e)
		{
			DialogResult quit = MessageBox.Show("Do you want to quit this game?", "Prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (quit == DialogResult.Yes)
				Environment.Exit(1);
		}

		private void btn_start_Click(object sender, EventArgs e)
		{
			string name, gender;
			int age;
			name = tbx_name.Text;
			age = (int)nud_age.Value;
			gender = cbx_gender.Text;
			if (name == "" || age == 0 || gender == "")
				MessageBox.Show("Please fill in all blanks");
			else
			{
				User user = new User(name, age, gender);
				this.Hide();
				Form main = new form_main(user);
				main.Show();
			}
		}
	}
}
