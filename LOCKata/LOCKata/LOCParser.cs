using System;
using System.Collections.Generic;
using System.IO;
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


        public string DeleteComments(string code)
        {
            var cleanCode = string.Empty;

            var so = new StringSplitOptions();
            foreach (var split in code.Split(new String[] { "/*" }, so))
            {
                foreach(var splitEnd in split.Split(new String[] { "*/"}, so)){
                    code.Remove(code.IndexOf(splitEnd), splitEnd.Length);
                }
            }


            string start = "";
            int startIndex = -1;
            int endIndex = -1;
            int index = 0;

            code.Split()

            foreach (char c in code)
            {
                if (c == '/')
                    start += c;
                else if (c == '*')
                    start += c;
                else
                    start = String.Empty;

                if (start == "/*")
                {
                    start = String.Empty;
                    startIndex = index;
                }
                    

                if (c == '*')
                    start += c;
                else if (c == '/')
                    start += c;
                else
                    start = String.Empty;

                if (start == "/*")
                    startIndex = index;


            }

            using (var reader = new StringReader(code))
            {
                //var x = reader.
                if (code.StartsWith("/*"))
                {
                    if (code.Contains("*/"))
                    {
                        code = code.Remove(0, code.IndexOf("*/"));
                    }
                }
            }

            return code;
        }

        private void Parse()
        {
            var list = _text.Split('\n');
            LinesTotal = list.Count();

            var linesOfCode = 0;

            bool commentBlock = false;

            foreach (var item in list)
            {
                var linesWithoutWhitespaces = item.Trim();              

                if (commentBlock && linesWithoutWhitespaces.Contains("*/"))
                {
                    commentBlock = false;
                    continue;
                }

                if (!linesWithoutWhitespaces.StartsWith("//") ||
                    !String.IsNullOrEmpty(linesWithoutWhitespaces) ||
                    !commentBlock)
                {
                    linesOfCode++;
                }

            }



            //LinesTotal = 1;
            //LinesOfCode = 0;
        }

        public int LinesTotal { get; private set; }
        public int LinesOfCode { get; private set; }

        


    }
}
