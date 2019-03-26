using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadKata
{
    public class BoundedQueue<T>
    {
        private T[] _list ;
        private readonly object _door = new object();

        public int Size { get; set; }
        public int Count { get; set; }

        public BoundedQueue(int size)
        {
            _list = new T[size];
            Size = size;
        }

        public void Enqueue(T element)
        {
            lock (_door)
            {
                while (Count >= Size)
                {
                    Thread.Sleep(10);                    
                }

                _list[Count++] = element;
            }
        }

        public T Dequeue()
        {
            var retVal = _list[0];
            for (int i = 1; i < Count; i++)
                _list[i - 1] = _list[i];
            Count--;
            return retVal;
        }


    }
}
