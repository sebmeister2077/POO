using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Project
{
    public class Target
    {
        protected bool alive;
        public bool IsAlive
        {
            get { return alive; }
        }
        public void Killed()
        {
            alive = false;
        }
    }
    class Human:Target
    {
        
        public Human() { alive = true; }//add some human characteristic as parameters if you want
        public void Died()
        {
            alive = false;
        }

    }
}
