namespace Prj_Padlockr
{
    partial class generatePassBox
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtBoxGen = new System.Windows.Forms.TextBox();
            this.chkBoxSLetters = new System.Windows.Forms.CheckBox();
            this.chkBoxCapLetters = new System.Windows.Forms.CheckBox();
            this.chkBoxNum = new System.Windows.Forms.CheckBox();
            this.chkBoxSpec = new System.Windows.Forms.CheckBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.numLength = new System.Windows.Forms.NumericUpDown();
            this.gBoxOptions = new System.Windows.Forms.GroupBox();
            this.gBoxGenPass = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).BeginInit();
            this.gBoxOptions.SuspendLayout();
            this.gBoxGenPass.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(479, 124);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Enabled = false;
            this.btnAccept.Location = new System.Drawing.Point(398, 124);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            // 
            // txtBoxGen
            // 
            this.txtBoxGen.Location = new System.Drawing.Point(6, 19);
            this.txtBoxGen.Name = "txtBoxGen";
            this.txtBoxGen.ReadOnly = true;
            this.txtBoxGen.Size = new System.Drawing.Size(445, 20);
            this.txtBoxGen.TabIndex = 1;
            this.txtBoxGen.TabStop = false;
            this.txtBoxGen.TextChanged += new System.EventHandler(this.txtBoxGen_TextChanged);
            // 
            // chkBoxSLetters
            // 
            this.chkBoxSLetters.AutoSize = true;
            this.chkBoxSLetters.Checked = true;
            this.chkBoxSLetters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxSLetters.Location = new System.Drawing.Point(15, 19);
            this.chkBoxSLetters.Name = "chkBoxSLetters";
            this.chkBoxSLetters.Size = new System.Drawing.Size(86, 17);
            this.chkBoxSLetters.TabIndex = 1;
            this.chkBoxSLetters.Text = "Small Letters";
            this.chkBoxSLetters.UseVisualStyleBackColor = true;
            // 
            // chkBoxCapLetters
            // 
            this.chkBoxCapLetters.AutoSize = true;
            this.chkBoxCapLetters.Checked = true;
            this.chkBoxCapLetters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxCapLetters.Location = new System.Drawing.Point(107, 19);
            this.chkBoxCapLetters.Name = "chkBoxCapLetters";
            this.chkBoxCapLetters.Size = new System.Drawing.Size(93, 17);
            this.chkBoxCapLetters.TabIndex = 2;
            this.chkBoxCapLetters.Text = "Capital Letters";
            this.chkBoxCapLetters.UseVisualStyleBackColor = true;
            // 
            // chkBoxNum
            // 
            this.chkBoxNum.AutoSize = true;
            this.chkBoxNum.Checked = true;
            this.chkBoxNum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxNum.Location = new System.Drawing.Point(206, 19);
            this.chkBoxNum.Name = "chkBoxNum";
            this.chkBoxNum.Size = new System.Drawing.Size(68, 17);
            this.chkBoxNum.TabIndex = 3;
            this.chkBoxNum.Text = "Numbers";
            this.chkBoxNum.UseVisualStyleBackColor = true;
            // 
            // chkBoxSpec
            // 
            this.chkBoxSpec.AutoSize = true;
            this.chkBoxSpec.Checked = true;
            this.chkBoxSpec.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxSpec.Location = new System.Drawing.Point(280, 19);
            this.chkBoxSpec.Name = "chkBoxSpec";
            this.chkBoxSpec.Size = new System.Drawing.Size(103, 17);
            this.chkBoxSpec.TabIndex = 4;
            this.chkBoxSpec.Text = "Special Symbols";
            this.chkBoxSpec.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(476, 17);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(78, 45);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // numLength
            // 
            this.numLength.Location = new System.Drawing.Point(389, 18);
            this.numLength.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numLength.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numLength.Name = "numLength";
            this.numLength.Size = new System.Drawing.Size(55, 20);
            this.numLength.TabIndex = 5;
            this.numLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numLength.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // gBoxOptions
            // 
            this.gBoxOptions.Controls.Add(this.chkBoxSLetters);
            this.gBoxOptions.Controls.Add(this.numLength);
            this.gBoxOptions.Controls.Add(this.chkBoxCapLetters);
            this.gBoxOptions.Controls.Add(this.chkBoxSpec);
            this.gBoxOptions.Controls.Add(this.chkBoxNum);
            this.gBoxOptions.Location = new System.Drawing.Point(12, 68);
            this.gBoxOptions.Name = "gBoxOptions";
            this.gBoxOptions.Size = new System.Drawing.Size(458, 50);
            this.gBoxOptions.TabIndex = 5;
            this.gBoxOptions.TabStop = false;
            this.gBoxOptions.Text = "Parameters";
            // 
            // gBoxGenPass
            // 
            this.gBoxGenPass.Controls.Add(this.txtBoxGen);
            this.gBoxGenPass.Location = new System.Drawing.Point(12, 12);
            this.gBoxGenPass.Name = "gBoxGenPass";
            this.gBoxGenPass.Size = new System.Drawing.Size(458, 50);
            this.gBoxGenPass.TabIndex = 6;
            this.gBoxGenPass.TabStop = false;
            this.gBoxGenPass.Text = "Generated password";
            // 
            // generatePassBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(566, 159);
            this.Controls.Add(this.gBoxGenPass);
            this.Controls.Add(this.gBoxOptions);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "generatePassBox";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate password";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).EndInit();
            this.gBoxOptions.ResumeLayout(false);
            this.gBoxOptions.PerformLayout();
            this.gBoxGenPass.ResumeLayout(false);
            this.gBoxGenPass.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.CheckBox chkBoxSLetters;
        private System.Windows.Forms.CheckBox chkBoxCapLetters;
        private System.Windows.Forms.CheckBox chkBoxNum;
        private System.Windows.Forms.CheckBox chkBoxSpec;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.NumericUpDown numLength;
        private System.Windows.Forms.GroupBox gBoxOptions;
        private System.Windows.Forms.GroupBox gBoxGenPass;
        protected internal System.Windows.Forms.TextBox txtBoxGen;
    }
}