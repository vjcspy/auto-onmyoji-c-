using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OnymojiAuto.Code.Services;

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
            return 0;
        }

        public int WinGetHandle(string title)
        {
            return 0;
        }

        public int[] WinGetPos()
        {
            int[] winPos = { };

            return winPos;
        }

        public int getWindowX()
        {
            return this.WinGetPos()[0];
        }

        public int getWindowY()
        {
            return this.WinGetPos()[1];
        }

        public int getWindowWidth()
        {
            return this.WinGetPos()[2];
        }

        public int getWindowHeigh()
        {
            return this.WinGetPos()[3];
        }

        public int[] getPositionRelatedWindow(int realX, int realY)
        {
            int[] relatedPosition = { };

            if ((realX - getWindowX()) <= getWindowWidth())
            {
                relatedPosition[0] = ((realX - getWindowX()) * 100 / getWindowWidth());
            }
            else
            {
                throw new Exception("Point out of current window with title: " + this.title);
            }

            if ((realY - getWindowY()) <= getWindowHeigh())
            {
                relatedPosition[1] = ((realY - getWindowY()) * 100 / getWindowHeigh());
            }
            else
            {
                throw new Exception("Point out of current window with title: " + this.title);
            }


            return relatedPosition;
        }

        public int[] getRealCoor(int relatedPosX, int relatedPosY)
        {
            if (relatedPosY > 100 || relatedPosX > 100)
            {
                throw new Exception("related position larger than 100");
            }

            int[] realCoor = { };
            realCoor[0] = getWindowX() + relatedPosX * getWindowWidth() / 100;
            realCoor[1] = getWindowY() + relatedPosY * getWindowHeigh() / 100;

            return realCoor;
        }

        public decimal getColorOfPixelByRelatedPos(int x, int y)
        {
            var realCoor = this.getRealCoor(x, y);

            return PixelGetColor(realCoor[0], realCoor[1], this.hwdn);
        }

        public bool isCorrectPixelByRelatedPos(int x, int y, decimal color)
        {
            return getColorOfPixelByRelatedPos(x, y) == color;
        }

        public bool isCorrectPixelByRelatedPos(PointColor pointColor)
        {
            return isCorrectPixelByRelatedPos(pointColor.x, pointColor.y, pointColor.color);
        }

        public void clickByRelatedCoor(PointColor pointColor)
        {
            var realCoor = getRealCoor(pointColor.x, pointColor.y);
        }
    }
}