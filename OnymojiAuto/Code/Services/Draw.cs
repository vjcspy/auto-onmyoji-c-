using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OnymojiAuto.Code.Services
{
    class Draw
    {
        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);

        public static void drawLine(int x, int y)
        {
            IntPtr desktopPtr = GetDC(IntPtr.Zero);
            Graphics g = Graphics.FromHdc(desktopPtr);

            SolidBrush b = new SolidBrush(Color.White);
            g.FillRectangle(b, new Rectangle(x, y, 1, 1));

            Pen myPen = new Pen(Color.Red)
            {
                Width = 30
            };
            g.DrawLine(myPen, x, y, x + 10, y);

            g.Dispose();
            ReleaseDC(IntPtr.Zero, desktopPtr);
        }
    }
}
