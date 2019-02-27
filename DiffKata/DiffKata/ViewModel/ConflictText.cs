using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DiffKata.ViewModel
{
    public class ConflictText : BaseViewModel
    {
        public string Text
        {
            get { return _Text; }
            set { _Text = value; FirePropertyChanged(); }
        }

        private bool _isConflict;

        public bool IsConflict
        {
            get { return _isConflict; }
            set { _isConflict = value; FirePropertyChanged(); }
        }

        private bool _isChecked;
        private string _Text;

        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value;
                 FirePropertyChanged(); }
        }


        public Brush Background  {

            get {
                return IsConflict ? Brushes.LightBlue : null;
            }
                        
        }

        public long LineNumber { get; set; }
       
    }
}
