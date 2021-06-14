using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasa_Stiva
{
    public class Stiva<T>
    {
        T[] array;
        int capacity;
        int index;
        public Stiva(int capacity)
        {
            index = 0;
            this.capacity = capacity;
            array = new T[capacity];
        }
        public void Push(T item)
        {
            if (index == capacity)
                throw new Exception("Stiva este plina.");
            array[index++] = item;
        }
        public T Pop()
        {
            if (index < 1)
                throw new Exception("Stiva este goala.");
            return array[--index];
        }
        public void Clear()
        {
            index = 0;
            array = new T[capacity];
        }
    }
}
