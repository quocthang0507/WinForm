using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CounterLib;

namespace CounterDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBoxValue;
		private System.Windows.Forms.Button buttonValue;
		private System.Windows.Forms.TextBox textBoxToValue;
		private System.Windows.Forms.Button buttonToValue;
		private System.Windows.Forms.ComboBox comboBoxDigits;
		private System.Windows.Forms.ComboBox comboBoxAppearance;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxTimerInterval;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBoxAnimationSpeed;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button buttonTimerInterval;
		private System.Windows.Forms.Button buttonAnimationSpeed;
		private System.Windows.Forms.Button buttonDigits;
		private System.Windows.Forms.Button buttonAppearance;
		private System.Windows.Forms.Button buttonEnabled;
		private System.Windows.Forms.CheckBox checkBoxEnabled;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button buttonExit;
		private CounterLib.Counter counter1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.buttonValue = new System.Windows.Forms.Button();
            this.textBoxToValue = new System.Windows.Forms.TextBox();
            this.buttonToValue = new System.Windows.Forms.Button();
            this.comboBoxDigits = new System.Windows.Forms.ComboBox();
            this.comboBoxAppearance = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTimerInterval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxAnimationSpeed = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonTimerInterval = new System.Windows.Forms.Button();
            this.buttonAnimationSpeed = new System.Windows.Forms.Button();
            this.buttonDigits = new System.Windows.Forms.Button();
            this.buttonAppearance = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonEnabled = new System.Windows.Forms.Button();
            this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.counter1 = new CounterLib.Counter();
            this.SuspendLayout();
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(112, 56);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(120, 20);
            this.textBoxValue.TabIndex = 2;
            this.textBoxValue.Text = "0";
            // 
            // buttonValue
            // 
            this.buttonValue.Location = new System.Drawing.Point(248, 56);
            this.buttonValue.Name = "buttonValue";
            this.buttonValue.Size = new System.Drawing.Size(75, 23);
            this.buttonValue.TabIndex = 3;
            this.buttonValue.Text = "Set";
            this.buttonValue.Click += new System.EventHandler(this.buttonValue_Click);
            // 
            // textBoxToValue
            // 
            this.textBoxToValue.Location = new System.Drawing.Point(112, 88);
            this.textBoxToValue.Name = "textBoxToValue";
            this.textBoxToValue.Size = new System.Drawing.Size(120, 20);
            this.textBoxToValue.TabIndex = 5;
            this.textBoxToValue.Text = "10";
            // 
            // buttonToValue
            // 
            this.buttonToValue.Location = new System.Drawing.Point(248, 88);
            this.buttonToValue.Name = "buttonToValue";
            this.buttonToValue.Size = new System.Drawing.Size(75, 23);
            this.buttonToValue.TabIndex = 6;
            this.buttonToValue.Text = "Set";
            this.buttonToValue.Click += new System.EventHandler(this.buttonToValue_Click);
            // 
            // comboBoxDigits
            // 
            this.comboBoxDigits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDigits.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18"});
            this.comboBoxDigits.Location = new System.Drawing.Point(112, 120);
            this.comboBoxDigits.Name = "comboBoxDigits";
            this.comboBoxDigits.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDigits.TabIndex = 8;
            // 
            // comboBoxAppearance
            // 
            this.comboBoxAppearance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAppearance.Items.AddRange(new object[] {
            "n01",
            "n02",
            "n03",
            "n04",
            "n05",
            "n06",
            "n07",
            "n08",
            "n09",
            "n10",
            "n11",
            "n12",
            "n13"});
            this.comboBoxAppearance.Location = new System.Drawing.Point(112, 152);
            this.comboBoxAppearance.Name = "comboBoxAppearance";
            this.comboBoxAppearance.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAppearance.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Digits";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Appearance";
            // 
            // textBoxTimerInterval
            // 
            this.textBoxTimerInterval.Location = new System.Drawing.Point(112, 184);
            this.textBoxTimerInterval.Name = "textBoxTimerInterval";
            this.textBoxTimerInterval.Size = new System.Drawing.Size(120, 20);
            this.textBoxTimerInterval.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Timer interval";
            // 
            // comboBoxAnimationSpeed
            // 
            this.comboBoxAnimationSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAnimationSpeed.Items.AddRange(new object[] {
            "NoAnimation",
            "Slow",
            "Normal",
            "Fast"});
            this.comboBoxAnimationSpeed.Location = new System.Drawing.Point(112, 216);
            this.comboBoxAnimationSpeed.Name = "comboBoxAnimationSpeed";
            this.comboBoxAnimationSpeed.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAnimationSpeed.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 16;
            this.label4.Text = "Animation speed";
            // 
            // buttonTimerInterval
            // 
            this.buttonTimerInterval.Location = new System.Drawing.Point(248, 184);
            this.buttonTimerInterval.Name = "buttonTimerInterval";
            this.buttonTimerInterval.Size = new System.Drawing.Size(75, 23);
            this.buttonTimerInterval.TabIndex = 15;
            this.buttonTimerInterval.Text = "Set";
            this.buttonTimerInterval.Click += new System.EventHandler(this.buttonTimerInterval_Click);
            // 
            // buttonAnimationSpeed
            // 
            this.buttonAnimationSpeed.Location = new System.Drawing.Point(248, 216);
            this.buttonAnimationSpeed.Name = "buttonAnimationSpeed";
            this.buttonAnimationSpeed.Size = new System.Drawing.Size(75, 23);
            this.buttonAnimationSpeed.TabIndex = 18;
            this.buttonAnimationSpeed.Text = "Set";
            this.buttonAnimationSpeed.Click += new System.EventHandler(this.buttonAnimationSpeed_Click);
            // 
            // buttonDigits
            // 
            this.buttonDigits.Location = new System.Drawing.Point(248, 120);
            this.buttonDigits.Name = "buttonDigits";
            this.buttonDigits.Size = new System.Drawing.Size(75, 23);
            this.buttonDigits.TabIndex = 9;
            this.buttonDigits.Text = "Set";
            this.buttonDigits.Click += new System.EventHandler(this.buttonDigits_Click);
            // 
            // buttonAppearance
            // 
            this.buttonAppearance.Location = new System.Drawing.Point(248, 152);
            this.buttonAppearance.Name = "buttonAppearance";
            this.buttonAppearance.Size = new System.Drawing.Size(75, 23);
            this.buttonAppearance.TabIndex = 12;
            this.buttonAppearance.Text = "Set";
            this.buttonAppearance.Click += new System.EventHandler(this.buttonAppearance_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 1;
            this.label5.Text = "Value";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "ToValue";
            // 
            // buttonEnabled
            // 
            this.buttonEnabled.Location = new System.Drawing.Point(248, 248);
            this.buttonEnabled.Name = "buttonEnabled";
            this.buttonEnabled.Size = new System.Drawing.Size(75, 23);
            this.buttonEnabled.TabIndex = 21;
            this.buttonEnabled.Text = "Set";
            this.buttonEnabled.Click += new System.EventHandler(this.buttonEnabled_Click);
            // 
            // checkBoxEnabled
            // 
            this.checkBoxEnabled.Location = new System.Drawing.Point(112, 248);
            this.checkBoxEnabled.Name = "checkBoxEnabled";
            this.checkBoxEnabled.Size = new System.Drawing.Size(104, 24);
            this.checkBoxEnabled.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 19;
            this.label7.Text = "Enabled";
            // 
            // buttonExit
            // 
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.Location = new System.Drawing.Point(8, 280);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 22;
            this.buttonExit.Text = "Exit";
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // counter1
            // 
            this.counter1.DigitCount = 2;
            this.counter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counter1.Location = new System.Drawing.Point(350, 101);
            this.counter1.Name = "counter1";
            this.counter1.Size = new System.Drawing.Size(310, 227);
            this.counter1.TabIndex = 23;
            this.counter1.ToValue = ((long)(0));
            this.counter1.Value = ((long)(0));
            this.counter1.CounterFinish += new System.EventHandler(this.counter1_CounterFinish);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.buttonExit;
            this.ClientSize = new System.Drawing.Size(672, 482);
            this.Controls.Add(this.counter1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.checkBoxEnabled);
            this.Controls.Add(this.buttonEnabled);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonAppearance);
            this.Controls.Add(this.buttonDigits);
            this.Controls.Add(this.buttonAnimationSpeed);
            this.Controls.Add(this.buttonTimerInterval);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxAnimationSpeed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxTimerInterval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxAppearance);
            this.Controls.Add(this.comboBoxDigits);
            this.Controls.Add(this.buttonToValue);
            this.Controls.Add(this.textBoxToValue);
            this.Controls.Add(this.buttonValue);
            this.Controls.Add(this.textBoxValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Counter demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			comboBoxDigits.SelectedIndex = counter1.DigitCount - 1;
			comboBoxAppearance.SelectedIndex = (int)counter1.NumbersTheme - 1;
			checkBoxEnabled.Checked = counter1.Enabled;
			textBoxTimerInterval.Text = counter1.TimerInterval.ToString();
			textBoxValue.Text = counter1.Value.ToString();
			textBoxToValue.Text = counter1.ToValue.ToString();
			switch(counter1.AnimationSpeed) 
			{
				case CounterAnimationSpeed.NoAnimation:
					comboBoxAnimationSpeed.SelectedIndex = 0;
					break;
				case CounterAnimationSpeed.Slow:
					comboBoxAnimationSpeed.SelectedIndex = 1;
					break;
				case CounterAnimationSpeed.Normal:
					comboBoxAnimationSpeed.SelectedIndex = 2;
					break;
				case CounterAnimationSpeed.Fast:
					comboBoxAnimationSpeed.SelectedIndex = 3;
					break;
			}
		}

		private void buttonTimerInterval_Click(object sender, System.EventArgs e)
		{
			try 
			{
				counter1.TimerInterval = int.Parse(textBoxTimerInterval.Text);
			} 
			catch(Exception ex) 
			{
				MessageBox.Show(this, ex.Message);
			}
		}

		private void buttonAnimationSpeed_Click(object sender, System.EventArgs e)
		{
			try 
			{
				switch(comboBoxAnimationSpeed.SelectedIndex) 
				{
					case 0:
						counter1.AnimationSpeed = CounterAnimationSpeed.NoAnimation;
						break;
					case 1:
						counter1.AnimationSpeed = CounterAnimationSpeed.Slow;
						break;
					case 2:
						counter1.AnimationSpeed = CounterAnimationSpeed.Normal;
						break;
					case 3:
						counter1.AnimationSpeed = CounterAnimationSpeed.Fast;
						break;
				}
			} 
			catch(Exception ex) 
			{
				MessageBox.Show(this, ex.Message);
			}
		}

		private void buttonDigits_Click(object sender, System.EventArgs e)
		{
			try 
			{
				counter1.DigitCount = comboBoxDigits.SelectedIndex + 1;
			} 
			catch(Exception ex) 
			{
				MessageBox.Show(this, ex.Message);
			}
		}

		private void buttonAppearance_Click(object sender, System.EventArgs e)
		{
			try 
			{
				counter1.NumbersTheme = (CounterNumbersTheme)comboBoxAppearance.SelectedIndex + 1;
			} 
			catch(Exception ex) 
			{
				MessageBox.Show(this, ex.Message);
			}
		}

		private void buttonEnabled_Click(object sender, System.EventArgs e)
		{
			try 
			{
				counter1.Enabled = checkBoxEnabled.Checked;
			} 
			catch(Exception ex) 
			{
				MessageBox.Show(this, ex.Message);
			}		
		}

		private void buttonValue_Click(object sender, System.EventArgs e)
		{
			try 
			{
				counter1.Value = long.Parse(textBoxValue.Text);
			} 
			catch(Exception ex) 
			{
				MessageBox.Show(this, ex.Message);
			}		
		}

		private void buttonToValue_Click(object sender, System.EventArgs e)
		{
			try 
			{
				counter1.ToValue = long.Parse(textBoxToValue.Text);
			} 
			catch(Exception ex) 
			{
				MessageBox.Show(this, ex.Message);
			}		
		}

		private void buttonExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void counter1_CounterFinish(object sender, System.EventArgs e)
		{
			MessageBox.Show(this, "Finish");
		}

	}
}
