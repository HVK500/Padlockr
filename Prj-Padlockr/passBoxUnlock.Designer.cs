﻿namespace Prj_Padlockr
{
    partial class passBoxUnlock
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
            this.btnUnlock = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.lblMpass = new System.Windows.Forms.Label();
            this.picLock = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLock)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUnlock
            // 
            this.btnUnlock.Location = new System.Drawing.Point(112, 82);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(178, 23);
            this.btnUnlock.TabIndex = 0;
            this.btnUnlock.TabStop = false;
            this.btnUnlock.Text = "Unlock";
            this.btnUnlock.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(296, 82);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(112, 50);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.PasswordChar = '*';
            this.maskedTextBox1.Size = new System.Drawing.Size(261, 20);
            this.maskedTextBox1.TabIndex = 1;
            // 
            // lblMpass
            // 
            this.lblMpass.AutoSize = true;
            this.lblMpass.Location = new System.Drawing.Point(112, 34);
            this.lblMpass.Name = "lblMpass";
            this.lblMpass.Size = new System.Drawing.Size(140, 13);
            this.lblMpass.TabIndex = 2;
            this.lblMpass.Text = "Enter your master password:";
            // 
            // picLock
            // 
            this.picLock.Image = global::Prj_Padlockr.Properties.Resources.Lock;
            this.picLock.InitialImage = null;
            this.picLock.Location = new System.Drawing.Point(-13, 12);
            this.picLock.Name = "picLock";
            this.picLock.Size = new System.Drawing.Size(119, 107);
            this.picLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLock.TabIndex = 3;
            this.picLock.TabStop = false;
            // 
            // passBoxUnlock
            // 
            this.AcceptButton = this.btnUnlock;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(383, 132);
            this.Controls.Add(this.picLock);
            this.Controls.Add(this.lblMpass);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUnlock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "passBoxUnlock";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter Master Password";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.picLock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label lblMpass;
        private System.Windows.Forms.PictureBox picLock;
    }
}