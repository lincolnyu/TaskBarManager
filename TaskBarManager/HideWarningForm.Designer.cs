namespace TaskBarManager
{
    partial class HideWarningForm
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
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnYes = new System.Windows.Forms.Button();
            this.BtnNo = new System.Windows.Forms.Button();
            this.ChkRemember = new System.Windows.Forms.CheckBox();
            this.RememberCheckToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(29, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(283, 52);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Hiding the task bar will permanently make it invisible.\r\nYou will have to press t" +
    "he \"Show Task Bar\" to restore it.\r\nAre you sure you want to continue?";
            // 
            // BtnYes
            // 
            this.BtnYes.Location = new System.Drawing.Point(29, 70);
            this.BtnYes.Name = "BtnYes";
            this.BtnYes.Size = new System.Drawing.Size(75, 23);
            this.BtnYes.TabIndex = 1;
            this.BtnYes.Text = "&Yes";
            this.BtnYes.UseVisualStyleBackColor = true;
            this.BtnYes.Click += new System.EventHandler(this.BtnYes_Click);
            // 
            // BtnNo
            // 
            this.BtnNo.Location = new System.Drawing.Point(110, 70);
            this.BtnNo.Name = "BtnNo";
            this.BtnNo.Size = new System.Drawing.Size(202, 23);
            this.BtnNo.TabIndex = 2;
            this.BtnNo.Text = "&No";
            this.BtnNo.UseVisualStyleBackColor = true;
            this.BtnNo.Click += new System.EventHandler(this.BtnNo_Click);
            // 
            // ChkRemember
            // 
            this.ChkRemember.AutoSize = true;
            this.ChkRemember.Location = new System.Drawing.Point(29, 112);
            this.ChkRemember.Name = "ChkRemember";
            this.ChkRemember.Size = new System.Drawing.Size(269, 17);
            this.ChkRemember.TabIndex = 3;
            this.ChkRemember.Text = "Remember \'Yes\' choice (Shift+click \'Kill ...\' to forget)";
            this.RememberCheckToolTip.SetToolTip(this.ChkRemember, "Click on the main dialog\'s \'Kill (Hide) Task Bar\' button with Shift key pressed t" +
        "o forget this \'Yes\' preference");
            this.ChkRemember.UseVisualStyleBackColor = true;
            // 
            // HideWarningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 151);
            this.Controls.Add(this.ChkRemember);
            this.Controls.Add(this.BtnNo);
            this.Controls.Add(this.BtnYes);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HideWarningForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Task Bar Manager";
            this.Load += new System.EventHandler(this.HideWarningForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtnYes;
        private System.Windows.Forms.Button BtnNo;
        private System.Windows.Forms.CheckBox ChkRemember;
        private System.Windows.Forms.ToolTip RememberCheckToolTip;

    }
}