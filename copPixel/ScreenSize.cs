using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace copPixel
{
    public static class ScreenSize
    {
        public static int GetWidth() => Screen.PrimaryScreen.Bounds.Size.Width;
        public static int GetHeight() => Screen.PrimaryScreen.Bounds.Size.Height;
    }
}
