using FitNesseUIExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFixture
{
    public class CalculateTwoTimes
    {
        private FitNesseUICalculatorWrapper _calculator = new FitNesseUICalculatorWrapper();
        public String NumberToCalculateWith;
        public String Result() {
            return _calculator.Multiply(NumberToCalculateWith);
        }

        public CalculateTwoTimes() { }
    }
}
