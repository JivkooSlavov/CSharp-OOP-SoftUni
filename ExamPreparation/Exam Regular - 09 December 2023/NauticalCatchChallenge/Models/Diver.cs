using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private List<string> caugthFish;
        private double competitionPoints;
        private bool hasHealthIssues;

        protected Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            caugthFish = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }
                name = value;
            }
        }

        public int OxygenLevel
        {
            get => oxygenLevel;
            protected set
            {
                if (value<=0)
                {
                    HasHealthIssues = true;
                    oxygenLevel = 0;
                } 
                else
                {
                    oxygenLevel = value;
                }

            }
        }


        public IReadOnlyCollection<string> Catch => caugthFish.AsReadOnly();

        public double CompetitionPoints
        {
            get => competitionPoints;
            private set
            {
                competitionPoints = value;
            }
        }

        public bool HasHealthIssues
        {
            get { return hasHealthIssues; }
            private set { hasHealthIssues = value; }
        }

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            caugthFish.Add(fish.Name);
            CompetitionPoints = Math.Round(competitionPoints + fish.Points, 1);
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            HasHealthIssues = !HasHealthIssues;
        }
        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {caugthFish.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
