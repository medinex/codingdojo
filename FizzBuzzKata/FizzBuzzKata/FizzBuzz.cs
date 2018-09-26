using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzKata
{
    public class FizzBuzz
    {
        public static String buzzing(int v)
        {
            if (v <= 0)
            {
                throw new ArgumentException();
            }

            var ret = v.ToString();

            if (v % 3 == 0 && v % 5 == 0)
            {
                ret = "fizzbuzz";
            }
            else
            {
                if (v % 3 == 0)
                {
                    ret = "fizz";
                }
                else if (v % 5 == 0)
                {
                    ret = "buzz";
                }
            }


            return ret;
        }
    }
}
