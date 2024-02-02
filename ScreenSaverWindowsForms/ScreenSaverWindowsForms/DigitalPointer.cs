using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ScreenSaver
{
    class DigitalPointer : Element
    {
        public int cx, cy, r;
        public double alpha;
        public int offset;
        public Color color;
        public int size;

        public DigitalPointer(int cx, int cy, int r, double alpha, int offset, Color color, int size) : base()
        {
            this.cx = cx;
            this.cy = cy;
            this.r = r;
            this.alpha = alpha;
            this.offset = offset;
            this.color = color;
            this.size = size;
        }

        public override void Draw(Graphics gf)
        {
            int x1 = cx + Convert.ToInt32(offset * Math.Cos(alpha * Math.PI / 180));
            int y1 = cy + Convert.ToInt32(offset * Math.Sin(alpha * Math.PI / 180));

            int x2 = cx + Convert.ToInt32((r + offset) * Math.Cos(alpha * Math.PI / 180));
            int y2 = cy + Convert.ToInt32((r + offset) * Math.Sin(alpha * Math.PI / 180));

            Pen pen = new Pen(color, size);
            gf.DrawLine(pen, x1, y1, x2, y2);
        }

    }
}
