namespace EncryptionFlow
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGoEncrypt = new System.Windows.Forms.Button();
            this.btnGoDecrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGoEncrypt
            // 
            this.btnGoEncrypt.FlatAppearance.BorderSize = 0;
            this.btnGoEncrypt.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoEncrypt.Location = new System.Drawing.Point(24, 35);
            this.btnGoEncrypt.Name = "btnGoEncrypt";
            this.btnGoEncrypt.Size = new System.Drawing.Size(235, 79);
            this.btnGoEncrypt.TabIndex = 0;
            this.btnGoEncrypt.Text = "Encrypt Folder";
            this.btnGoEncrypt.UseVisualStyleBackColor = true;
            this.btnGoEncrypt.Click += new System.EventHandler(this.btnGoEncrypt_Click);
            // 
            // btnGoDecrypt
            // 
            this.btnGoDecrypt.FlatAppearance.BorderSize = 0;
            this.btnGoDecrypt.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoDecrypt.Location = new System.Drawing.Point(285, 35);
            this.btnGoDecrypt.Name = "btnGoDecrypt";
            this.btnGoDecrypt.Size = new System.Drawing.Size(236, 79);
            this.btnGoDecrypt.TabIndex = 0;
            this.btnGoDecrypt.Text = "Decrypt Folder";
            this.btnGoDecrypt.UseVisualStyleBackColor = true;
            this.btnGoDecrypt.Click += new System.EventHandler(this.btnGoDecrypt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(533, 145);
            this.Controls.Add(this.btnGoDecrypt);
            this.Controls.Add(this.btnGoEncrypt);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "EncryiptionFlow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGoEncrypt;
        private System.Windows.Forms.Button btnGoDecrypt;
    }
}

