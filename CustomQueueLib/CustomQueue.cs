using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueueLib
{
    public class CustomQueue<T>
    {
        private T[] array;
        private int size;
        private int capacity;
        private int head;
        private int tail;        

        public CustomQueue()
        {
            this.capacity = 10;
            this.array = new T[capacity];            
            this.size = 0;
            this.head = 0;
            this.tail = 0;
        }

        public CustomQueue(int capacity)
        {
            this.capacity = capacity;
            this.array = new T[capacity];
            this.size = 0;
            this.head = 0;
            this.tail = 0;            
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public void Enqueue(T newElement)
        {
            if (this.size == this.capacity)
            {
                T[] tempArray = new T[capacity*2];
                Array.Copy(array, tempArray, array.Length);
                array = tempArray;
                capacity *= 2;
            }
            size++;
            array[tail++ % capacity] = newElement;
        }

        public T Dequeue()
        {
            if (this.size == 0)
            {
                throw new InvalidOperationException();
            }
            size--;
            return array[++head % capacity];
        }

        public T Peek()
        {
            if (this.size == 0)
            {
                throw new InvalidOperationException();
            }
            return array[head  % capacity];
        }

        public CustomIterator GetEnumerator()
        {
            return new CustomIterator(this);
        }

        public class CustomIterator
        {
            private T[] temparray;
            private int currentIndex;

            public CustomIterator(CustomQueue<T> queue)
            {
                temparray = new T[queue.size];
                currentIndex = -1;
                Array.Copy(queue.array, (queue.head % queue.capacity), temparray, 0, queue.size);
            }

            public T Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex == temparray.Length)
                    {
                        throw new InvalidOperationException();
                    }
                    return temparray[currentIndex];
                }
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public bool MoveNext()
            {
                return ++currentIndex < temparray.Length;
            }
        }
    }
}
