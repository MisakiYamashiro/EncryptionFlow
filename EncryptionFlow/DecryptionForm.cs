using EncryptionFlow.FolderLockerApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptionFlow
{
    public partial class DecryptionForm : Form
    {
        public DecryptionForm()
        {
            InitializeComponent();
            this.Text = "Decrypt Mode";
            this.StartPosition = FormStartPosition.CenterParent;
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please select a folder and enter a password.");
                return;
            }

            try
            {
                string[] files = Directory.GetFiles(txtPath.Text, "*.locked", SearchOption.AllDirectories);

                if (files.Length == 0)
                {
                    MessageBox.Show("No locked files found in this folder.");
                    return;
                }

                progressBar1.Maximum = files.Length;
                progressBar1.Value = 0;

                foreach (string file in files)
                {
                    CryptoEngine.FileDecrypt(file, txtPassword.Text);
                    progressBar1.Value++;
                }

                MessageBox.Show("Decryption Complete! Folder is unlocked.");
                this.Close();
            }
            catch (CryptographicException)
            {
                MessageBox.Show("Wrong Password! Cannot decrypt files.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
