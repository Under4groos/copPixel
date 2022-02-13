using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace copPixel
{
    public struct FPixel
    {
        public Color color_rgba;
        public Point position;
        public override string ToString()
        {
            return $"C:{color_rgba} , P: {position}";
        }
    }
}
