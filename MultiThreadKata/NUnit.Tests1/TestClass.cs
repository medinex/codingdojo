// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
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

    }
}
