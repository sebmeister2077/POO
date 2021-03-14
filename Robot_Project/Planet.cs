using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Project
{
    public class Planet
    {
        static int count = 0;
        private Dictionary<Target,uint> amount;///amount of lifeform x
        private HashSet<Target> lifeforms;
        public Planet() 
        {
            count++;
            lifeforms = new HashSet<Target>();
            amount = new Dictionary<Target, uint>();
        }
        ~Planet()
        {
            count--;
        }
        public static int Count
        {
            get { return count; }
        }
        
        public bool ContainsTarget(Target target)
        {
            return lifeforms.Contains(target);
        }
        public bool ContainsLifeforms(HashSet<Target> list)
        {
            foreach (var lifeform in lifeforms)
                if (list.Contains(lifeform))
                    return true;
            return false;
        }
    }
}
