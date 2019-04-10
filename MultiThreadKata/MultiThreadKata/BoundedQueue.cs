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

        private void Enqueue(T element, CancellationToken token)
        {
            lock (_door)
            {
                while (Count >= Size)
                {
                    Thread.Sleep(1);
                    token.ThrowIfCancellationRequested();
                }

                _list[Count++] = element;
            }
        }

        public void Enqueue(T element)
        {
            Enqueue(element, CancellationToken.None);
        }

        public T Dequeue()
        {
           return Dequeue(CancellationToken.None);
        }

        private T Dequeue(CancellationToken token)

        {
            T retVal = default(T);
            lock (_doorDequeue)
            {
                while (Count == 0)
                {
                    Thread.Sleep(1);
                    token.ThrowIfCancellationRequested();
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
            CancellationTokenSource cancellationTokenSource = null;
            try
            {
                cancellationTokenSource = new CancellationTokenSource(timeoutMsec);

                var t = Task.Run(() =>
                {
                    Enqueue(element, cancellationTokenSource.Token);
                    return true;
                }, cancellationTokenSource.Token);

                t.Wait();

                return t.Result;
            }
            catch (Exception e) when (e is TaskCanceledException || e is OperationCanceledException || e is AggregateException)
            {
                return false;
            }
            finally
            {
                cancellationTokenSource?.Dispose();
            }
        }

        public bool TryDequeue(int timeoutMsec, out T element)
        {
            CancellationTokenSource cancellationTokenSource = null;
            element = default(T);
            try
            {
                cancellationTokenSource = new CancellationTokenSource(timeoutMsec);
                T retVal = default(T);
                var t = Task.Run(() =>
                {
                   retVal = Dequeue(cancellationTokenSource.Token);
                }, cancellationTokenSource.Token);

                t.Wait();
                element = retVal;
                return true;
            }
            catch (Exception e) when (e is TaskCanceledException || e is OperationCanceledException || e is AggregateException)
            {
                return false;
            }
            finally
            {
                cancellationTokenSource?.Dispose();
            }
        }
    }
}
