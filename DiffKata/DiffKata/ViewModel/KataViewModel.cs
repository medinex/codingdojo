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
           InputText = Properties.Resources.TestString;
        }

        private string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; FirePropertyChanged(); }
        }


        private bool _hasConflict;
        string _inputText = string.Empty;

        public Dictionary<long, string> HeadStringList { get; set; } = new Dictionary<long, string>();

        public Dictionary<long, string> BranchStringList { get; set; } = new Dictionary<long, string>();

        public ObservableCollection<ConflictText> HeadlistValues { get; set; } = new ObservableCollection<ConflictText>();
        public ObservableCollection<ConflictText> BranchlistValues { get; set; } = new ObservableCollection<ConflictText>();

        public ObservableCollection<ConflictText> Resultlist { get; set; } = new ObservableCollection<ConflictText>();

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
                FirePropertyChanged();
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
                var ct = new ConflictText()
                {
                    LineNumber = i,
                    Text = item.Value,
                    IsConflict = IsConflict(i++)
                };

                ct.PropertyChanged += Head_PropertyChanged;

                HeadlistValues.Add(ct);
            }
            i = 0;
            foreach (var item in BranchStringList)
            {
                var ct = new ConflictText()
                {
                    LineNumber = i,
                    Text = item.Value,
                    IsConflict = IsConflict(i++)
                };

                BranchlistValues.Add(ct);

                ct.PropertyChanged += Branch_PropertyChanged;
            }
            FillResultList();
        }

        private void Head_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            FillResultList();
        }

        private void Branch_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            FillResultList();
        }

        private void FillResultList()
        {
            Resultlist.Clear();

            foreach (var itemHead in HeadlistValues)
            {
                var itemBranch = BranchlistValues[(int)itemHead.LineNumber];
                var ct = new ConflictText();
                ct.LineNumber = itemHead.LineNumber;
                ct.Text = itemHead.Text;
                if (itemHead.IsConflict)
                {
                    string text="";
                    
                    if (itemHead.IsChecked && itemBranch.IsChecked)
                    {
                        text += itemHead.Text + Environment.NewLine + itemBranch.Text;
                    }

                    else if (itemHead.IsChecked)
                    {
                        text = itemHead.Text;
                    }


                    else if (itemBranch.IsChecked)
                    {
                        text += itemBranch.Text; 
                    }

                    ct.Text = text;
                }
                
                Resultlist.Add(ct);

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
