using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace CounterLib
{
	/// <summary>
	/// Summary description for Counter.
	/// </summary>
	[DefaultProperty("Value")]
	[DefaultEvent("CounterFinish")]
	public class Counter : System.Windows.Forms.UserControl
	{
		private System.ComponentModel.Container components = null;
		private Bitmap numbersBitmap;
		private ArrayList digits;
		private int digitCount = 5;
		private long val = 0;
		private long toVal = 0;
		private Timer timer;
		private Timer animationTimer;
		private CounterAnimationSpeed animationSpeed = CounterAnimationSpeed.Normal;
		private CounterNumbersTheme numbersTheme = CounterNumbersTheme.n01;
		private int digitWidth;
		private int totalFrames;

		public event EventHandler CounterFinish;

		[Category("Appearance")]
		[Description("The value displayed in the counter. Setting this value will reset the ToValue property")]
		public long Value 
		{
			get { return val; }
			set 
			{
				if( value < 0 )
					throw new ArgumentOutOfRangeException("Value", "The value must be greater than 0");
				long precision = (long)Math.Log10((double)value);
				if( precision >= DigitCount )
					throw new ArgumentOutOfRangeException("Value", "Value to is to big to fit in " + DigitCount.ToString() + " digits. Modify the numer of digits then retry");
				val = value;
				toVal = value;
				SetDigits();
				Refresh(); 
			}
		}

		[Category("Appearance")]
		[Description("The value towards the counter will increment/decrement")]
		public long ToValue
		{
			get { return toVal; }
			set 
			{
				if( value < 0 )
					throw new ArgumentOutOfRangeException("ToValue", "The value must be greater than 0");
				long precision = (long)Math.Log10((double)value);
				if( precision >= DigitCount )
					throw new ArgumentOutOfRangeException("ToValue", "Value to is to big to fit in " + DigitCount.ToString() + " digits. Modify the numer of digits then retry");
				toVal = value; 
			}
		}

		[DefaultValue(5)]
		[Category("Appearance")]
		[Description("The number of digits displayed")]
		public int DigitCount 
		{
			get { return digitCount; }
			set 
			{
				if( value < 1 || value > 18 )
					throw new ArgumentOutOfRangeException("DigitCount", "Value must be between 1 and 18");
				digitCount = value; 
				CreateDigits();
				SetDigits();
				Width = DigitCount * digitWidth;
				Refresh();
			}
		}

		[DefaultValue(1000)]
		[Category("Appearance")]
		[Description("The increment / decrement interval ")]
		public int TimerInterval 
		{
			get { return timer.Interval; }
			set 
			{
				if( value <= 0 )
					throw new ArgumentOutOfRangeException("TimerInterval ", "Value must be greater than 0"); 
				timer.Interval = value; 
			}
		}
	
		[DefaultValue(CounterAnimationSpeed.Normal)]
		[Category("Appearance")]
		[Description("The speed for animating the digits")]
		public CounterAnimationSpeed AnimationSpeed 
		{
			get { return animationSpeed; }
			set 
			{
				animationSpeed = value;
				if( animationSpeed == CounterAnimationSpeed.NoAnimation )
					animationTimer.Enabled = false;
				else 
				{
					animationTimer.Enabled = true;
					animationTimer.Interval = timer.Interval / (int)animationSpeed;
				}
			}
		}

		[DefaultValue(CounterNumbersTheme.n01)]
		[Category("Appearance")]
		[Description("The appearance of the digits")]
		public CounterNumbersTheme NumbersTheme 
		{
			get { return numbersTheme; }
			set 
			{
				numbersTheme = value; 
				ReadNumbersBitmap();
				Refresh();
			}
		}

		[Category("Behavior")]
		[Description("The counter will increment/decrement only if enabled")]
		public new bool Enabled 
		{
			get { return base.Enabled; }
			set 
			{
				base.Enabled = value; 
				animationTimer.Enabled = value;
				timer.Enabled = value;
			}
		}

		public Counter()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			ReadNumbersBitmap();

			timer = new Timer();
			timer.Enabled = true;
			timer.Interval = 1000;
			timer.Tick += new EventHandler(timer_Tick);

			animationTimer = new Timer();
			animationTimer.Enabled = true;
			animationTimer.Interval = timer.Interval / (int)animationSpeed;
			animationTimer.Tick += new EventHandler(animationTimer_Tick);
		}

		public void OnCounterFinish(EventArgs e) 
		{
			if( null != CounterFinish)
				CounterFinish(this, e);
		}
		
		private void timer_Tick(object source, EventArgs e)
		{
			if( Value == ToValue ) return;

			if( Value < ToValue )
				Increment();
			else
				Decrement();

			if( Value == ToValue )
				OnCounterFinish(new EventArgs());
		}

		private void animationTimer_Tick(object source, EventArgs e)
		{
			for(int i=0; i!=DigitCount; i++) 
			{
				CounterDigit cd = digits[i] as CounterDigit;
				cd.NextFrame();
			}
			Invalidate();
		}

		private void Increment() 
		{
			++val;
			SetDigits();
		}

		private void Decrement() 
		{
			--val;
			SetDigits();
		}

		private void CreateDigits() 
		{
			if( null != digits) 
			{
				for(int i=0; i!=digits.Count; i++) 
				{
					CounterDigit cd = digits[i] as CounterDigit;
					if( null != cd )
						cd.Dispose();
				}
				digits.Clear();
				digits = null;
			}
			digits = new ArrayList(DigitCount);
			for(int i=0; i!=DigitCount; i++) 
			{
				digits.Add(new CounterDigit(numbersBitmap));
			}
		}

		private void ReadNumbersBitmap() 
		{
			if( null != numbersBitmap )
				numbersBitmap.Dispose();
			Stream s = this.GetType().Assembly.GetManifestResourceStream("CounterLib." + numbersTheme.ToString().PadLeft(2, '0') + ".gif");
			try 
			{
				numbersBitmap = new Bitmap(s);
			}
			finally 
			{
				s.Close();
			}
			digitWidth = numbersBitmap.Width / 10;
			totalFrames = numbersBitmap.Height;
			Height = numbersBitmap.Height;
			Width = DigitCount * digitWidth;
			CreateDigits();
			SetDigits();
		}
	
		private void SetDigits() 
		{
			int[] newDig = GetDigits(val);
			for(int i=0; i!=DigitCount; i++) 
			{
				CounterDigit cd = digits[i] as CounterDigit;
				cd.Digit = newDig[i];
				if( cd.PrevDigit != newDig[i] ) 
				{
					if( animationSpeed == 0)
						cd.Frame = totalFrames;
					else
						cd.Frame = 0;
				}
			}
			Invalidate();
		}

		private int[] GetDigits(long val) 
		{
			long p = (long)Math.Pow(10, DigitCount-1);
			int[] dig = new int[DigitCount];
			long v = val;
			for(int i=0; i!=DigitCount; i++) 
			{
				long d = v / p;
				if( v > 0 ) 
				{
					v = v - p * d;
					dig[i] = (int)d;
				}
				p /= 10;
			}
			return dig;
		}

		protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
		{
			try 
			{
				for(int i=0; i!=DigitCount; i++) 
				{
					e.Graphics.DrawImage((digits[i] as CounterDigit).DigitBitmap, i * digitWidth, 0);
				}
			} 
			catch {}
		}

		protected override void OnResize(System.EventArgs e)
		{
			if( null != numbersBitmap )
				Height = numbersBitmap.Height;
			Width = DigitCount * digitWidth;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( null != numbersBitmap )
					numbersBitmap.Dispose();
				if( null != timer )
					timer.Dispose();
				if( null != animationTimer )
					animationTimer.Dispose();
				if( null != digits) 
				{
					for(int i=0; i!=digits.Count; i++) 
					{
						(digits[i] as CounterDigit).Dispose();
					}
					digits.Clear();
					digits = null;
				}
				if( null != components )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// Counter
			// 
			this.Name = "Counter";
			this.Size = new System.Drawing.Size(344, 56);

		}
		#endregion

	}

	/// <summary>
	/// 
	/// </summary>
	public class CounterDigit : IDisposable
	{
		private int digit;//0-9
		private int frame;
		private int prevDigit;
		private Bitmap numbersBitmap;
		private Bitmap framedDigitBitmap;
		private int width;
		private int height;
		private int frames;

		public int Digit 
		{
			get { return digit; }
			set 
			{
				prevDigit = digit;
				digit = value; 
			}
		}

		public int PrevDigit 
		{
			get { return prevDigit; }
		}

		public int Frame 
		{
			get { return frame; }
			set { frame = value; }
		}

		public CounterDigit(Bitmap numbersBitmap) 
		{
			width = numbersBitmap.Width / 10;
			height = numbersBitmap.Height;
			frames = height;
			framedDigitBitmap = new Bitmap(width, height);
			this.numbersBitmap = numbersBitmap;
			frame = frames;
			digit = 0;
			prevDigit = 0;
		}

		/// <summary>
		/// Moves to the next frame
		/// </summary>
		/// <returns>True if overflow ocured</returns>
		public void NextFrame() 
		{
			if( Frame < frames) 
			{
				Frame ++;
			}
		}

		/// <summary>
		/// Moves to the previous frame
		/// </summary>
		/// <returns>True if overflow ocured</returns>
		public void PrevFrame() 
		{
			if( Frame > 0) 
			{
				Frame --;
			}
		}

		public Bitmap DigitBitmap 
		{
			get 
			{
				Graphics g = Graphics.FromImage(framedDigitBitmap);
				try 
				{
					g.DrawImage(numbersBitmap, 0, 0, new Rectangle(Digit * width, frames - Frame, width, frames), GraphicsUnit.Pixel);
					g.DrawImage(numbersBitmap, 0, Frame, new Rectangle( PrevDigit * width, 0, width, frames - Frame + 2), GraphicsUnit.Pixel);
				}
				finally 
				{
					g.Dispose();
				}
				return framedDigitBitmap;
			}
		}

		public void Dispose() 
		{
			framedDigitBitmap.Dispose();
		}
	}

	public enum CounterAnimationSpeed 
	{
		NoAnimation = 0,
		Slow = 40,
		Normal = 60,
		Fast = 100
	}

	public enum CounterNumbersTheme
	{
		n01 = 1,
		n02 = 2,
		n03 = 3,
		n04 = 4,
		n05 = 5,
		n06 = 6,
		n07 = 7,
		n08 = 8,
		n09 = 9,
		n10 = 10,
		n11 = 11,
		n12 = 12,
		n13 = 13,
	}
}
