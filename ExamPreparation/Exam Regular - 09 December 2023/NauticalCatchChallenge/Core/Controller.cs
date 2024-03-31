using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private DiverRepository divers;
        private FishRepository fish;
        private string[] diversType = new string[] { typeof(ScubaDiver).Name, typeof(FreeDiver).Name};
        private string[] fishArray = new string[] {typeof(ReefFish).Name, typeof(DeepSeaFish).Name, typeof(PredatoryFish).Name}; 

        public Controller()
        {
            divers = new DiverRepository();
            fish = new FishRepository();
        }
        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (!diversType.Contains(diverType))
            {
                return String.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }
            if (divers.GetModel(diverName)!=null)
            {
                return String.Format(OutputMessages.DiverNameDuplication, diverName, nameof(DiverRepository));
            }
            IDiver diver = null;
            if (diverType == typeof(ScubaDiver).Name)
            {
                diver = new ScubaDiver(diverName);
            }
            else if (diverType == typeof(FreeDiver).Name)
            {
                diver = new FreeDiver(diverName);
            }
            divers.AddModel(diver);
            return String.Format(OutputMessages.DiverRegistered, diverName, nameof(DiverRepository));

        }
        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (!fishArray.Contains(fishType))
            {
                return String.Format(OutputMessages.FishTypeNotPresented, fishType);
            }
            if (fish.GetModel(fishName)!=null)
            {
                return String.Format(OutputMessages.FishNameDuplication, fishName);
            }
            IFish newFish = null;
            if (fishType == typeof(DeepSeaFish).Name)
            {
                newFish = new DeepSeaFish(fishName, points);
            }
            else if (fishType == typeof(PredatoryFish).Name)
            {
                newFish = new PredatoryFish(fishName, points);
            }
            else if (fishType == typeof(ReefFish).Name)
            {
                newFish = new ReefFish(fishName, points);
            }
            fish.AddModel(newFish);
            return String.Format(OutputMessages.FishCreated, fishName);
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            if (divers.GetModel(diverName)==null)
            {
                return String.Format(OutputMessages.DiverNotFound, nameof(DiverRepository), diverName);
            }
            if (fish.GetModel(fishName) == null)
            {
                return String.Format(OutputMessages.FishNotAllowed, fishName);
            }
            IDiver currentDiver = divers.GetModel(diverName);
            IFish currentFish = fish.GetModel(fishName);

            if (currentDiver.HasHealthIssues == true)
            {
                return String.Format(OutputMessages.DiverHealthCheck, diverName);
            }
            if (currentDiver.OxygenLevel < currentFish.TimeToCatch)
            {
                currentDiver.Miss(currentFish.TimeToCatch);
                return String.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            else if (currentDiver.OxygenLevel == currentFish.TimeToCatch)
            {
                if (isLucky)
                {
                    currentDiver.Hit(currentFish);
                    return String.Format(OutputMessages.DiverHitsFish, diverName, currentFish.Points, fishName);
                }
                else
                {
                    currentDiver.Miss(currentFish.TimeToCatch);
                    return String.Format(OutputMessages.DiverMisses, diverName, fishName);
                }
            }
            else
            {
                currentDiver.Hit(currentFish);
                return String.Format(OutputMessages.DiverHitsFish, diverName, currentFish.Points, fishName);
            }


        }

        public string HealthRecovery()
        {
           List<IDiver> healthIssueDivers = divers.Models.Where(x=>x.HasHealthIssues).ToList();

            foreach (var diver in healthIssueDivers)
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();
            }
            return String.Format(OutputMessages.DiversRecovered, healthIssueDivers.Count);
        }
        public string DiverCatchReport(string diverName)
        {
            IDiver diver = divers.GetModel(diverName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(diver.ToString());
            sb.AppendLine("Catch Report:");
            foreach (var coughtFish in diver.Catch)
            {
                sb.AppendLine(fish.GetModel(coughtFish).ToString());
            }
            return sb.ToString().Trim();
        }
        public string CompetitionStatistics()
        {
            List<IDiver> newList = divers.Models.Where(x=>x.HasHealthIssues==false).OrderByDescending(x=>x.CompetitionPoints).ThenByDescending(x=>x.Catch.Count).ThenBy(x=>x.Name).ToList();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("**Nautical-Catch-Challenge**");
            foreach (var cougthFish in newList)
            {
                sb.AppendLine(cougthFish.ToString());
            }
            return sb.ToString().Trim();
        }

    }
}
