using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Complex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Complex("+8-3i")/new Complex("i"));
            Console.ReadLine();
        }
    }
    class Complex
    {
        double re, im;
        public Complex()
        { }
        public Complex(string str)
        {
            try
            {
                string[] parts = new string[2];
                int i;
                for (i = 1; i < str.Length; i++)
                    if(str[i] == '-' || str[i] == '+') 
                       break;
                parts[0] = str.Substring(0, i);
                parts[1] = str.Substring(i, str.Length - i);
                if (parts[1]=="")//exista doar r sau doar i
                {
                    if(parts[0][parts[0].Length-1]=='i')
                    {
                        re = 0;
                        im = ParseImag(parts[0]);
                    }
                    else
                    {
                        re = double.Parse(parts[0]);
                        im = 0;
                    }
                }
                else
                {
                    re = double.Parse(parts[0]);
                    im = ParseImag(parts[1]);
                }
                        
            }
            catch { Console.WriteLine("Error parsing string parameter to Complex"); }
        }
        private double ParseImag(string str)
        {
            bool ok = false;//presupunem ca avem ...+i sau ...-i sau i
            double n;
            for (int i = 0; i < 2 && i < str.Length; i++)
                if (str[i] >= '0' && str[i] <= '9')
                    ok = true;
            if (!ok)
            {
                n = 1;// +i sau i = 1i
                if (str[0] == '-')
                    n= -n;
            }
            else
                n= double.Parse(str.Substring(0, str.Length - 1));
            return n;
        }
        public Complex(double r, double i=0)
        {
            this.im = i;
            this.re = r;
        }
        public static Complex operator +(Complex c1, Complex c2) =>
            new Complex(c1.re + c2.re, c1.im + c2.im);
        public static Complex operator -(Complex c1, Complex c2) =>
            new Complex(c1.re - c2.re, c1.im - c2.im);
        public static Complex operator *(Complex c1, Complex c2) =>
            new Complex(c1.re*c2.re-c1.im*c2.im, c1.re*c2.im + c1.im*c2.re);
        public static Complex operator ^(Complex c, int putere) =>
            Power(c,putere);
        public static Complex operator /(Complex c1, Complex c2) =>
            Divide(c1, c2);
        public static Complex Power(Complex c, int putere)
        {
            Complex aux = c;
            putere--;
            while (putere-- > 0)
                c = c * aux;
            return c;
        }
        public static Complex Multiply(Complex c1,Complex c2)
        {
            return new Complex(c1.re * c2.re - c1.im * c2.im, c1.re * c2.im + c1.im * c2.re);
        }
        public static Complex Subtract(Complex c1,Complex c2)
        {
            return new Complex(c1.re - c2.re, c1.im - c2.im);
        }
        public static Complex Add(Complex c1,Complex c2)
        {
            return new Complex(c1.re +c2.re, c1.im + c2.im);
        }
        public static Complex Divide(Complex c1,Complex c2)
        {
            //inmultesti cu conjugata/conjugata
            Complex aux1 = c1 * Conjugate(c2);
            double aux2 = (c2 * Conjugate(c2)).re;//devine real
            return new Complex(aux1.re / aux2, aux1.im / aux2);
        }
        public static Complex Conjugate(Complex c)
        {
            return new Complex(c.re, -c.im);
        }

        public override string ToString()
        {
            string str = "";
            if (re != 0)
                str += re.ToString();
            if (im != 0)
                if (im > 0)
                    str += "+" + im.ToString() + "i";
                else
                    str += im.ToString() + "i";
            return str;
        }
        public Complex Parse(string str)
        {
            Complex c=new Complex(str);
            return c;
        }

    }
}
