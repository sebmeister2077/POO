using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUEUE
{
    interface IQueue<T>
    {
        T First();
        T Last();
        void Enqueue(T item);
        T Dequeue();

    }
    class Queue_list<T> : IQueue<T>
    {
        internal class Node
        {
            internal T item;
            internal Node next;
        }
        internal Node first;
        internal Node last;
        public Queue_list()
        { first = new Node();last = first; }
        public T First()
        {
            if (first == null)
                throw new Exception("First element is null.");
            return first.item;
        }
        public T Last()
        {
            if(last==null)
                throw new Exception("Last element is null.");
            return last.item;
        }
        public void Enqueue(T item)
        {
            last.item = item;
            last.next = new Node();
            last = last.next;
        }
        public T Dequeue()
        {
            if (first == null)
                throw new Exception("First element is null.");
            T item = first.item;
            first = first.next;
            return item;
        }
    }
    
    class Queue_array<T>:IQueue<T>
    {
        int capacity,elements;
        int first;
        int last;//pe pozitia last nu
        T[] array;
        public Queue_array(int capacity) { this.capacity = capacity; array = new T[capacity]; }
        public T Last()
        {
            if (last==first)
                throw new Exception("Last element is null.");
            return array[last];
        }
        public T First()
        {
            if (last == first)
                throw new Exception("First element is null.");
            return array[first];
        }
        public void Enqueue(T item)
        {
            if (elements == capacity)
                throw new Exception("Queue is full");
            elements++;
            array[last++] = item;
            last %= capacity;
        }
        public T Dequeue()
        {
            if (elements == 0)
                throw new Exception("Queue is empty.");
            elements--;
            T item = array[first++];
            first = first % capacity;
            return item;
        }

    }
}
