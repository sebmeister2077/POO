using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// Creati un program care sa poata simula un/mai multi roboti care poate 
            /// fi manipulat in mai multe feluri, de exemplu distrugerea/uciderea unor tinte(eroi,oameni,ticalos) 
            /// </summary>

            Planet Earth = new Planet("Earth");
            Earth.Lifeforms.Add(new Human(), 340);//added 340 Humans to planet Earth

            GiantKillerRobot r= new GiantKillerRobot();
            r.Initialize();
            r.EyeLaserIntensity = Intensity.Kill;
            r.Targets = new HashSet<Target>() { new Human(), Animals, Superheroes };//create a new class foreach new item you want to add as a target

            r.TargetPlanets.Add(Earth);//the only implicit planet is Earth
            while (r.Active && r.TargetPlanetsContainsLife)
                if (r.CurrentTarget.IsAlive)
                    r.FireLaserAt(r.CurrentTarget);
                else
                    r.AquireNextTarget();

            Console.WriteLine(r);

        }
    }
}
