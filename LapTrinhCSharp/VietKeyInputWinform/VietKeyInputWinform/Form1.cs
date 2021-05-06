using Net.SourceForge.Vietpad.InputMethod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VietKeyInputWinform
{
    public partial class Form1 : Form
    {
        VietKeyHandler keyHandler;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {         
            object[] list_kieugo = Enum.GetValues(typeof(InputMethods))
                      .Cast<object>()
                      .ToArray();
            cb_kieugo.Items.AddRange(list_kieugo);
            cb_kieugo.SelectedIndex = 2;
            cb_kieugo.SelectedValueChanged += Cb_kieugo_SelectedValueChanged;

            VietKeyHandler.InputMethod = InputMethods.VNI;
            keyHandler = new VietKeyHandler(txtText);
            txtText.KeyPress += new KeyPressEventHandler(keyHandler.OnKeyPress);            
            VietKeyHandler.VietModeEnabled = true;
            VietKeyHandler.SmartMark = true;
        }

        private void Cb_kieugo_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cb_kieugo.Text.ToLower())
            {
                case "telex":
                    VietKeyHandler.InputMethod = InputMethods.Telex;
                    break;
                case "vni":
                    VietKeyHandler.InputMethod = InputMethods.VNI;
                    break;
                case "viqr":
                    VietKeyHandler.InputMethod = InputMethods.VIQR;
                    break;
            }
        }
    }
}
