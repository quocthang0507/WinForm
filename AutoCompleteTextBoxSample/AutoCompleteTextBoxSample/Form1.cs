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
            List<string> source = new List<string>();        
            StreamReader stream = new StreamReader("en-EN.dic");           
            string line = stream.ReadLine();         
            while (line != null)
            {               
                source.Add(line);               
                line = stream.ReadLine();
            }            
            stream.Close();
            stream.Dispose();            
            this.autoCompleteTextbox1.AutoCompleteList = source;
        }

        #endregion Methods
    }
}