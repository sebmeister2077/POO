using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rational
{
    public class Rational
    {
        private int a, b;
        #region Contructor
        public Rational()
        { }
        public Rational(int a, int b)
        {
            this.a = a;
            if (b == 0)
                throw new Exception("Numar invalid.Nu se poate efectua impartirea cu 0");
            else
                if (b < 0)
            {
                a = -a;
                this.b = -b;
            }
            else
                this.b = b;

        }
        public Rational(Rational r)
        {
            this.a = r.a;
            this.b = r.b;
        }
        #endregion
        #region Properties
        //readonly
        public int A
        {
            get { return a; }
        }
        public int B
        {
            get { return b; }
        }
        public Rational Invers
        {
            get { return new Rational(b, a); }
        }
        #endregion
        #region operators
        public static Rational operator +(Rational r1, Rational r2) =>
             (new Rational(r1.a * r2.b + r2.a * r1.b, r1.b * r2.b)).Simplific();
        public static Rational operator -(Rational r1, Rational r2) =>
            (new Rational(r1.a * r2.b - r2.a * r1.b, r1.b * r2.b)).Simplific();
        public static Rational operator *(Rational r1, Rational r2) =>
          (new Rational(r1.a * r2.a, r1.b * r2.b)).Simplific();
        public static Rational operator /(Rational r1, Rational r2) =>
            (Impartire(r1, r2));

        #endregion
        #region Methods
        private Rational Simplific()//aceasta functie se foloseste doar in interiorul clasei,mai precis in sectiunea de mai sus
        {
            for (int i = 2; i <= this.b; i++)
                if (a % i == 0 && b % i == 0)
                {
                    a /= i;
                    b /= i;
                    i--;
                }
            return this;
        }
        public void Simplifica()
        {
            for (int i = 2; i <= this.b; i++)
                if (a % i == 0 && b % i == 0)
                {
                    a /= i;
                    b /= i;
                    i--;
                }
        }
        public void Amplificare(int n)
        {
            a *= n;
            b *= n;
        }
        public static Rational Adunare(Rational r1, Rational r2)
        {
            return new Rational(r1 + r2);//simplificarea nu mai este nevoie deoarece este mai sus implicita
        }
        public static Rational Scadere(Rational r1, Rational r2)
        {
            return new Rational(r1 - r2);
        }
        public static Rational Inmultire(Rational r1, Rational r2)
        {
            return new Rational(r1 * r2);
        }
        public static Rational Impartire(Rational r1, Rational r2)
        {
            if (r2.a == 0)
            {
                Console.WriteLine("Impartirea nu se poate efectua.");
                return new Rational();
            }
            else
                return (new Rational(r1 * r2.Invers)).Simplific();
        }
        public Rational Clone()
        {
            return new Rational(this);
        }
        public override string ToString()
        {
            return a.ToString() + "/" + b.ToString();
        }
        #endregion
    }
}
