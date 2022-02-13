using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace copPixel
{
    public static class NumberLib
    {
        public static bool diapazon(int number, int ddd, int a = 40)
        {
            int aa_ = ddd + a;
            int bb_ = ddd - a;

            if (number <= aa_ && number >= bb_)
                return true;
            return false;
        }
    }
}
