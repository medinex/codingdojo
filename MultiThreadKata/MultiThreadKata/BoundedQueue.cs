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
        private readonly object _doorDequeue = new object();

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
            T retVal = default(T);
            lock (_doorDequeue)
            {
                while (Count == 0)
                {
                    Thread.Sleep(10);
                }
                retVal = _list[0];
                for (int i = 1; i < Count; i++)
                    _list[i - 1] = _list[i];
                Count--;
                
            }
            return retVal;
        }

        public bool TryEnqueue( T element, int timeoutMsec)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(timeoutMsec);



            var t = Task.Run(() =>
            {
                Enqueue(element);
            }, cancellationTokenSource.Token);

            await t;
            return false;
        }


    }
}
