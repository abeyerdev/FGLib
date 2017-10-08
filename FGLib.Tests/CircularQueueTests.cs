using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FGLib.CircularQueue;

namespace FGLib.Tests.CircularQueue
{
    [TestClass]
    public class CircularQueueTests
    {
        [TestMethod]
        public void CanConstruct_Test()
        {
            CircularQueue<string> queue = new CircularQueue<string>(5);
            Assert.IsInstanceOfType(queue, typeof(CircularQueue<string>));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Need to provide a size of at least 2 for a CircularQueue.")]
        public void CannotCreateQueueSmallerThan2_Test()
        {
            CircularQueue<string> failure = new CircularQueue<string>(1);
        }

        [TestMethod]
        public void CanAdd_Test()
        {
            CircularQueue<string> queue = new CircularQueue<string>(5);
            queue.Add("First");
            queue.Add("Second");
            queue.Add("Third");
            queue.Add("Fourth");
            queue.Add("Fifth");

            Assert.IsTrue(queue[0] == "First");
            Assert.IsTrue(queue[1] == "Second");
            Assert.IsTrue(queue[2] == "Third");
            Assert.IsTrue(queue[3] == "Fourth");
            Assert.IsTrue(queue[4] == "Fifth");

            Assert.IsTrue(queue.Head == 0);
            Assert.IsTrue(queue.Tail == 4);
        }

        [TestMethod]
        public void CanAddToLoopAround_Test()
        {
            CircularQueue<string> queue = new CircularQueue<string>(5);
            queue.Add("First");
            queue.Add("Second");
            queue.Add("Third");
            queue.Add("Fourth");
            queue.Add("Fifth");
            queue.Add("Sixth");
            queue.Add("Seventh");
            queue.Add("Eighth");
            queue.Add("Ninth");
            queue.Add("Tenth");
            queue.Add("Eleventh");

            Assert.IsTrue(queue[0] == "Eleventh");
            Assert.IsTrue(queue[1] == "Seventh");
            Assert.IsTrue(queue[2] == "Eighth");
            Assert.IsTrue(queue[3] == "Ninth");
            Assert.IsTrue(queue[4] == "Tenth");

            Assert.IsTrue(queue.Head == 1);
            Assert.IsTrue(queue.Tail == 0);
        }

        [TestMethod]
        public void CanRemove_Test()
        {
            CircularQueue<string> queue = new CircularQueue<string>(5);
            queue.Add("First");
            queue.Add("Second");
            queue.Add("Third");
            queue.Add("Fourth");
            queue.Add("Fifth");
            queue.Remove();

            Assert.IsTrue(queue[0] == null);
            Assert.IsTrue(queue[1] == "Second");
            Assert.IsTrue(queue[2] == "Third");
            Assert.IsTrue(queue[3] == "Fourth");
            Assert.IsTrue(queue[4] == "Fifth");

            Assert.IsTrue(queue.Head == 1);
            Assert.IsTrue(queue.Tail == 4);
        }

        [TestMethod]
        public void CanClear_Test()
        {
            CircularQueue<int> queue = new CircularQueue<int>(3) { 0, 222, 2321 };
            queue.Clear();

            Assert.IsTrue(queue.IsEmpty());
        }
    }
}
