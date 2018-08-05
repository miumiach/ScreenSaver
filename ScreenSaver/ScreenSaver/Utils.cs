using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ScreenSaver
{
    public class Utils
    {
        public static int PX(double x, int width)
        {
            int result = Convert.ToInt32(x * width / 100);
            if (result == 0)
            {
                result = 1;
            }
            return result;
        }

        public static int PY(double y, int height)
        {
            int result = Convert.ToInt32(y * height / 100);
            if (result == 0)
            {
                result = 1;
            }
            return result;
        }
    }
}
