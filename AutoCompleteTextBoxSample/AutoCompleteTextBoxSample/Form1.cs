namespace AutoCompleteTextBoxSample
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        #region Constructors

        public Form1()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void Form1_Load(object sender, EventArgs e)
        {          
            var source = new List<string>();        
            StreamReader strem = new StreamReader("en-EN.dic");           
            string line = strem.ReadLine();         
            while (line != null)
            {               
                source.Add(line);               
                line = strem.ReadLine();
            }            
            strem.Close();
            strem.Dispose();            
            this.autoCompleteTextbox1.AutoCompleteList = source;
        }

        #endregion Methods
    }
}