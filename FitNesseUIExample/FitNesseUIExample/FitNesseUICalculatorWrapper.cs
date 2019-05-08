using CalculatorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitNesseUIExample
{
    public class FitNesseUICalculatorWrapper
    {
        private Calculator _calculator = new Calculator();

        public String Multiply(String numberAsString)
        {
            String result = "";

            if (numberAsString.Length > 0)
            {
                try
                {
                    result = _calculator.Multiply(Convert.ToInt64(numberAsString)).ToString();
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
            }

            return result;
        }
    }
}