// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiThreadKata;
using NUnit.Framework;

namespace NUnit.Tests1
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void IfEnqueueIsEqualDequeue()
        {
            var queue = new BoundedQueue<int>(2);

            queue.Enqueue(1);

            Assert.That(queue.Dequeue(), Is.EqualTo(1), "Some useful error message");
        }

        [Test]
        public void IfEnqueueIsEqualDequeueMultiple()
        {
            var queue = new BoundedQueue<int>(2);

            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Dequeue();

            Assert.That(queue.Dequeue(), Is.EqualTo(3), "Some useful error message");
        }

        [Test]
        public void IfEnqueueIsEqualDequeueTwice()
        {
            var queue = new BoundedQueue<int>(2);

            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.That(queue.Dequeue(), Is.EqualTo(2), "Some useful error message");
        }


        [Test]
        public void Enqueue3Dequeue1()
        {
            var queue = new BoundedQueue<int>(2);

            queue.Enqueue(2);
            queue.Enqueue(3);
            var t = Task.Run(() => queue.Enqueue(4));
            var timeout = Task.WhenAny(t, Task.Delay(100));
           
            Assert.That(t.IsCompleted, Is.False, "Some useful error message");
        }

        [Test]
        public async Task EnqueueAndDequeueMultiThreaded()
        {
            var queue = new BoundedQueue<int>(2);

            queue.Enqueue(2);
            queue.Enqueue(3);
            var t = Task.Run(() => queue.Enqueue(4));
            var timeout = Task.WhenAny(t, Task.Delay(100));
            await timeout;
            Assert.That(t.IsCompleted, Is.False, "Some useful error message");

            queue.Dequeue();
            await t;

            Assert.That(t.IsCompleted, Is.True, "Some useful error message");
            Assert.That(queue.Count, Is.EqualTo(2), "Some useful error message");
        }

        [Test]
        public async Task BigTest()
        {
            var list1 =  new List<int> { 1, 2, 3, 4, 5 };
            var list2 = new List<int> { 6, 7, 9, 10, 8 };
            var expected = new List<int>(list1.Union(list2));
            expected.Sort();
            var queue = new BoundedQueue<int>(2);

            var results = new ConcurrentBag<int>();

            var t1 = new Task(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    queue.Enqueue(list1[i]);
                }
            });

            var t2 = new Task(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    queue.Enqueue(list2[i]);
                }
            });

            var t3 = new Task(() =>
            {
            while (results.Count < 10)
                {
                    results.Add(queue.Dequeue());
                }
            });

            var t4 = new Task(() =>
            {
                while (results.Count < 10)
                {
                    results.Add(queue.Dequeue());
                }
            });

            t1.Start();
            t2.Start();

            t3.Start();
            t4.Start();

            var t5 = Task.Delay(5000);
            await Task.WhenAny(t3, t4, t5);

            Assert.That(t5.IsCompleted, Is.EqualTo(false), "TimeOut");
            Assert.That(results.Count, Is.EqualTo(10), "Count is not 10");

            var sortedList = results.ToList();
            sortedList.Sort();

            Assert.That(expected.SequenceEqual(sortedList), "Sequence not equal");
        }

        [Test]
        public async Task TryEnqueueShouldTimeout()
        {
            var queue = new BoundedQueue<int>(2);
            queue.Enqueue(1);
            queue.Enqueue(2);
            var ok = queue.TryEnqueue(3, 500);

            Assert.That(ok, Is.False);

        }

        [Test, Timeout(500)]
        public async Task TryEnqueueShouldNQ()
        {
            var queue = new BoundedQueue<int>(2);
            queue.Enqueue(1);
            var ok = queue.TryEnqueue(3, 500);

            Assert.That(ok, Is.True);
            Assert.That(queue.Dequeue(), Is.EqualTo(1));
            Assert.That(queue.Dequeue(), Is.EqualTo(3));
        }
    }
}
