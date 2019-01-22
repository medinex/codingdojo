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


        public List<string> ParseToList(string input)
        {
            var myList = new List<string>();
            var stringReader = new StringReader(input);
            string line = String.Empty;

            while ((line = stringReader.ReadLine()) != null)
            {
                if (line.StartsWith("<<<<<<<"))
                {

                }
                myList.Add(line);
            }

            return myList;

        }
    }
}
