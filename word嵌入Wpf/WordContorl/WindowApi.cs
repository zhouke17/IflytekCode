using System;
using System.Runtime.InteropServices;

namespace WpfApp.WordContorl
{
    public static class WindowApi
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string strclassName, string strWindowName);

        [DllImport("user32.dll")]
        public static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern bool SetWindowPos(
            IntPtr hWnd,               // handle to window
            IntPtr hWndInsertAfter,    // placement-order handle
            int X,                  // horizontal position
            int Y,                  // vertical position
            int cx,                 // width
            int cy,                 // height
            uint uFlags             // window-positioning options
        );

        [DllImport("user32.dll", EntryPoint = "MoveWindow")]
        public static extern bool MoveWindow(
            IntPtr hWnd,
            int X,
            int Y,
            int nWidth,
            int nHeight,
            bool bRepaint
        );

        public const int SWP_DRAWFRAME = 0x20;
        public const int SWP_NOMOVE = 0x2;
        public const int SWP_NOSIZE = 0x1;
        public const int SWP_NOZORDER = 0x4;
    }
}
