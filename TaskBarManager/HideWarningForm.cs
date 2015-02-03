using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;


namespace TaskBarManager
{
    public partial class HideWarningForm : Form
    {
        public HideWarningForm()
        {
            InitializeComponent();
        }

        private void HideWarningForm_Load(object sender, EventArgs e)
        {
            Text = Application.ProductName;
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            if (ChkRemember.Checked)
            {
                Properties.Settings.Default.RememberYesToHide = true;
            }
            this.DialogResult = DialogResult.Yes;
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
