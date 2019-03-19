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
            int startIndex = -1;
            bool insideString = false;

            for (int i = 0; i< code.Length; i++)
            {
                var c = code[i];
                if (c == '"')
                    insideString = !insideString;

                if (c == '/' && code[Math.Min(i+1, code.Length-1)] == '*' && startIndex == -1 && !insideString)
                    startIndex = i;
                else if (c== '*' && code[Math.Min(i + 1, code.Length - 1)] == '/' && startIndex != -1 && !insideString)
                {
                    code = code.Remove(startIndex, i - startIndex + 2);
                    return DeleteComments(code);
                }

                if (c == '/' && code[Math.Min(i + 1, code.Length - 1)] == '/' && !insideString)
                {
                    var newLine = code.IndexOf(Environment.NewLine, i);
                    if (newLine >= 0)
                    {
                        code = code.Remove(i, newLine - i);
                    }
                    else
                    {
                        code = code.Remove(i, code.Length - i);
                    }
                }
            }
            return code;
        }

        private void Parse()
        {
            LinesTotal = _text.Split('\n').Count();
            var text = DeleteComments(_text);

            LinesOfCode = 0;
            var list = text.Split('\n');
            foreach(var line in list)
            {
                if (!string.IsNullOrWhiteSpace(line.Trim())) {
                    LinesOfCode++;
                }
            }
         
        }

        public int LinesTotal { get; private set; }
        public int LinesOfCode { get; private set; }

        


    }
}
