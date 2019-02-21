using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DiffKata.ViewModel
{
    public class ConflictText
    {
        public string Text { get; set; }
        public bool IsConflict { get; set; }
        public Brush Background  {

            get {
                return IsConflict ? Brushes.LightBlue : null;
            }
                        
        }

        public long LineNumber { get; set; }
       
    }
}
