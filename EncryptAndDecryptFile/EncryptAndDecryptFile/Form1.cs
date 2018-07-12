using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptAndDecryptFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Chọn tập tin cần mã hóa";
            dialog.Filter = "Text files|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string file_path = dialog.FileName;
                file_path = new FileInfo(file_path).FullName;

                txt_url.Text = file_path;
                txt_url_encrypt.Text = Path.GetDirectoryName(file_path) + @"\ciphertext.dat";
                txt_url_decrypt.Text = Path.GetDirectoryName(file_path) + @"\deciphered.txt";

                txtPlaintextFile.Text = File.ReadAllText(file_path);
            }
        }

        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            CryptoStuff.EncryptFile(txt_pass.Text, txt_url.Text, txt_url_encrypt.Text);


            txtCiphertextFile.Text = File.ReadAllBytes(txt_url_encrypt.Text).ToHex(' ');
        }

        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            CryptoStuff.DecryptFile(txt_pass.Text, txt_url_encrypt.Text, txt_url_decrypt.Text);

            // Display the result.
            txtDecipheredFile.Text = File.ReadAllText(txt_url_decrypt.Text);
        }
    }
}
