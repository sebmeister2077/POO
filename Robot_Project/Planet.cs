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
        private Dictionary<Target, uint> lifeforms;

        public Planet() { Name = "Planet"+(DateTime.Now.Millisecond%30); } 
        public Planet(string name)
        {
            this.Name = name;
            count++;
            lifeforms = new Dictionary<Target, uint>();
        }
        ~Planet()
        {
            count--;
        }
        public string Name { get; set; }
        public static int Count
        {
            get { return count; }
        }
        public  Dictionary<Target,uint> Lifeforms
        {
            get { return lifeforms; }
        }
        public void AddLifeform(Target lifeform,uint amount=1)
        {
            if (lifeforms.ContainsKey(lifeform))
                lifeforms[lifeform] += amount;//increases population
            else
                lifeforms.Add(lifeform, amount);//adds a new species to planet
        }

        public void LifeformKilled(Target lifeform)
        {
            lifeforms[lifeform]--;
            if (lifeforms[lifeform] == 0)
            {
                lifeforms.Remove(lifeform);
                Console.WriteLine($"Lifeform {lifeform.Species} exterminated on planet {this.Name}");
            }
        }
        public bool ContainsTarget(Target target)
        {
            return lifeforms.ContainsKey(target);
        }
        public bool ContainsLifeforms(HashSet<Target> list)
        {
            foreach (var lifeform in lifeforms)
                if (list.Contains(lifeform.Key))
                    return true;
            return false;
        }
    }
}
