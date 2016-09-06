namespace Prj_Padlockr.Forms
{
    partial class PassBoxUnlock
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
            this.maskedMasterTextBox = new System.Windows.Forms.MaskedTextBox();
            this.lblMpass = new System.Windows.Forms.Label();
            this.picLock = new System.Windows.Forms.PictureBox();
            this.btnMaskWatcher = new System.Windows.Forms.Button();
            this.lblPassVal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLock)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUnlock
            // 
            this.btnUnlock.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnUnlock.Enabled = false;
            this.btnUnlock.Location = new System.Drawing.Point(112, 76);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(178, 23);
            this.btnUnlock.TabIndex = 1;
            this.btnUnlock.Text = "Unlock";
            this.btnUnlock.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(296, 76);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // maskedMasterTextBox
            // 
            this.maskedMasterTextBox.Location = new System.Drawing.Point(112, 50);
            this.maskedMasterTextBox.Name = "maskedMasterTextBox";
            this.maskedMasterTextBox.Size = new System.Drawing.Size(241, 20);
            this.maskedMasterTextBox.TabIndex = 0;
            this.maskedMasterTextBox.UseSystemPasswordChar = true;
            this.maskedMasterTextBox.TextChanged += new System.EventHandler(this.maskedMasterTextBox_TextChanged);
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
            this.picLock.Image = global::Prj_Padlockr.Properties.Resources.ImgLock;
            this.picLock.InitialImage = null;
            this.picLock.Location = new System.Drawing.Point(-13, 12);
            this.picLock.Name = "picLock";
            this.picLock.Size = new System.Drawing.Size(119, 107);
            this.picLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLock.TabIndex = 3;
            this.picLock.TabStop = false;
            // 
            // btnMaskWatcher
            // 
            this.btnMaskWatcher.Enabled = false;
            this.btnMaskWatcher.Image = global::Prj_Padlockr.Properties.Resources.ImgEye;
            this.btnMaskWatcher.Location = new System.Drawing.Point(353, 49);
            this.btnMaskWatcher.Name = "btnMaskWatcher";
            this.btnMaskWatcher.Size = new System.Drawing.Size(18, 22);
            this.btnMaskWatcher.TabIndex = 4;
            this.btnMaskWatcher.TabStop = false;
            this.btnMaskWatcher.UseVisualStyleBackColor = true;
            this.btnMaskWatcher.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMaskWatcher_MouseDown);
            this.btnMaskWatcher.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMaskWatcher_MouseUp);
            // 
            // lblPassVal
            // 
            this.lblPassVal.AutoSize = true;
            this.lblPassVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.lblPassVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPassVal.Location = new System.Drawing.Point(258, 35);
            this.lblPassVal.Name = "lblPassVal";
            this.lblPassVal.Size = new System.Drawing.Size(0, 13);
            this.lblPassVal.TabIndex = 5;
            // 
            // passBoxUnlock
            // 
            this.AcceptButton = this.btnUnlock;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(383, 132);
            this.Controls.Add(this.lblPassVal);
            this.Controls.Add(this.btnMaskWatcher);
            this.Controls.Add(this.picLock);
            this.Controls.Add(this.lblMpass);
            this.Controls.Add(this.maskedMasterTextBox);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUnlock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PassBoxUnlock";
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
        private System.Windows.Forms.Label lblMpass;
        private System.Windows.Forms.PictureBox picLock;
        protected internal System.Windows.Forms.MaskedTextBox maskedMasterTextBox;
        private System.Windows.Forms.Button btnMaskWatcher;
        protected internal System.Windows.Forms.Label lblPassVal;
    }
}