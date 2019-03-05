using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOCKata
{
    public class LOCParser
    {
        private string _text;

        public LOCParser(string v)
        {
            this._text = v;
            Parse();
        }

        private void Parse()
        {
            
            var list = _text.Split('\n');
            LinesTotal = list.Count();

            foreach (var item in list)
            {
                var linesWithoutWhitespaces = item.Trim();

                if (!linesWithoutWhitespaces.StartsWith("//"))
                {

                }

            }



            //LinesTotal = 1;
            //LinesOfCode = 0;
        }

        public int LinesTotal { get; private set; }
        public int LinesOfCode { get; private set; }

        


    }
}
