namespace TaskBarManager
{
    partial class MainForm
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
            this.BtnShowTaskBar = new System.Windows.Forms.Button();
            this.BtnHideTaskBar = new System.Windows.Forms.Button();
            this.ChkAutoHide = new System.Windows.Forms.CheckBox();
            this.ChkAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // BtnShowTaskBar
            // 
            this.BtnShowTaskBar.Location = new System.Drawing.Point(37, 16);
            this.BtnShowTaskBar.Name = "BtnShowTaskBar";
            this.BtnShowTaskBar.Size = new System.Drawing.Size(150, 30);
            this.BtnShowTaskBar.TabIndex = 0;
            this.BtnShowTaskBar.Text = "Show Task Bar";
            this.BtnShowTaskBar.UseVisualStyleBackColor = true;
            this.BtnShowTaskBar.Click += new System.EventHandler(this.BtnShowTaskBar_Click);
            // 
            // BtnHideTaskBar
            // 
            this.BtnHideTaskBar.Location = new System.Drawing.Point(37, 63);
            this.BtnHideTaskBar.Name = "BtnHideTaskBar";
            this.BtnHideTaskBar.Size = new System.Drawing.Size(150, 30);
            this.BtnHideTaskBar.TabIndex = 1;
            this.BtnHideTaskBar.Text = "Kill (Hide) Task Bar";
            this.BtnHideTaskBar.UseVisualStyleBackColor = true;
            this.BtnHideTaskBar.Click += new System.EventHandler(this.BtnHideTaskBar_Click);
            // 
            // ChkAutoHide
            // 
            this.ChkAutoHide.AutoSize = true;
            this.ChkAutoHide.Location = new System.Drawing.Point(37, 110);
            this.ChkAutoHide.Name = "ChkAutoHide";
            this.ChkAutoHide.Size = new System.Drawing.Size(117, 17);
            this.ChkAutoHide.TabIndex = 2;
            this.ChkAutoHide.Text = "Auto-hide Task Bar";
            this.ChkAutoHide.UseVisualStyleBackColor = true;
            this.ChkAutoHide.CheckedChanged += new System.EventHandler(this.ChkAutoHide_CheckedChanged);
            // 
            // ChkAlwaysOnTop
            // 
            this.ChkAlwaysOnTop.AutoSize = true;
            this.ChkAlwaysOnTop.Location = new System.Drawing.Point(37, 133);
            this.ChkAlwaysOnTop.Name = "ChkAlwaysOnTop";
            this.ChkAlwaysOnTop.Size = new System.Drawing.Size(144, 17);
            this.ChkAlwaysOnTop.TabIndex = 3;
            this.ChkAlwaysOnTop.Text = "Task Bar Always On Top";
            this.ChkAlwaysOnTop.UseVisualStyleBackColor = true;
            this.ChkAlwaysOnTop.CheckedChanged += new System.EventHandler(this.ChkAlwaysOnTop_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 167);
            this.Controls.Add(this.ChkAlwaysOnTop);
            this.Controls.Add(this.ChkAutoHide);
            this.Controls.Add(this.BtnHideTaskBar);
            this.Controls.Add(this.BtnShowTaskBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Bar Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnShowTaskBar;
        private System.Windows.Forms.Button BtnHideTaskBar;
        private System.Windows.Forms.CheckBox ChkAutoHide;
        private System.Windows.Forms.CheckBox ChkAlwaysOnTop;
    }
}

