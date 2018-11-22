using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyNumbersKata
{
    public class HappyNumber
    {
        public IEnumerable<int> SplitNumber(int num)
        {
            var asStr = num.ToString();
            var tt = asStr.Select(s => int.Parse(s.ToString()));
            return tt;
        }

        public Boolean IsHappy(int v)
        {
            var ret = v;
            var counter = 0;
            var trigger = true;
            while (trigger) {
                if (ret == 1 || counter == 99) {
                    trigger = false;
                }
                else {
                    ret = CalculateSum(SplitNumber(ret));
                    counter++;
                }
            }

            if (ret == 1) {
                return true;
            }
            else {
                return false;
            }

        }

        public int CalculateSum(IEnumerable<int> enumerable)
        {
            // falsch
            // return enumerable.Aggregate((x, y) => x + y * y);
            int r = 0;
            foreach (var x in enumerable) {
                r += x * x;
            }

            return r;
        }
    }
}
