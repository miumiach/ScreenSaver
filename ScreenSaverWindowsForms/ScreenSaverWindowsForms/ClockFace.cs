using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ScreenSaver
{
    public class ClockFace
    {
        public int width, height;

        private List<Element> hourElements = new List<Element>();
        private List<Element> minuteElements = new List<Element>();
        private Element shorterHand;
        private Element longerHand;
        private Element secondsHand;
        private Element cover;

        private Bitmap shorterHandBitmap;
        private Bitmap longerHandBitmap;

        public ClockFace(int width, int height, Bitmap shorterHandBitmap, Bitmap longerHandBitmap)
        {
            this.width = width;
            this.height = height;
            this.shorterHandBitmap = shorterHandBitmap;
            this.longerHandBitmap = longerHandBitmap;
        }

        private void AddClockFaceElements()
        {
            hourElements.Clear();
            minuteElements.Clear();

            int cx = Utils.PX(50, width);
            int cy = Utils.PY(50, height);
            int x, y, r, re, alpha, h;

            // hourElements
            r = Utils.PY(Settings.data.hourElementsOffset, height);
            re = Utils.PY(Settings.data.hourElementsLength, height);
            h = Utils.PY(Settings.data.hourElementsSize, height);
            alpha = 0;
            for (int i = 0; i <= 11; i++)
            {
                x = cx + Convert.ToInt32(r * Math.Cos(alpha * Math.PI / 180));
                y = cy + Convert.ToInt32(r * Math.Sin(alpha * Math.PI / 180));
                Element el = null;
                switch (Settings.data.hourElementsType)
                {
                    case "Circle":
                        el = new Circle(x, y, re, Color.FromArgb(Settings.data.hourElementsColor));
                        break;
                    case "Rectangle":
                        el = new Rect(x, y, re, h, Color.FromArgb(Settings.data.hourElementsColor), alpha);
                        break;
                }
                hourElements.Add(el);
                alpha += 30;
            }

            // minuteElements
            r = Utils.PY(Settings.data.minuteElementsOffset, height);
            re = Utils.PY(Settings.data.minuteElementsLength, height);
            h = Utils.PY(Settings.data.minuteElementsSize, height);
            alpha = 0;
            for (int i = 0; i <= 59; i++)
            {
                x = cx + Convert.ToInt32(r * Math.Cos(alpha * Math.PI / 180));
                y = cy + Convert.ToInt32(r * Math.Sin(alpha * Math.PI / 180));
                Element el = null;
                switch (Settings.data.minuteElementsType)
                {
                    case "Circle":
                        el = new Circle(x, y, re, Color.FromArgb(Settings.data.minuteElementsColor));
                        break;
                    case "Rectangle":
                        el = new Rect(x, y, re, h, Color.FromArgb(Settings.data.minuteElementsColor), alpha);
                        break;
                }
                minuteElements.Add(el);
                alpha += 6;
            }
        }

        public void AddPointers()
        {
            int cx = Utils.PX(50, width);
            int cy = Utils.PY(50, height);
            int r, offset, size;
            double alpha;

            #region SHORTER HAND

            r = Utils.PY(Settings.data.shorterHandLength, height);
            alpha = DateTime.Now.Hour * 30
                           + (double)DateTime.Now.Minute / 60 * 30
                           + (double)DateTime.Now.Second / 3600 * 30
                           - 90;
            offset = Utils.PY(Settings.data.shorterHandOffset, height);
            size = Utils.PY(Settings.data.shorterHandSize, height);

            switch (Settings.data.shorterHandType)
            {
                case "Rectangle":
                    shorterHand = new DigitalPointer(cx, cy, r, alpha, offset, Color.FromArgb(Settings.data.shorterHandColor), size);
                    break;
                case "Image":
                    shorterHand = new BitmapPointer(cx, cy, r, alpha, offset, Color.FromArgb(Settings.data.shorterHandColor), size, shorterHandBitmap);
                    break;
            }

            #endregion

            #region LONGER HAND

            r = Utils.PY(Settings.data.longerHandLength, height);
            alpha = DateTime.Now.Minute * 6
                        + (double)DateTime.Now.Second / 60 * 6
                        - 90;
            offset = Utils.PY(Settings.data.longerHandOffset, height);
            size = Utils.PY(Settings.data.longerHandSize, height);

            switch (Settings.data.longerHandType)
            {
                case "Rectangle":
                    longerHand = new DigitalPointer(cx, cy, r, alpha, offset, Color.FromArgb(Settings.data.longerHandColor), size);
                    break;
                case "Image":
                    longerHand = new BitmapPointer(cx, cy, r, alpha, offset, Color.FromArgb(Settings.data.longerHandColor), size, longerHandBitmap);
                    break;
            }

            #endregion

            #region SECONDS HAND

            r = Utils.PY(Settings.data.secondsHandLength, height);
            alpha = DateTime.Now.Second * 6 - 90;
            offset = Utils.PY(Settings.data.secondsHandOffset, height);
            size = Utils.PY(Settings.data.secondsHandSize, height);

            secondsHand = new DigitalPointer(cx, cy, r, alpha, offset, Color.FromArgb(Settings.data.secondsHandColor), size);

            #endregion
        }

        public void AddCover()
        {
            int cx = Utils.PX(50, width);
            int cy = Utils.PY(50, height);
            int re = Utils.PY(Settings.data.coverLength, height);
            cover = new Circle(cx, cy, re, Color.FromArgb(Settings.data.coverColor));
        }

        public void Draw(Graphics gf)
        {
            AddClockFaceElements();         
            if (Settings.data.swapElementsOrderEnabled)
            {
                if (Settings.data.hourElementsEnabled)
                {
                    DrawHourElements(gf);
                }
                if (Settings.data.minuteElementsEnabled)
                {
                    DrawMinuteElements(gf);
                }
            }
            else
            {
                if (Settings.data.minuteElementsEnabled)
                {
                    DrawMinuteElements(gf);
                }
                if (Settings.data.hourElementsEnabled)
                {
                    DrawHourElements(gf);
                }
            }

            AddPointers();
            DrawPointers(gf);

            AddCover();
            DrawCover(gf);
        }

        private void DrawHourElements(Graphics gf)
        {
            foreach (Element el in hourElements)
            {
                el.Draw(gf);
            }
        }

        private void DrawMinuteElements(Graphics gf)
        {
            foreach (Element el in minuteElements)
            {
                el.Draw(gf);
            }
        }

        private void DrawPointers(Graphics gf)
        {
            if (Settings.data.shorterHandEnabled)
            {
                shorterHand.Draw(gf);
            }
            if (Settings.data.longerHandEnabled)
            {
                longerHand.Draw(gf);
            }
            if (Settings.data.secondsHandEnabled)
            {
                secondsHand.Draw(gf);
            }
        }


        private void DrawCover(Graphics gf)
        {
            if (Settings.data.coverEnabled)
            {
                cover.Draw(gf);
            }
        }

    }
}
