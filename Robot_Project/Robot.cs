using System;
using System.Collections.Generic;

namespace Robot_Project
{
    public enum Intensity { None, Warm, Cook, Kill }
    public enum Planets { Mercury,Venus,Earth,Mars}
    public abstract class Robot
    {
        protected static int count=0;
        protected int arms, legs;
        protected bool active;
        private string name;
        public Robot() 
        {
            count++;
            this.active = false;
            this.arms = 0;
            this.legs = 0;
            this.name = "Robot"+DateTime.Now.Millisecond%99;
        }
        ~Robot()
        {
            count--;
        }
        public void Initialize()
        {
            active = true;
            Console.WriteLine($"{this.name} has awakened");
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public static int Count
        {
            get { return count; }
        }

    }
    public class GiantKillerRobot : Robot
    {
        private Intensity intensity;
        private HashSet<Target> targets;//unique targets, human and human is not valid,but human1 and human2 is
        private HashSet<Planet> targetPlanets;
        private Target currentTarget;
        private Planet currentPlanet;

        public GiantKillerRobot() 
        {
            EyeLaserIntensity = Intensity.None;
            targets = new HashSet<Target>();
            currentPlanet = null;
            currentTarget = null;
        }
        ~GiantKillerRobot()
        {
            count--;
        }

        #region Properties
        public HashSet<Target> Targets
        {
            get { return targets; }
            set { targets = value; RefreshPlanet(); }
        }
        public HashSet<Planet> TargetPlanets
        {
            get { return targetPlanets; }
            set { targetPlanets = value;RefreshPlanet(); }
        }

        

        public Intensity EyeLaserIntensity
        {
            get { return this.intensity; }
            set { intensity = value; }
        }
        public int Arms
        {
            get { return arms; }
            set { arms = value; }
        }
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        public bool TargetPlanetsContainsLife
        {
            get { return _TargetPlanetsContainsLife(); }
        }
        public Planet CurrentPLanet
        {
            get { return currentPlanet; }
        }
        public Target CurrentTarget
        {
            get {
                    foreach (var target in targets)
                        if (currentPlanet.ContainsTarget(target))
                            return target;
                return null;//no ore alive targets exists
            }
        }
        #endregion
        #region Methods
        private bool _TargetPlanetsContainsLife()
        {
            foreach (var planet in targetPlanets)
                if (planet.ContainsLifeforms(targets))
                    return true;
            return false;
        }
        public void FireLaserAt(Target target)
        {
            target.Killed();

        }
        private void RefreshPlanet()//refreshes the Current planet
        {
            if (currentPlanet.ContainsLifeforms(targets))
                return;
            else foreach (var planet in targetPlanets)
                    if (planet.ContainsLifeforms(targets))
                        currentPlanet = planet;
        }
        #endregion
    }
}
