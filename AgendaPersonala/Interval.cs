using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPersonala
{
    public class Interval
    {
        //could have used the TimeSpan class instead of making this class

        public DateTime Begin, End;
        public Interval() { }
        public Interval(DateTime begin,DateTime end) 
        {
            Begin = begin;
            End = end;
        }
        public static bool operator <(Interval a, Interval b) => (a.End - a.Begin) < (b.End - b.Begin);
        public static bool operator >(Interval a, Interval b) => (a.End - a.Begin) > (b.End - b.Begin);
        public Interval Min(Interval a,Interval b)
        {
            Interval c = new Interval();
            c.Begin = a.Begin > b.Begin ? a.Begin : b.Begin;
            c.End = a.End < b.End ? a.End : b.End;
            return c;
        }
        public int ToMinutes()
        {
            int a=0, b=0;
            if (Begin.Year < End.Year)
                b += 365;
            a += Begin.DayOfYear;
            b += End.DayOfYear;//totaldays
            a = a * 24;
            b = b * 24;
            a += Begin.Hour;
            b += End.Hour;//hours
            a = a * 60;
            b = b * 60;//minutes
            return b - a;
        }
    }
}
