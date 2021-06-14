using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPersonala
{
    public class Agenda
    {
        static List<Agenda> AgendasList = new List<Agenda>();
        List<Activity> activityList;
        Person personAgenda;//who it belongs to
        
        public Agenda()
        {
            activityList = new List<Activity>();
            AgendasList.Add(this);
        }
        public Agenda(Person p):this()
        {
            personAgenda = p;
        }

        public List<Activity> Activities { get => activityList; }

        public void AddActivity(Activity activity)
        {
            bool ok = true;
            int[] indexes = new int[activity.Participants.Count];
            int x = 0;
            foreach (var p in activity.Participants)
            {
                
                List<Activity> acList = p.GetAgenda.activityList;
                if (acList.Count == 0)
                { indexes[x++] = 0; continue; }
                if (acList.Contains(activity))
                    throw new Exception($"This activity is already present in the agenda of person {personAgenda.FullName}");
                int i = 0;
                while (i < activityList.Count && acList[i].BeginDate.CompareTo(activity.BeginDate) < 0)
                    i++;

                if (i == 0 || i == acList.Count)
                {
                    if (i == 0 && acList[0].BeginDate.CompareTo(activity.EndDate) > 0)
                    { indexes[x++] = i; continue; } 
                    if (i == acList.Count && acList[i - 1].EndDate.CompareTo(activity.BeginDate) < 0)
                    { indexes[x++] = i; continue; }
                }
                else
                    if (acList[i-1].EndDate.CompareTo(activity.BeginDate) < 0)
                { indexes[x++] = i; continue; }
                ok = false;
                throw new Exception("This activity overlaps with another activity");
            }
            if(ok)
            {
                x = 0;
                foreach (var p in activity.Participants)
                    p.GetAgenda.activityList.Insert(indexes[x++], activity);
            }
        }
        public List<Activity> FindByName(string name)
        {
            List<Activity> list = new List<Activity>();
            foreach (var activity in activityList)
                if (activity.Name.Contains(name) || name.Contains(activity.Name))
                    list.Add(activity);
            return list;
        }
        public void DeleteActivity(Activity activity)
        {
            activityList.Remove(activity);
        }
        public void DeleteActivity(string activityName)
        {
            activityList.Remove(activityList.Find(x => x.Name == activityName));
        }
        /// <summary>
        /// Deletes all activities in between this time period
        /// </summary>
        public void DeleteActivity(DateTime dBegin,DateTime dEnd)
        {
            foreach(var activity in activityList)
                if (activity.BeginDate.CompareTo(dBegin) >= 0 && activity.BeginDate.CompareTo(dEnd) <= 0 ||
                    activity.EndDate.CompareTo(dBegin) >= 0 && activity.EndDate.CompareTo(dEnd) <= 0)
                    activityList.Remove(activity);
        }
        /// <summary>
        /// Returns a list of datetime Intervals where this person does not have any activities planned
        /// </summary>
        public List<Interval> FindInterval(int hours,int minutes)
        {
            List<Interval> list = new List<Interval>();
            minutes += 60 * hours;
            if ((activityList[0].BeginDate - DateTime.Now).Minutes > minutes)
                list.Add(new Interval(DateTime.Now, activityList[0].BeginDate));
            for (int i = 0; i < activityList.Count - 1; i++)
                if ((activityList[i].EndDate - activityList[i + 1].BeginDate).Minutes > minutes)
                    list.Add(new Interval(activityList[i].EndDate, activityList[i + 1].BeginDate));
            if (activityList[activityList.Count - 1].EndDate < DateTime.Now)
                list.Add(new Interval(DateTime.Now, DateTime.MaxValue));
            else
                list.Add(new Interval(activityList[activityList.Count - 1].EndDate, DateTime.MaxValue));
            return list;
        }
    }
}
