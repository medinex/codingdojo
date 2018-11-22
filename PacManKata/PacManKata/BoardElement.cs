using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManKata
{
    public class BoardElement
    {
        public char Representation { get; set; }

        public bool CanMove { get; set; }

        public BoardElement(char c)
        { Representation = c; }

        

        public virtual bool CanEat(BoardElement element)
        {
            return false;
        }

    }
}
