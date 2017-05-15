using System;
using System.Collections.Generic;
using System.Text;
using static WinTop.WinApi;

namespace WinTop
{
    public class WindowsFinder
    {
        /// <summary> Get the text for the window pointed to by hWnd </summary>
        public static string GetWindowText(IntPtr hWnd)
        {
            int size = GetWindowTextLength(hWnd);
            if (size > 0)
            {
                var builder = new StringBuilder(size + 1);
                WinApi.GetWindowText(hWnd, builder, builder.Capacity);
                return builder.ToString();
            }
            return String.Empty;
        }

        /// <summary> Find all windows that match the given filter </summary>
        /// <param name="filter"> A delegate that returns true for windows
        ///    that should be returned and false for windows that should
        ///    not be returned </param>
        public static IEnumerable<IntPtr> FindWindows(EnumWindowsProc filter = null)
        {
            var windows = new IntPtrEnumerable();

            EnumWindows((wnd, param) =>
            {
                if (filter?.Invoke(wnd, param) != false)
                {
                    // only add the windows that pass the filter
                    windows.Add(wnd);
                }
                // but return true here so that we iterate all windows
                return true;
            }, IntPtr.Zero);

            return windows;
        }

        /// <summary> Find all windows that contain the given title text </summary>
        /// <param name="titleText"> The text that the window title must contain. </param>
        public static IEnumerable<IntPtr> FindWindowsWithText(string titleText)
            => FindWindows((wnd, param) => GetWindowText(wnd).Contains(titleText));

        public static bool IsMainWindow(IntPtr hwnd)
            => GetWindow(hwnd, GWCmds.GW_OWNER) == IntPtr.Zero && IsWindowVisible(hwnd);
    }
}
