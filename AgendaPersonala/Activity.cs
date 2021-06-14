using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPersonala
{
    public class Activity
    {
        string name,description;
        DateTime endDate, beginDate;
        List<Person> activityParticipants;
        public Activity() {
            activityParticipants = new List<Person>();
        }
        public Activity(string name,string description,DateTime begindate,DateTime enddate,List<Person> participants):this()
        {
            this.name = name;
            this.description = description;
            this.beginDate = begindate;
            this.endDate = enddate;
            activityParticipants =new List<Person>(participants);
        }
        public string Name { get => name; }
        public DateTime BeginDate { get => beginDate; }
        public DateTime EndDate { get => endDate; }

        public List<Person> Participants { get => activityParticipants; }
    }
}
