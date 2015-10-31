namespace Prj_Padlockr
{
    partial class entryAddBox
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.accNameTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.userNameTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.passMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.linkTxtBox = new System.Windows.Forms.TextBox();
            this.btnMaskWatcher = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnLinkPaste = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(360, 118);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(279, 118);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account Name:";
            // 
            // accNameTxtBox
            // 
            this.accNameTxtBox.Location = new System.Drawing.Point(99, 12);
            this.accNameTxtBox.Name = "accNameTxtBox";
            this.accNameTxtBox.Size = new System.Drawing.Size(336, 20);
            this.accNameTxtBox.TabIndex = 2;
            this.accNameTxtBox.TextChanged += new System.EventHandler(this.accNameTxtBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name:";
            // 
            // userNameTxtBox
            // 
            this.userNameTxtBox.Enabled = false;
            this.userNameTxtBox.Location = new System.Drawing.Point(99, 38);
            this.userNameTxtBox.Name = "userNameTxtBox";
            this.userNameTxtBox.Size = new System.Drawing.Size(336, 20);
            this.userNameTxtBox.TabIndex = 2;
            this.userNameTxtBox.TextChanged += new System.EventHandler(this.userNameTxtBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Password:";
            // 
            // passMaskedTextBox
            // 
            this.passMaskedTextBox.Enabled = false;
            this.passMaskedTextBox.Location = new System.Drawing.Point(99, 65);
            this.passMaskedTextBox.Name = "passMaskedTextBox";
            this.passMaskedTextBox.Size = new System.Drawing.Size(244, 20);
            this.passMaskedTextBox.TabIndex = 3;
            this.passMaskedTextBox.UseSystemPasswordChar = true;
            this.passMaskedTextBox.TextChanged += new System.EventHandler(this.passMaskedBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Link:";
            // 
            // linkTxtBox
            // 
            this.linkTxtBox.Location = new System.Drawing.Point(99, 92);
            this.linkTxtBox.Name = "linkTxtBox";
            this.linkTxtBox.Size = new System.Drawing.Size(261, 20);
            this.linkTxtBox.TabIndex = 2;
            // 
            // btnMaskWatcher
            // 
            this.btnMaskWatcher.Enabled = false;
            this.btnMaskWatcher.Image = global::Prj_Padlockr.Properties.Resources.Eye;
            this.btnMaskWatcher.Location = new System.Drawing.Point(343, 64);
            this.btnMaskWatcher.Name = "btnMaskWatcher";
            this.btnMaskWatcher.Size = new System.Drawing.Size(18, 22);
            this.btnMaskWatcher.TabIndex = 4;
            this.btnMaskWatcher.UseVisualStyleBackColor = true;
            this.btnMaskWatcher.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMaskWatcher_MouseDown);
            this.btnMaskWatcher.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMaskWatcher_MouseUp);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Enabled = false;
            this.btnGenerate.Location = new System.Drawing.Point(360, 64);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 22);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnLinkPaste
            // 
            this.btnLinkPaste.Location = new System.Drawing.Point(360, 91);
            this.btnLinkPaste.Name = "btnLinkPaste";
            this.btnLinkPaste.Size = new System.Drawing.Size(75, 22);
            this.btnLinkPaste.TabIndex = 5;
            this.btnLinkPaste.Text = "Paste";
            this.btnLinkPaste.UseVisualStyleBackColor = true;
            this.btnLinkPaste.Click += new System.EventHandler(this.btnLinkPaste_Click);
            // 
            // entryAddBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(448, 153);
            this.Controls.Add(this.btnLinkPaste);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnMaskWatcher);
            this.Controls.Add(this.passMaskedTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkTxtBox);
            this.Controls.Add(this.userNameTxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.accNameTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "entryAddBox";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Entry";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        protected internal System.Windows.Forms.TextBox accNameTxtBox;
        protected internal System.Windows.Forms.TextBox userNameTxtBox;
        protected internal System.Windows.Forms.MaskedTextBox passMaskedTextBox;
        protected internal System.Windows.Forms.TextBox linkTxtBox;
        private System.Windows.Forms.Button btnMaskWatcher;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnLinkPaste;
    }
}