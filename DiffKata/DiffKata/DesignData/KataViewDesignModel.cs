using DiffKata.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffKata.DesignData
{
    public class KataViewDesignModel : KataViewModel
    {



        public KataViewDesignModel()
        {
            ParseToList(Properties.Resources.TestString);

            Text = "Test";

        }
    }
}
