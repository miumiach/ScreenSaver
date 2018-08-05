using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ScreenSaver
{
    class BitmapPointer : Element
    {
        public int cx, cy, r;
        public double alpha;
        public int offset;
        public Color color;
        public int size;
        public Bitmap bitmap;

        public BitmapPointer(int cx, int cy, int r, double alpha, int offset, Color color, int size, Bitmap bitmap)
            : base()
        {
            this.cx = cx;
            this.cy = cy;
            this.r = r;
            this.alpha = alpha + 90;
            this.offset = offset;
            this.color = color;
            this.size = size;
            this.bitmap = bitmap;
        }

        public override void Draw(Graphics gf)
        {
            GraphicsState state;
            state = gf.Save();

            Matrix obrot = new Matrix();
            obrot.RotateAt((float)alpha, new Point(0, 0));
            gf.Transform = obrot;

            int x1 = cx - bitmap.Width / 2;
            int y1 = cy - bitmap.Height;
            gf.DrawImage(bitmap, 300, 300);
            gf.Restore(state);
        }

    }
}
