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
        private static extern bool PostMessage(IntPtr hWnd, MouseMessages Msg, IntPtr wParam, IntPtr lParam);

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
        public static extern bool SendMessage(
            int hWnd,               // handle to destination window
            int Msg,                // message
            int wParam,             // first message parameter
            int lParam);			// second message parameter

		[DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void sendMouseClick(IntPtr hwnd, MouseMessages m, int x, int y)
        {
			SetFore
            bool sent = false;
            switch (m)
            {
                case MouseMessages.WM_LBUTTONUP:
                   	sent = SendMessage((int)hwnd, (int)MouseMessages.WM_LBUTTONUP,0x00000001, (int)MakeLParam(x, y));
                    break;
                case MouseMessages.WM_LBUTTONDOWN:
                    sent = SendMessage((int)hwnd, (int)MouseMessages.WM_LBUTTONDOWN,0x00000000, (int)MakeLParam(x, y));
                    break;
            }
            if (sent == false)
            {
                //throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        private static IntPtr MakeLParam(int LoWord, int HiWord)
        {
           return ((HiWord << 16) | (LoWord & 0xffff));
        }
    }
}