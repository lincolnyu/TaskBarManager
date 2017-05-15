using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WinTop;

namespace TaskBarManager
{
    public partial class MainForm : Form
    {
        #region Fields

        private IntPtr _taskBarHwnd;

        private bool _suppressingUIToSysUpdate;

        #endregion

        #region Constructors

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region Event handlers

        private void MainForm_Load(object sender, EventArgs e)
        {
            var title = string.Format("{0} (ver {1})", Application.ProductName, GetMajorProductVersion());
            this.Text = title;
            _taskBarHwnd = WinApi.FindWindow("Shell_TrayWnd", "");
            InitUIAsPerOS();
            UpdateCheckBoxes();
        }

        private void BtnShowTaskBar_Click(object sender, EventArgs e)
        {
            WinApi.ShowWindow(_taskBarHwnd, WinApi.ShowWindowCommands.Show);
            WinApi.ShowWindow(_taskBarHwnd, WinApi.ShowWindowCommands.Minimize); // Or ForceMinimize
        }

        private void BtnHideTaskBar_Click(object sender, EventArgs e)
        {
            if ((ModifierKeys & Keys.Shift) != 0)
            {
                Properties.Settings.Default.RememberYesToHide = false;
            }

            if (!Properties.Settings.Default.RememberYesToHide)
            {
                var warning = new HideWarningForm();
                var res = warning.ShowDialog();
                if (res != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
            }

            WinApi.ShowWindow(_taskBarHwnd, WinApi.ShowWindowCommands.Hide);
        }

        private void ChkAutoHide_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAppBarState();

            UpdateCheckBoxes();
        }

        private void ChkAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAppBarState();

            UpdateCheckBoxes();
        }

        #endregion

        private void InitUIAsPerOS()
        {
            var osInfo = System.Environment.OSVersion;
            var platform = osInfo.Platform;
            var major = osInfo.Version.Major;
            var minor = osInfo.Version.Minor;
            if (platform == PlatformID.Win32NT && major == 6 && minor >= 2)
            { // Win8.1 or up
                ChkAlwaysOnTop.Enabled = false;
            }
        }

        private void UpdateAppBarState()
        {
            if (_suppressingUIToSysUpdate)
            {
                return;
            }

            var autohide = ChkAutoHide.Checked;
            var alwaysOnTop = ChkAlwaysOnTop.Checked;

            var abd = new WinApi.APPBARDATA();
            abd.hWnd = _taskBarHwnd;
            if (autohide)
            {
                abd.lParam = (int)(alwaysOnTop ? WinApi.ABState.ABS_AUTOHIDEANDONTOP : WinApi.ABState.ABS_AUTOHIDE);
            }
            else
            {
                abd.lParam = (int)(alwaysOnTop ? WinApi.ABState.ABS_ALWAYSONTOP : WinApi.ABState.ABS_MANUAL);
            }

            WinApi.SHAppBarMessage((uint)WinApi.ABMsg.ABM_SETSTATE, ref abd);
        }

        private void UpdateCheckBoxes()
        {
            _suppressingUIToSysUpdate = true;

            var abd = new WinApi.APPBARDATA();
            abd.cbSize = Marshal.SizeOf(abd);
            abd.hWnd = _taskBarHwnd;

#if false
            abd.uEdge = (uint)WinApi.ABEdge.ABE_BOTTOM;
            
            var prect = new WinApi.RECT(0,0,1,1);
            var hMonitor = WinApi.MonitorFromRect(ref prect, (uint)WinApi.MonitorDefault.MONITOR_DEFAULTTONEAREST);
            
            var monitorInfo = new WinApi.MONITORINFOEX();
            monitorInfo.Size = Marshal.SizeOf(monitorInfo);
            
            WinApi.GetMonitorInfo(hMonitor, ref monitorInfo);
            abd.rc = monitorInfo.WorkArea;
#endif
            
            var state = (WinApi.ABState)WinApi.SHAppBarMessage((uint)WinApi.ABMsg.ABM_GETSTATE, ref abd);
            ChkAutoHide.Checked = state == WinApi.ABState.ABS_AUTOHIDE
                || state == WinApi.ABState.ABS_AUTOHIDEANDONTOP;

            ChkAlwaysOnTop.Checked = state == WinApi.ABState.ABS_ALWAYSONTOP
                || state == WinApi.ABState.ABS_AUTOHIDEANDONTOP;

            _suppressingUIToSysUpdate = false;
        }

        private string GetMajorProductVersion()
        {
            var pv = Application.ProductVersion;
            var p = pv.IndexOf('.');
            if (p >= 0)
            {
                p = pv.IndexOf('.', p + 1);
            }
            if (p > 0)
            {
                return pv.Substring(0, p);
            }
            return pv;
        }

        #endregion
    }
}
