using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackKataLibrary
{
    public class StackKata <TElement>: IStack<TElement>
    {
        private List<TElement> _elements = new List<TElement>();

        public StackKata(List<TElement> element)
        {
            _elements = element;
        }

        public StackKata()
        {
        }

        public TElement Pop()
        {
            var result = _elements.Any() ? _elements.Last() : throw new InvalidOperationException();
            _elements.Remove(result);
            return result;
        }

        public void Push(TElement element)
        {
            _elements.Add(element);
        }

        public int Count {
            get { return _elements.Count(); } }

        public List<TElement> GetAsList()
        {
            return _elements;
        }
    }
}
