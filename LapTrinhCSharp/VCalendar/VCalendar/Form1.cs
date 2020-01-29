using Augustine.VietnameseCalendar.Core.LuniSolarCalendar;
using System;
using System.Windows.Forms;

namespace VCalendar
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			LuniSolarDate<VietnameseLocalInfoProvider> lunarDate = LuniSolarCalendar<VietnameseLocalInfoProvider>.LuniSolarDateFromSolarDate(dateTimePicker1.Value);
			label1.Text = (string.Format("{0:dd/MM/yyyy} = {1}", dateTimePicker1.Value, lunarDate.FullDayInfo));
		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{

		}
	}
}
