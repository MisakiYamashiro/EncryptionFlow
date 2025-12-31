using EncryptionFlow.FolderLockerApp;
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

namespace EncryptionFlow
{
    public partial class EncryptForm : Form
    {
        public EncryptForm()
        {
            InitializeComponent();
            this.Text = "Encrypt Mode";
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

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please select a folder and enter a password.");
                return;
            }

            try
            {
                string[] files = Directory.GetFiles(txtPath.Text, "*", SearchOption.AllDirectories);
                progressBar1.Maximum = files.Length;
                progressBar1.Value = 0;

                foreach (string file in files)
                {
                    // Zaten kilitliyse (.locked) atla
                    if (file.EndsWith(".locked")) continue;

                    CryptoEngine.FileEncrypt(file, txtPassword.Text);
                    progressBar1.Value++;
                }

                MessageBox.Show("Encryption Complete! Folder is locked.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
