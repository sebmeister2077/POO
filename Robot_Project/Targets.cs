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
        protected string species;
        private int hp;
        public Target() { hp = 100; }
        public bool IsAlive
        {
            get { return alive; }
        }
        public void FiredAt(Intensity intensity,ref Planet planet)
        {
            if(intensity==Intensity.Kill)
            alive = false;
            if(intensity==Intensity.Cook)
            {
                hp -= 25;
                if (hp <= 0) alive = false;
            }
            if(alive==false)
                planet.LifeformKilled(this);//decrease population by 1
        }
        public string Species
        {
            get { return species; }
        }
    }
    class Human:Target
    {
        
        public Human() { alive = true;species = "Human"; }//add some human characteristic as parameters if you want

    }
}
