using System;
using System.Collections.Generic;
using System.Linq;
using static WinTop.WinApi;
using static WinTop.WindowsFinder;

namespace WinTop
{
    public class Window
    {
        private static int _simpleIdGenerator = 0;

        public static void ResetIdGenerator()
        {
            _simpleIdGenerator = 0;
        }

        public Window()
        {
            Id = ++_simpleIdGenerator;
        }

        public int Id { get; private set; }
        public IntPtr Handle { get; set; }
        public string Text => GetWindowText(Handle);
        public bool IsMain => IsMainWindow(Handle);

        public RECT? Rect
        {
            get
            {
                RECT rect = default(RECT);
                if (!GetWindowRect(Handle, ref rect))
                {
                    return null;
                }
                return rect;
            }
        }

        public WindowStyles WindowStyle => (WindowStyles)GetWindowLong(Handle, WindowLongFlags.GWL_EXSTYLE);

        public bool IsTopMost
        {
            get
            {
                return (WindowStyle & WindowStyles.WS_EX_TOPMOST) != 0;
            }
        }

        /// <summary> Find all windows that match the given filter </summary>
        /// <param name="filter"> A delegate that returns true for windows
        ///    that should be returned and false for windows that should
        ///    not be returned </param>
        public static IEnumerable<Window> FindWindows(EnumWindowsProc filter = null)
        {
            var itrs = WindowsFinder.FindWindows(filter);
            return itrs.Select(x => new Window { Handle = x });
        }

        public bool NailToTopmost()
            =>
            SetWindowPos(Handle, new IntPtr((int)HWNDSpecials.HWND_TOPMOST), 0, 0, 0, 0, SWPFlags.SWP_NOMOVE | SWPFlags.SWP_NOSIZE | SWPFlags.SWP_SHOWWINDOW);

        public bool RestoreFromTopmost()
            => SetWindowPos(Handle, new IntPtr((int)HWNDSpecials.HWND_NOTOPMOST), 0, 0, 0, 0, SWPFlags.SWP_NOMOVE | SWPFlags.SWP_NOSIZE | SWPFlags.SWP_SHOWWINDOW);

        public bool BringToTop() => BringWindowToTop(Handle);
    }
}
