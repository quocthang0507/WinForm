using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ToggleKeys_OldMethod
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        internal static extern short GetKeyState(int keyCode);

        [DllImport("user32.dll")]        
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);        


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {          
            labelDayDate.Text = System.DateTime.Today.DayOfWeek + ", " + System.DateTime.Today.Day + "-" + System.DateTime.Today.Month + "-" + System.DateTime.Today.Year;    
            UpdateKeys();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
         
            if (e.KeyData == Keys.Insert)
            {
                UpdateInsert();
            }
            else if (e.KeyData == Keys.NumLock)
            {
                UpdateNUMLock();
            }
            else if (e.KeyData == Keys.CapsLock)
            {
                UpdateCAPSLock();
            }            
        }

        private void lblINS_DoubleClick(object sender, EventArgs e)
        {
            PressKeyboardButton(Keys.Insert);
            UpdateInsert();
        }

        private void lblNUM_DoubleClick(object sender, EventArgs e)
        {
            PressKeyboardButton(Keys.NumLock);
            UpdateNUMLock();
        }

        private void lblCAPS_DoubleClick(object sender, EventArgs e)
        {
            PressKeyboardButton(Keys.CapsLock);
            UpdateCAPSLock();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            UpdateKeys();
        }
        
       
        private void UpdateKeys()
        {
            UpdateInsert();
            UpdateNUMLock();
            UpdateCAPSLock();
        }

        
        private void UpdateInsert()
        {
            bool NumLock = (GetKeyState((int)Keys.Insert)) != 0;

            if (NumLock)
            {
                lblINS.Text = "INS";
            }
            else
            {
                lblINS.Text = "OVR";
            }

            this.Refresh();
        }

    
        private void UpdateNUMLock()
        {
            bool NumLock = (GetKeyState((int)Keys.NumLock)) != 0;

            if (NumLock)
            {
                lblNUM.Text = "NUM";
            }
            else
            {
                lblNUM.Text = String.Empty;
            }

            this.Refresh();
        }

        private void UpdateCAPSLock()
        {
            bool CapsLock = (GetKeyState((int)Keys.CapsLock)) != 0;

            if (CapsLock)
            {
                lblCAPS.Text = "CAPS";
            }
            else
            {
                lblCAPS.Text = String.Empty;
            }

            this.Refresh();
        }

        
        private void PressKeyboardButton(Keys keyCode)
        {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;
            keybd_event((byte)keyCode, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event((byte)keyCode, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }

  

    }
}