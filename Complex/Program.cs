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
            while (true)
            {
                Complex c = new Complex(Console.ReadLine());
                Console.WriteLine(c.ToString());
            }
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
                for (int i = 0; i < str.Length; i++)
                    if (i>0 && (str[i] == '-' || str[i] == '+'))
                    {
                        parts[0] = str.Substring(0, i);
                        parts[1] = str.Substring(i, str.Length - i);
                        break;
                    }
                if(parts[1]=="")//exista doar r sau doar i
                {
                    if(parts[0][parts[0].Length-1]=='i')
                    {
                        re = 0;
                        im = double.Parse(parts[0].Substring(0, parts[0].Length - 1));
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
                    im = double.Parse(parts[1].Substring(0, parts[1].Length - 1));
                }
                        
            }
            catch { Console.WriteLine("Error parsing string parameter to Complex"); }
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
            Putere(c,putere);

        public static Complex Putere(Complex c, int putere)
        {
            Complex aux = c;
            putere--;
            while (putere-- > 0)
                c = c * aux;
            return c;
        }
        public static Complex Multiplication(Complex c1,Complex c2)
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
