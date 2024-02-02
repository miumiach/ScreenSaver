using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ScreenSaver
{
    class Circle : Element
    {
        private int x, y, re, w, h;
        private Color color;

        public Circle(int x, int y, int re, Color color) : base ()
        {
            this.x = x - re/2;
            this.y = y - re/2;
            this.re = re;
            this.color = color;
            
            w = re;
            h = re;
        }

        public override void Draw(Graphics gf)
        {
            SolidBrush myBrush = new SolidBrush(color);
            gf.FillEllipse(myBrush, new Rectangle(x, y, w, h));
        }
    }
}
