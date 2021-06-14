using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasa_Stiva
{
    class Program
    {
        static void Main(string[] args)
        {
            Stiva<int> st = new Stiva<int>(10);
            for (int i = 0; i < 11; i++)
                st.Push(i);
        }
    }
}
