namespace Prj_Padlockr.Forms
{
    partial class passBoxChange
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
            this.picKey = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMaskWatcherOld = new System.Windows.Forms.Button();
            this.btnMaskWatcherNew = new System.Windows.Forms.Button();
            this.btnMaskWatcherRnew = new System.Windows.Forms.Button();
            this.maskedOldBox = new System.Windows.Forms.MaskedTextBox();
            this.maskedNewBox = new System.Windows.Forms.MaskedTextBox();
            this.maskedRnewBox = new System.Windows.Forms.MaskedTextBox();
            this.lblOpassValidation = new System.Windows.Forms.Label();
            this.lblNewPassValidation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picKey)).BeginInit();
            this.SuspendLayout();
            // 
            // picKey
            // 
            this.picKey.Image = global::Prj_Padlockr.Properties.Resources.key;
            this.picKey.InitialImage = null;
            this.picKey.Location = new System.Drawing.Point(7, 15);
            this.picKey.Name = "picKey";
            this.picKey.Size = new System.Drawing.Size(119, 107);
            this.picKey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picKey.TabIndex = 2;
            this.picKey.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(313, 133);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Enabled = false;
            this.btnAccept.Location = new System.Drawing.Point(232, 133);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Old password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "New password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Repeat new password:";
            // 
            // btnMaskWatcherOld
            // 
            this.btnMaskWatcherOld.Enabled = false;
            this.btnMaskWatcherOld.Image = global::Prj_Padlockr.Properties.Resources.Eye;
            this.btnMaskWatcherOld.Location = new System.Drawing.Point(371, 27);
            this.btnMaskWatcherOld.Name = "btnMaskWatcherOld";
            this.btnMaskWatcherOld.Size = new System.Drawing.Size(18, 22);
            this.btnMaskWatcherOld.TabIndex = 6;
            this.btnMaskWatcherOld.TabStop = false;
            this.btnMaskWatcherOld.UseVisualStyleBackColor = true;
            this.btnMaskWatcherOld.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMaskWatcherOld_MouseDown);
            this.btnMaskWatcherOld.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMaskWatcherOld_MouseUp);
            // 
            // btnMaskWatcherNew
            // 
            this.btnMaskWatcherNew.Enabled = false;
            this.btnMaskWatcherNew.Image = global::Prj_Padlockr.Properties.Resources.Eye;
            this.btnMaskWatcherNew.Location = new System.Drawing.Point(371, 66);
            this.btnMaskWatcherNew.Name = "btnMaskWatcherNew";
            this.btnMaskWatcherNew.Size = new System.Drawing.Size(18, 22);
            this.btnMaskWatcherNew.TabIndex = 6;
            this.btnMaskWatcherNew.TabStop = false;
            this.btnMaskWatcherNew.UseVisualStyleBackColor = true;
            this.btnMaskWatcherNew.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMaskWatcherNew_MouseDown);
            this.btnMaskWatcherNew.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMaskWatcherNew_MouseUp);
            // 
            // btnMaskWatcherRnew
            // 
            this.btnMaskWatcherRnew.Enabled = false;
            this.btnMaskWatcherRnew.Image = global::Prj_Padlockr.Properties.Resources.Eye;
            this.btnMaskWatcherRnew.Location = new System.Drawing.Point(371, 105);
            this.btnMaskWatcherRnew.Name = "btnMaskWatcherRnew";
            this.btnMaskWatcherRnew.Size = new System.Drawing.Size(18, 22);
            this.btnMaskWatcherRnew.TabIndex = 6;
            this.btnMaskWatcherRnew.TabStop = false;
            this.btnMaskWatcherRnew.UseVisualStyleBackColor = true;
            this.btnMaskWatcherRnew.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMaskWatcherRnew_MouseDown);
            this.btnMaskWatcherRnew.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMaskWatcherRnew_MouseUp);
            // 
            // maskedOldBox
            // 
            this.maskedOldBox.Location = new System.Drawing.Point(135, 28);
            this.maskedOldBox.Name = "maskedOldBox";
            this.maskedOldBox.Size = new System.Drawing.Size(236, 20);
            this.maskedOldBox.TabIndex = 0;
            this.maskedOldBox.UseSystemPasswordChar = true;
            this.maskedOldBox.TextChanged += new System.EventHandler(this.maskedOldBox_TextChanged);
            // 
            // maskedNewBox
            // 
            this.maskedNewBox.Enabled = false;
            this.maskedNewBox.Location = new System.Drawing.Point(135, 67);
            this.maskedNewBox.Name = "maskedNewBox";
            this.maskedNewBox.Size = new System.Drawing.Size(236, 20);
            this.maskedNewBox.TabIndex = 1;
            this.maskedNewBox.UseSystemPasswordChar = true;
            this.maskedNewBox.TextChanged += new System.EventHandler(this.maskedNewBox_TextChanged);
            // 
            // maskedRnewBox
            // 
            this.maskedRnewBox.Enabled = false;
            this.maskedRnewBox.Location = new System.Drawing.Point(135, 106);
            this.maskedRnewBox.Name = "maskedRnewBox";
            this.maskedRnewBox.Size = new System.Drawing.Size(236, 20);
            this.maskedRnewBox.TabIndex = 2;
            this.maskedRnewBox.UseSystemPasswordChar = true;
            this.maskedRnewBox.TextChanged += new System.EventHandler(this.maskedRnewBox_TextChanged);
            // 
            // lblOpassValidation
            // 
            this.lblOpassValidation.AutoSize = true;
            this.lblOpassValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.lblOpassValidation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblOpassValidation.Location = new System.Drawing.Point(212, 12);
            this.lblOpassValidation.Name = "lblOpassValidation";
            this.lblOpassValidation.Size = new System.Drawing.Size(0, 13);
            this.lblOpassValidation.TabIndex = 8;
            // 
            // lblNewPassValidation
            // 
            this.lblNewPassValidation.AutoSize = true;
            this.lblNewPassValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.lblNewPassValidation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNewPassValidation.Location = new System.Drawing.Point(12, 125);
            this.lblNewPassValidation.Name = "lblNewPassValidation";
            this.lblNewPassValidation.Size = new System.Drawing.Size(0, 13);
            this.lblNewPassValidation.TabIndex = 8;
            // 
            // passBoxChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 170);
            this.Controls.Add(this.lblNewPassValidation);
            this.Controls.Add(this.lblOpassValidation);
            this.Controls.Add(this.maskedRnewBox);
            this.Controls.Add(this.maskedNewBox);
            this.Controls.Add(this.maskedOldBox);
            this.Controls.Add(this.btnMaskWatcherRnew);
            this.Controls.Add(this.btnMaskWatcherNew);
            this.Controls.Add(this.btnMaskWatcherOld);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.picKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "passBoxChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Master Password";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.passBoxChange_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picKey)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picKey;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMaskWatcherOld;
        private System.Windows.Forms.Button btnMaskWatcherNew;
        private System.Windows.Forms.Button btnMaskWatcherRnew;
        protected internal System.Windows.Forms.MaskedTextBox maskedOldBox;
        protected internal System.Windows.Forms.MaskedTextBox maskedNewBox;
        protected internal System.Windows.Forms.MaskedTextBox maskedRnewBox;
        protected internal System.Windows.Forms.Label lblOpassValidation;
        protected internal System.Windows.Forms.Label lblNewPassValidation;
        private IPadlockrDbContext dbContext;

        // Parse the dbContext object through the passBoxChange dialog
        public passBoxChange(IPadlockrDbContext dbContext)
        {
            InitializeComponent();
            this.dbContext = dbContext;
        }
    }
}