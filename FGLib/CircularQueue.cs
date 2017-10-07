using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CircularQueue
{
    /// <summary>
    /// A circular queue to hold input information
    /// for FGLib InputBuffer.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CircularQueue<T> : IEnumerable<T>
    {
        private T[] _queue;
        private int _head, _tail = 0;
        private int _size;

        public int Head { get { return _head; } }
        public int Tail { get { return _tail; } }
        public int Size { get { return _size; } }

        public CircularQueue(int size)
        {
            if (size < 2)
            {
                throw new ArgumentOutOfRangeException("Need to provide a size of at least 2 for a CircularQueue.");
            }

            _size = size;
            _queue = new T[_size];
        }

        public T this[int i]
        {
            get { return _queue[i]; }
        }

        /// <summary>
        /// Adds an element to end/tail of the queue.
        /// </summary>
        /// <param name="element"></param>
        public void Add(T element)
        {
            if (isIndexClear(_head))
            {
                _queue[_head] = element;
            }
            else
            {
                _tail = (_tail + 1) % _size;
                _queue[_tail] = element;

                // handle case when tail becomes head
                if (_head == _tail)
                {
                    _head = (_head + 1) % _size;
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
                _queue[_head] = default(T);
                _head = (_head + 1) % _size;
            }
        }

        /// <summary>
        /// Clear the queue of all current values.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < _size; i++)
            {
                _queue[i] = default(T);
            }

            _head = _tail;
        }

        public bool IsEmpty()
        {
            return _head == _tail;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_queue).GetEnumerator();
        }

        private bool isIndexClear(int index)
        {
            return _queue[index] == null || _queue[index].Equals(default(T));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_queue).GetEnumerator();
        }
    }
}
