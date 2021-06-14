using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPersonala
{
    public class Person
    {
        string name, surname, email;
        DateTime dateOfBirth;
        Agenda agenda;
        public Person()
        {
            agenda = new Agenda(this);
        }
        public Person(string name,string surname,string email,DateTime dateOfBirth):this()
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.dateOfBirth = dateOfBirth;
        }

        public string FullName { get => name + " " + surname; }
        public string Name { get => name; }
        public string Surname { get => surname; }
        public Agenda GetAgenda { get => agenda; }
        public void DropAgenda ()
        {
            agenda = new Agenda();
        }
        public void ActivityReport(DateTime dbegin,DateTime dend)
        {
            List<Activity> activities = agenda.Activities;
            TextWriter sw = new StreamWriter(@"..\..\ActivityReport.txt");
            for (int i=activities.FindIndex(x=>x.EndDate.CompareTo(dbegin)>=0);activities[i].EndDate.CompareTo(dend)<=0 ;i++)
            {
                sw.Write($"{activities[i].Name} from {activities[i].BeginDate} to {activities[i].EndDate} with");
                foreach (var p in activities[i].Participants)
                    sw.Write($" {p.Name}");
                sw.WriteLine();
            }
            sw.Close();
        }
        /// <summary>
        /// Returns a time interval telling if there can be a group activity between more people
        /// If not possible it will display a message and return DateTime.MinValue
        /// </summary>
        public static Interval FindActivityTime(List<Person> participants,int hours,int minutes=0)
        {
            if (participants.Count == 0)
                throw new Exception("There is no participant");
            DateTime dbegin, dend,auxbegin,auxend;
            dbegin = DateTime.MinValue;
            dend = DateTime.MaxValue;
            List<Interval> commonIntervals=new List<Interval>(participants[0].GetAgenda.FindInterval(hours,minutes));//at first includes all intervals,but then deletes those which are not common
            for(int i=1;i<participants.Count;i++)
            {
                List<Interval> pIntervals = participants[i].GetAgenda.FindInterval(hours, minutes);
                int x = 0, y = 0;
                byte overlapping;
                while(x<commonIntervals.Count&&y<pIntervals.Count)
                {
                    overlapping = 0;
                    if(pIntervals[y].End<commonIntervals[x].Begin)//no overlapping
                    { y++;continue; }
                    if(pIntervals[y].Begin>commonIntervals[x].End)//No overlapping, but interval won't be available => delete
                    {
                        commonIntervals.RemoveAt(x);
                        continue; 
                    }

                    if(pIntervals[y].Begin>commonIntervals[x].Begin)
                    {
                        overlapping++;
                        commonIntervals[x].Begin = pIntervals[y].Begin;
                    }
                    if(pIntervals[y].End<commonIntervals[x].End)
                    {
                        overlapping++;
                        commonIntervals[x].End = pIntervals[y].End;
                    }
                    x += overlapping;
                    y += overlapping;
                }
                if(x<commonIntervals.Count)//this person has less time available so the list deletes the next x to list.Count intervals
                    commonIntervals.Capacity = x;//TODO Verify this works(eliminates elements after index x
                
            }
            if (commonIntervals.Count == 0)
                return new Interval(DateTime.MinValue, DateTime.MinValue);
            return commonIntervals[0];

        }
    }
}
