using System;
using System.Collections.Generic;
using System.Linq;
using static WinTop.WinApi;
using static WinTop.WindowsFinder;

namespace WinTop
{
    public class Window
    {
        private string _text;

        public IntPtr Handle { get; set; }
        public string Text => _text ?? (_text = GetWindowText(Handle));
        public bool IsMain => IsMainWindow(Handle);

        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        /// <summary> Find all windows that match the given filter </summary>
        /// <param name="filter"> A delegate that returns true for windows
        ///    that should be returned and false for windows that should
        ///    not be returned </param>
        public static IEnumerable<Window> FindWindows(EnumWindowsProc filter = null)
        {
            var itrs = WindowsFinder.FindWindows(filter);
            return itrs.Select(x => new Window { Handle = x });
        }

        public bool UpdateWindowInfo()
        {
            RECT rect = default(RECT);
            if (GetWindowRect(Handle, ref rect))
            {
                X = rect.X;
                Y = rect.Y;
                Width = rect.Width;
                Height = rect.Height;
                return true;
            }
            return false;
        }

        public bool NailToTopmost() => SetWindowPos(Handle, new IntPtr((int)HWNDSpecials.HWND_TOPMOST), 0, 0, 0, 0, SWPFlags.SWP_NOMOVE | SWPFlags.SWP_NOSIZE | SWPFlags.SWP_SHOWWINDOW);

        public bool RestoreFromTopmost() => SetWindowPos(Handle, new IntPtr((int) HWNDSpecials.HWND_NOTOPMOST), 0, 0, 0, 0, SWPFlags.SWP_NOMOVE | SWPFlags.SWP_NOSIZE | SWPFlags.SWP_SHOWWINDOW);
    }
}
