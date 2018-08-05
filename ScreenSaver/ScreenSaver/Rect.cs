using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ScreenSaver
{
    class Rect : Element
    {
        private int x1, y1, x2, y2, re, h;
        private double alpha;
        private Color color;

        public Rect(int x, int y, int re, int h, Color color, int alpha) : base ()
        {
            this.re = re;
            this.color = color;
            this.alpha = alpha;
            this.h = h;

            x1 = x - Convert.ToInt32(re/2 * Math.Cos(alpha * Math.PI / 180));
            y1 = y - Convert.ToInt32(re/2 * Math.Sin(alpha * Math.PI / 180));

            x2 = x + Convert.ToInt32(re/2 * Math.Cos(alpha * Math.PI / 180));
            y2 = y + Convert.ToInt32(re/2 * Math.Sin(alpha * Math.PI / 180));

            
        }

        public override void Draw(Graphics gf)
        {
            Pen pen = new Pen(color, h);
            gf.DrawLine(pen, x1, y1, x2, y2);    
        }
    }
}
