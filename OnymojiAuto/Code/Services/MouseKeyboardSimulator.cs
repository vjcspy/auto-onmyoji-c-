using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static OnymojiAuto.Code.Hooks.HookHelper;
using System.ComponentModel;

namespace OnymojiAuto.Code.Services
{
    class MouseKeyboardSimulator
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(int hWnd, MouseMessages Msg, int wParam, int lParam);

        // This function does not perform a case-sensitive search.
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int FindWindow(string strClassName, string strWindowName);

        // The FindWindowEx function retrieves a handle to a window whose class name 
        // and window name match the specified strings. The function searches child windows, beginning
        // with the one following the specified child window. This function does not perform a case-sensitive search.
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int FindWindowEx(int hwndParent, int hwndChildAfter, string strClassName, string strWindowName);


        // The SendMessage function sends the specified message to a 
        // window or windows. It calls the window procedure for the specified 
        // window and does not return until the window procedure has processed the message. 
        [DllImport("user32.dll", SetLastError = true)]
        public static extern Int32 SendMessage(
            int hWnd,               // handle to destination window
            int Msg,                // message
            int wParam,             // first message parameter
            [MarshalAs(UnmanagedType.LPStr)] string lParam); // second message parameter

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SendMessage(
            int hWnd,               // handle to destination window
            int Msg,                // message
            int wParam,             // first message parameter
            int lParam);            // second message parameter

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(int hWnd);

        public static void sendMouseClick(int hwnd, MouseMessages m, int x, int y)
        {
            //SetForegroundWindow(hwnd);
            bool sent = false;
            switch (m)
            {
                case MouseMessages.WM_LBUTTONUP:
                    sent = PostMessage(hwnd, MouseMessages.WM_LBUTTONUP, 0x00000000, MakeLParam(x, y));
                    break;
                case MouseMessages.WM_LBUTTONDOWN:
                    sent = PostMessage(hwnd, MouseMessages.WM_LBUTTONDOWN, 0x00000001, MakeLParam(x, y));
                    break;
            }
            if (sent == false)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        private static int MakeLParam(int LoWord, int HiWord)
        {
            return ((HiWord << 16) | (LoWord & 0xffff));
        }
    }
}