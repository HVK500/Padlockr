namespace Prj_Padlockr
{
    partial class passBoxLock
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
            this.lblSetMpass = new System.Windows.Forms.Label();
            this.lblReMpass = new System.Windows.Forms.Label();
            this.firstMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.secondMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnMaskWatcher2 = new System.Windows.Forms.Button();
            this.picKey = new System.Windows.Forms.PictureBox();
            this.btnMaskWatcher1 = new System.Windows.Forms.Button();
            this.lblValidation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picKey)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSetMpass
            // 
            this.lblSetMpass.AutoSize = true;
            this.lblSetMpass.Location = new System.Drawing.Point(132, 12);
            this.lblSetMpass.Name = "lblSetMpass";
            this.lblSetMpass.Size = new System.Drawing.Size(160, 13);
            this.lblSetMpass.TabIndex = 0;
            this.lblSetMpass.Text = "Please enter a master password:";
            // 
            // lblReMpass
            // 
            this.lblReMpass.AutoSize = true;
            this.lblReMpass.Location = new System.Drawing.Point(132, 56);
            this.lblReMpass.Name = "lblReMpass";
            this.lblReMpass.Size = new System.Drawing.Size(151, 13);
            this.lblReMpass.TabIndex = 0;
            this.lblReMpass.Text = "Re-enter the master password:";
            // 
            // firstMaskedTextBox
            // 
            this.firstMaskedTextBox.Location = new System.Drawing.Point(135, 29);
            this.firstMaskedTextBox.Name = "firstMaskedTextBox";
            this.firstMaskedTextBox.Size = new System.Drawing.Size(236, 20);
            this.firstMaskedTextBox.TabIndex = 0;
            this.firstMaskedTextBox.UseSystemPasswordChar = true;
            this.firstMaskedTextBox.TextChanged += new System.EventHandler(this.firstMaskedTextBox_TextChanged);
            // 
            // secondMaskedTextBox
            // 
            this.secondMaskedTextBox.Enabled = false;
            this.secondMaskedTextBox.Location = new System.Drawing.Point(135, 72);
            this.secondMaskedTextBox.Name = "secondMaskedTextBox";
            this.secondMaskedTextBox.Size = new System.Drawing.Size(236, 20);
            this.secondMaskedTextBox.TabIndex = 1;
            this.secondMaskedTextBox.UseSystemPasswordChar = true;
            this.secondMaskedTextBox.TextChanged += new System.EventHandler(this.secondMaskedTextBox_TextChanged);
            // 
            // btnSet
            // 
            this.btnSet.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSet.Enabled = false;
            this.btnSet.Location = new System.Drawing.Point(135, 98);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(254, 23);
            this.btnSet.TabIndex = 2;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            // 
            // btnMaskWatcher2
            // 
            this.btnMaskWatcher2.Enabled = false;
            this.btnMaskWatcher2.Image = global::Prj_Padlockr.Properties.Resources.Eye;
            this.btnMaskWatcher2.Location = new System.Drawing.Point(371, 71);
            this.btnMaskWatcher2.Name = "btnMaskWatcher2";
            this.btnMaskWatcher2.Size = new System.Drawing.Size(18, 22);
            this.btnMaskWatcher2.TabIndex = 3;
            this.btnMaskWatcher2.TabStop = false;
            this.btnMaskWatcher2.UseVisualStyleBackColor = true;
            this.btnMaskWatcher2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMaskWatcher2_MouseDown);
            this.btnMaskWatcher2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMaskWatcher2_MouseUp);
            // 
            // picKey
            // 
            this.picKey.Image = global::Prj_Padlockr.Properties.Resources.key;
            this.picKey.InitialImage = null;
            this.picKey.Location = new System.Drawing.Point(7, 12);
            this.picKey.Name = "picKey";
            this.picKey.Size = new System.Drawing.Size(119, 107);
            this.picKey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picKey.TabIndex = 1;
            this.picKey.TabStop = false;
            // 
            // btnMaskWatcher1
            // 
            this.btnMaskWatcher1.Enabled = false;
            this.btnMaskWatcher1.Image = global::Prj_Padlockr.Properties.Resources.Eye;
            this.btnMaskWatcher1.Location = new System.Drawing.Point(371, 28);
            this.btnMaskWatcher1.Name = "btnMaskWatcher1";
            this.btnMaskWatcher1.Size = new System.Drawing.Size(18, 22);
            this.btnMaskWatcher1.TabIndex = 3;
            this.btnMaskWatcher1.TabStop = false;
            this.btnMaskWatcher1.UseVisualStyleBackColor = true;
            this.btnMaskWatcher1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMaskWatcher1_MouseDown);
            this.btnMaskWatcher1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMaskWatcher1_MouseUp);
            // 
            // lblValidation
            // 
            this.lblValidation.AutoSize = true;
            this.lblValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.lblValidation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblValidation.Location = new System.Drawing.Point(289, 57);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Size = new System.Drawing.Size(0, 13);
            this.lblValidation.TabIndex = 4;
            // 
            // passBoxLock
            // 
            this.AcceptButton = this.btnSet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 132);
            this.Controls.Add(this.lblValidation);
            this.Controls.Add(this.btnMaskWatcher1);
            this.Controls.Add(this.btnMaskWatcher2);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.secondMaskedTextBox);
            this.Controls.Add(this.firstMaskedTextBox);
            this.Controls.Add(this.picKey);
            this.Controls.Add(this.lblReMpass);
            this.Controls.Add(this.lblSetMpass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "passBoxLock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter Master Password";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.passBoxLock_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picKey)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSetMpass;
        private System.Windows.Forms.PictureBox picKey;
        private System.Windows.Forms.Label lblReMpass;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnMaskWatcher2;
        private System.Windows.Forms.Button btnMaskWatcher1;
        private System.Windows.Forms.Label lblValidation;
        protected internal System.Windows.Forms.MaskedTextBox firstMaskedTextBox;
        protected internal System.Windows.Forms.MaskedTextBox secondMaskedTextBox;
    }
}