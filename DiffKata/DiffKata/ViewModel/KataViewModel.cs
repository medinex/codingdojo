using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffKata.ViewModel
{
    public class KataViewModel : BaseViewModel
    {

        public KataViewModel()
        {
           // ParseToList(Properties.Resources.TestString);
        }

        private bool _hasConflict;
        string _inputText = Properties.Resources.TestString;

        public Dictionary<long, string> HeadStringList { get; set; } = new Dictionary<long, string>();

        public Dictionary<long, string> BranchStringList { get; set; } = new Dictionary<long, string>();

        public ObservableCollection<ConflictText> HeadlistValues { get; set; } = new ObservableCollection<ConflictText>();
        public ObservableCollection<ConflictText> BranchlistValues { get; set; } = new ObservableCollection<ConflictText>();

        public bool HasConflict
        {
            get
            {
                return _hasConflict;
            }

            set
            {
                if (_hasConflict != value)
                {
                    _hasConflict = value;
                    FirePropertyChanged();
                }
            }
        }

        public string InputText {
            get
            {
                return _inputText;
            }

            set
            {
                ParseToList(value);
                _inputText = value;
            }
        }
        enum flag { head, branch, both }

        public bool IsConflict(int atLine)
        {
            return HeadStringList[atLine].CompareTo(BranchStringList[atLine]) != 0;
        }

        public void ParseToList(string input)
        {
            BranchStringList.Clear();
            HeadStringList.Clear();
            BranchlistValues.Clear();
            HeadlistValues.Clear();

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
                    HasConflict = true;
                }
                else if (position == flag.head)
                {
                    HeadStringList.Add(lineNumberLeft, line);
                    lineNumberLeft++;
                    HasConflict = true;
                }
                else
                {
                    HeadStringList.Add(lineNumberLeft, line);
                    BranchStringList.Add(lineNumberRight, line);

                    lineNumberLeft++;
                    lineNumberRight++;
                }

            }

            int i = 0;
            foreach (var item in HeadStringList)
            {
                HeadlistValues.Add(new ConflictText()
                {
                    LineNumber = i,
                    Text = item.Value,
                    IsConflict = IsConflict(i++)
                });
            }
            i = 0;
            foreach (var item in BranchStringList)
            {
                BranchlistValues.Add(new ConflictText()
                {
                    LineNumber = i,
                    Text = item.Value,
                    IsConflict = IsConflict(i++)
                });
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
