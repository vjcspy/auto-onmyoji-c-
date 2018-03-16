using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OnymojiAuto.Code.Hooks.HookHelper;

namespace OnymojiAuto.Code.Hooks
{
    public class MouseHookGlobal
    {
        //Declare the hook handle as an int.
        public int hHook = 0;

        public delegate void MouseActionDelegate(MouseMessages mouseMessage, int x, int y);

        public event MouseActionDelegate MouseAction;

        private CallbackDelegate _proc;

        public void Install()
        {
            _proc = new CallbackDelegate(this.HookCallBack);
            hHook = SetupHook(_proc);

            if (hHook == 0)
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        public void StopHook()
        {
            if (hHook != 0)
                UnhookWindowsHookEx(hHook);
        }


        private int SetupHook(CallbackDelegate hookProc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(HookType.WH_MOUSE_LL, hookProc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private int HookCallBack(int nCode, int wParam, int lParam)
        {
            //Marshall the data from the callback.
            MouseHookStruct CurrentMouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure((IntPtr)lParam, typeof(MouseHookStruct));
            MouseMessages CurrentMouseMessage = (MouseMessages)wParam;

            if (nCode < 0)
            {
                return CallNextHookEx(hHook, nCode, wParam, lParam);
            }
            else
            {
                //Create a string variable that shows the current mouse coordinates.
                String strCaption = "x = " +
                CurrentMouseHookStruct.pt.x.ToString("d") +
                "  y = " +
                CurrentMouseHookStruct.pt.y.ToString("d");

                MouseAction?.Invoke(CurrentMouseMessage, CurrentMouseHookStruct.pt.x, CurrentMouseHookStruct.pt.y);

                return CallNextHookEx(hHook, nCode, wParam, lParam);
            }
        }
    }
}
