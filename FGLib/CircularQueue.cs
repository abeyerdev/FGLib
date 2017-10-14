using System;
using System.Collections;
using System.Collections.Generic;

namespace FGLib
{
    /// <summary>
    /// Represents a strongly typed queue of objects that is circular in nature
    /// allowing the tail of the queue to eventually wrap back around to the head 
    /// and allow endless additions to the queue.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CircularQueue<T> : IEnumerable<T>
    {
        private T[] queue;
        private int head, tail = 0;
        private int size;

        /// <summary>
        /// Number of objects occupying space in the queue.
        /// </summary>
        public int Count {
            get
            {
                if (IsEmpty())
                {
                    return 0;
                }                    
                else
                {
                    int count = 1;

                    for (int i = head; i != tail; i = GetNextIndex(i))
                    {
                        count++;
                    }

                    return count;
                }                
            }
        }

        /// <summary>
        /// Current index of first object in the queue.
        /// </summary>
        public int Head { get { return head; } }

        /// <summary>
        /// Current index of last object in the queue.
        /// </summary>
        public int Tail { get { return tail; } }

        /// <summary>
        /// Number of total objects that can be stored in the queue.
        /// </summary>
        public int Size { get { return size; } }

        /// <summary>
        /// Constructs a new queue with the given size. Size must be greater than or equal to 2 
        /// as a lower size would not allow basic functionality that relies on head and tail
        /// values differing.
        /// </summary>
        /// <param name="size"></param>
        public CircularQueue(int size)
        {
            if (size < 2)
            {
                throw new ArgumentOutOfRangeException("Need to provide a size of at least 2 for a CircularQueue.");
            }

            this.size = size;
            queue = new T[this.size];           
        }

        /// <summary>
        /// Indexer for accessing queue values using bracket notation.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T this[int i]
        {
            get { return queue[i]; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)queue).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)queue).GetEnumerator();
        }

        /// <summary>
        /// Adds an element to end/tail of the queue.
        /// </summary>
        /// <param name="element"></param>
        public void Add(T element)
        {
            if (isIndexClear(head))
            {
                queue[head] = element;
            }
            else
            {
                tail = GetNextIndex(tail);
                queue[tail] = element;

                // handle case when tail becomes head
                if (head == tail)
                {
                    head = GetNextIndex(head);
                }
            }
        }

        /// <summary>
        /// Removes an element from the front/head of the queue.
        /// </summary>
        public void Remove()
        {
            if (!IsEmpty())
            {
                queue[head] = default(T);
                head = GetNextIndex(head);
            }
        }

        /// <summary>
        /// Clear the queue of all current values.
        /// </summary>
        public void Clear()
        {
            while(!IsEmpty())
            {
                Remove();
            }

            queue[head] = default(T);
        }

        /// <summary>
        /// Returns whether or not there are any items in the queue.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return head == tail;
        }

        /// <summary>
        /// Returns the next index in the queue, travelling towards the tail.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetNextIndex(int index)
        {
            return (index + 1) % size;
        }

        private bool isIndexClear(int index)
        {
            return queue[index] == null || queue[index].Equals(default(T));
        }
    }
}
