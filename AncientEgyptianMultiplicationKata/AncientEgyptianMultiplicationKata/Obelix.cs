using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientEgyptianMultiplicationKata
{
    public class Obelix
    {
        public object Mul(int a, int b)
        {
            if (a < 1 || b < 1)
            {
                throw new ArgumentException();
            }

            int x, y, res;
            x = a;
            y = b;
            res = 0;
            while (x > 0)
            {
                if (x % 2 != 0)
                {
                    res += y;
                }

                x = x / 2;
                y = y * 2;
            }

            return res;
        }
    }
}
