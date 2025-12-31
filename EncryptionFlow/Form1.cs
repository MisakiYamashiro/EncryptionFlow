using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptionFlow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Flow Technologies Secured Vault";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        private void btnGoEncrypt_Click(object sender, EventArgs e)
        {
            EncryptForm frm = new EncryptForm();
            frm.ShowDialog(); 
        }

        private void btnGoDecrypt_Click(object sender, EventArgs e)
        {
            DecryptionForm frm = new DecryptionForm();
            frm.ShowDialog();
        }
    }
}
