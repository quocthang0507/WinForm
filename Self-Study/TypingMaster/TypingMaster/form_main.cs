using System;
using System.Windows.Forms;

namespace TypingMaster
{
	public partial class form_main : Form
	{
		private User user;
		private string text;
		private int index = 0;
		private char current;
		int sec = 0;

		public form_main(User user)
		{
			this.user = user;
			InitializeComponent();
		}

		private void form_main_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult quit = MessageBox.Show("Do you want to quit this game?", "Prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (quit == DialogResult.Yes)
				Environment.Exit(1);
		}

		private void load_Text()
		{
			text = TypingMaster.Properties.Resources.String1;
			rtbx_text.Text = text;
			current = text[index];
			rtbx_text.Select(index, 1);
		}

		private void form_main_Load(object sender, EventArgs e)
		{
			stt_username.Text = user.Name;
			load_Text();
		}

		private void rtbx_text_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (current == e.KeyChar)
			{
				if (index == 0)
					timer.Start();
				if (index <= text.Length - 1)
				{
					if (index == text.Length - 1)
					{
						timer.Stop();
						MessageBox.Show(string.Format("Succesfully, Your speed is {0} wpm", Math.Round(speed(), 2), "Result", MessageBoxButtons.OK, MessageBoxIcon.Information));
					}
					else
					{
						index++;
						current = text[index];
						rtbx_text.Select(index, 1);
					}
				}
			}
		}

		private int count_words()
		{
			int wordCount = 0, index = 0;
			while (index < text.Length)
			{
				while (index < text.Length && !char.IsWhiteSpace(text[index]))
					index++;
				wordCount++;
				while (index < text.Length && char.IsWhiteSpace(text[index]))
					index++;
			}
			return wordCount;
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			sec++;
		}

		private double speed()
		{
			return ((double)sec / count_words()) * 60;
		}
	}
}
