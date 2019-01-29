using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffKata.ViewModel
{
    public class KataViewModel : BaseViewModel
    {
        public Dictionary<long, string> HeadStringList { get; set; } = new Dictionary<long, string>();

        public Dictionary<long, string> BranchStringList { get; set; } = new Dictionary<long, string>();

        public string InputText { get; set; }
        enum flag { head, branch, both }

        public void ParseToList(string input)
        {
            flag position = flag.both;
            int lineNumberLeft = 0;
            int lineNumberRight = 0;

            var stringReader = new StringReader(input);
            string line = String.Empty;
            
            while ((line = stringReader.ReadLine()) != null)
            {
              

                if (line.StartsWith("<<<<<<<"))
                {
                    position = flag.head;
                    continue;
                }
                else if ( line.StartsWith("======="))
                {
                    position = flag.branch;
                    continue;
                }
                else if (line.StartsWith(">>>>>>>"))
                {
                    position = flag.both;
                    FillLines(ref lineNumberLeft, ref lineNumberRight);
                    continue;
                }

               
                if (position == flag.branch)
                {         
                    BranchStringList.Add(lineNumberRight, line);
                    lineNumberRight++;
                }
                else if (position == flag.head)
                {
                    HeadStringList.Add(lineNumberLeft, line);
                    lineNumberLeft++;
                }
                else
                {
                    HeadStringList.Add(lineNumberLeft, line);
                    BranchStringList.Add(lineNumberRight, line);

                    lineNumberLeft++;
                    lineNumberRight++;
                }

            }
        }

        private void FillLines(ref int lineNumberLeft, ref int lineNumberRight)
        {
            for (int i = lineNumberRight; i < lineNumberLeft; i++)
            {
                BranchStringList.Add(i, string.Empty);
                lineNumberRight++;
            }

            for (int i = lineNumberLeft; i < lineNumberRight; i++)
            {
                HeadStringList.Add(i, string.Empty);
                lineNumberLeft++;
            }
        }
    }
}
