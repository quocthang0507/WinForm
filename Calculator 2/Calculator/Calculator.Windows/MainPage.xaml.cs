using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		double num1 = 0, num2 = 0;
		double result = 0;
		char opr;
		string temp = "0";
		int flag = 0;
		public MainPage()
		{
			this.InitializeComponent();
		}

		private void btn0_Click(object sender, RoutedEventArgs e)
		{
			tbxDisplay.Text += "0";
			temp += "0";
		}

		private void btn1_Click(object sender, RoutedEventArgs e)
		{
			tbxDisplay.Text += "1";
			temp += "1";
		}

		private void btn2_Click(object sender, RoutedEventArgs e)
		{
			tbxDisplay.Text += "2";
			temp += "2";
		}

		private void btn3_Click(object sender, RoutedEventArgs e)
		{
			tbxDisplay.Text += "3";
			temp += "3";
		}

		private void btn4_Click(object sender, RoutedEventArgs e)
		{
			tbxDisplay.Text += "4";
			temp += "4";
		}

		private void btn5_Click(object sender, RoutedEventArgs e)
		{
			tbxDisplay.Text += "5";
			temp += "5";
		}

		private void btn6_Click(object sender, RoutedEventArgs e)
		{
			tbxDisplay.Text += "6";
			temp += "6";
		}

		private void btn7_Click(object sender, RoutedEventArgs e)
		{
			tbxDisplay.Text += "7";
			temp += "7";
		}

		private void btn8_Click(object sender, RoutedEventArgs e)
		{
			tbxDisplay.Text += "8";
			temp += "8";
		}

		private void btn9_Click(object sender, RoutedEventArgs e)
		{
			tbxDisplay.Text += "9";
			temp += "9";
		}

		private void btnDel_Click(object sender, RoutedEventArgs e)
		{
			tbxDisplay.Text = "";
			temp = "0";
			tbxResult.Text = "";
			flag = 0;
			num1 = 0; num2 = 0;
		}

		private void btnADD_Click(object sender, RoutedEventArgs e)
		{
			flag++;
			if (flag > 1)
			{
				btnCalc_Click(sender, e);
				num1 = double.Parse(tbxResult.Text);
				tbxResult.Text = "";
				if (opr != '+')
					tbxDisplay.Text = num1.ToString();
			}
			else
			{
				num1 = double.Parse(temp);
			}
			tbxDisplay.Text += " + ";
			opr = '+';
			temp = "";
		}

		private void btnSUB_Click(object sender, RoutedEventArgs e)
		{
			flag++;
			if (flag > 1)
			{
				btnCalc_Click(sender, e);
				num1 = double.Parse(tbxResult.Text);
				tbxResult.Text = "";
				if (opr != '-')
					tbxDisplay.Text = num1.ToString();
			}
			else
			{
				num1 = double.Parse(temp);
			}
			tbxDisplay.Text += " - ";
			opr = '-';
			temp = "";
		}

		private void btnMUL_Click(object sender, RoutedEventArgs e)
		{
			flag++;
			if (flag > 1)
			{
				btnCalc_Click(sender, e);
				num1 = double.Parse(tbxResult.Text);
				tbxResult.Text = "";
				if (opr != '*')
					tbxDisplay.Text = num1.ToString();
			}
			else
			{
				num1 = double.Parse(temp);
			}
			tbxDisplay.Text += " * ";
			opr = '*';
			temp = "";
		}

		private void btnDIV_Click(object sender, RoutedEventArgs e)
		{
			flag++;
			if (flag > 1)
			{
				btnCalc_Click(sender, e);
				num1 = double.Parse(tbxResult.Text);
				tbxResult.Text = "";
				if (opr != '/')
					tbxDisplay.Text = num1.ToString();
			}
			else
			{
				num1 = double.Parse(temp);
			}
			tbxDisplay.Text += " / ";
			opr = '/';
			temp = "";
		}
		private void Calc(double num1, double num2, char opr)
		{
			switch (opr)
			{
				case '+':
					result = num1 + num2;
					tbxResult.Text = result.ToString();
					break;
				case '-':
					result = num1 - num2;
					tbxResult.Text = result.ToString();
					break;
				case '*':
					result = num1 * num2;
					tbxResult.Text = result.ToString();
					break;
				case '/':
					if (num2 == 0)
					{
						tbxResult.Text = "Error! Can't divide by zero";
					}
					else
					{
						result = num1 / num2;
						tbxResult.Text = result.ToString();
					}
					break;
				default:
					break;
			}
		}

		private void btnCalc_Click(object sender, RoutedEventArgs e)
		{
			double.TryParse(temp, out num2);
			Calc(num1, num2, opr);
		}
	}
}