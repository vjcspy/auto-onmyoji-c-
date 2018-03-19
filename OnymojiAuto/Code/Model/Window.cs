using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OnymojiAuto.Code.Services;
using AutoIt;

namespace OnymojiAuto.Code.Model
{
    public class Window
    {
        public int hwdn { get; }
        public string title { get; }

        public Window(string title)
        {
            this.title = title;
            hwdn = WinGetHandle(title);
        }

        public decimal PixelGetColor(int x, int y, int? hwnd)
        {
            return AutoItX.PixelGetColor(x, y);
        }

        public int WinGetHandle(string title)
        {
            return (int)AutoItX.WinGetHandle(title);
        }

        public int[] WinGetPos()
        {
            var winPos = AutoItX.WinGetPos(winHandle: (IntPtr)hwdn);
            if (winPos.IsEmpty)
            {
                throw new Exception("Can not find game window");
            }

            int[] _winPos = { winPos.X, winPos.Y, winPos.Width, winPos.Height };
            return _winPos;
        }

        public int getWindowX()
        {
            return WinGetPos()[0];
        }

        public int getWindowY()
        {
            return WinGetPos()[1];
        }

        public int getWindowWidth()
        {
            return WinGetPos()[2];
        }

        public int getWindowHeigh()
        {
            return WinGetPos()[3];
        }

        public decimal[] getPositionRelatedWindow(decimal realX, decimal realY)
        {
            decimal[] relatedPosition = new decimal[2];

            if ((realX - getWindowX()) <= getWindowWidth())
            {
                relatedPosition[0] = decimal.Round(((realX - getWindowX()) * 100 / getWindowWidth()), 5, MidpointRounding.AwayFromZero);
            }
            else
            {
                throw new Exception("Point out of current window with title: " + title);
            }

            if ((realY - getWindowY()) <= getWindowHeigh())
            {
                relatedPosition[1] = decimal.Round(((realY - getWindowY()) * 100 / getWindowHeigh()), 5, MidpointRounding.AwayFromZero);
            }
            else
            {
                throw new Exception("Point out of current window with title: " + title);
            }


            return relatedPosition;
        }

        public int[] getRealCoor(decimal relatedPosX, decimal relatedPosY)
        {
            if (relatedPosY > 100 || relatedPosX > 100)
            {
                throw new Exception("related position larger than 100");
            }

            int[] realCoor = new int[2];
            realCoor[0] = getWindowX() + (int)(relatedPosX * getWindowWidth() / 100);
            realCoor[1] = getWindowY() + (int)(relatedPosY * getWindowHeigh() / 100);

            return realCoor;
        }

        public decimal getColorOfPixelByRelatedPos(decimal x, decimal y)
        {
            var realCoor = getRealCoor(x, y);

            return PixelGetColor(realCoor[0], realCoor[1], hwdn);
        }

        public decimal getColorOfPixelByRelatedPos(PointColor point)
        {
            return getColorOfPixelByRelatedPos(point.x, point.y);
        }

        public bool isCorrectPixelByRelatedPos(decimal x, decimal y, decimal color)
        {
            var _color = getColorOfPixelByRelatedPos(x, y);
            return _color == color;
        }

        public bool isCorrectPixelByRelatedPos(PointColor pointColor)
        {
            return isCorrectPixelByRelatedPos(pointColor.x, pointColor.y, pointColor.color);
        }

        public void clickByRelatedCoor(PointColor pointColor)
        {
            clickByRelatedCoor(pointColor.x, pointColor.y);
        }

        public void clickByRelatedCoor(decimal x,decimal y)
        {
            var realCoor = getRealCoor(x, y);
            clickRealCoor(realCoor[0], realCoor[1]);
        }

        public void clickRealCoor(int x,int y)
        {
            MouseKeyboardSimulator.sendMouseClick(hwdn, Hooks.HookHelper.MouseMessages.WM_LBUTTONDOWN, x - getWindowX(), y-getWindowY());
            MouseKeyboardSimulator.sendMouseClick(hwdn, Hooks.HookHelper.MouseMessages.WM_LBUTTONUP, x - getWindowX(), y - getWindowY());
        }
    }
}