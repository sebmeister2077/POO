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
            Planet Earth = new Planet();

            GiantKillerRobot r= new GiantKillerRobot();
            r.Initialize();
            r.EyeLaserIntensity = Intensity.Kill;
            r.Targets = new HashSet<Target>() { Targets, Animals, Superheroes };//create a new class foreach new item you want to add as a target

            r.TargetPlanets.Add(Earth);//the only implicit planet is Earth
            while(r.Active&&r.TargetPlanetsContainsLife)
                if(r.CurrentTarget.IsAlive)
                    r.

            Console.WriteLine(r);

        }
    }
}
