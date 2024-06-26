﻿using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository supplements;
        private RobotRepository robots;

        public Controller()
        {
            this.supplements = new SupplementRepository();
            this.robots = new RobotRepository();
        }
        public string CreateRobot(string model, string typeName)
        {
            IRobot robot;

            if (typeName == nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
            }
            else if (typeName == nameof(IndustrialAssistant))
            {
                robot = new IndustrialAssistant(model);
            }
            else
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            this.robots.AddNew(robot);

            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            ISupplement supplement;

            if (typeName == nameof(SpecializedArm))
            {
                supplement = new SpecializedArm();
            }
            else if (typeName == nameof(LaserRadar))
            {
                supplement = new LaserRadar();
            }
            else
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }
            this.supplements.AddNew(supplement);

            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            var selectedRobots = this.robots.Models().Where(r => r.InterfaceStandards.Any(i => i == intefaceStandard)).OrderByDescending(y => y.BatteryLevel);

            if (selectedRobots.Count() == 0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            int powerSum = selectedRobots.Sum(r => r.BatteryLevel);

            if (powerSum < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - powerSum);
            }

            int usedRobotsCount = 0;

            foreach (var robot in selectedRobots)
            {
                usedRobotsCount++;

                if (totalPowerNeeded <= robot.BatteryLevel)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    break; 
                }
                else
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                }

            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, usedRobotsCount);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            var robotReportCollection = this.robots.Models().OrderByDescending(r => r.BatteryLevel).ThenBy(b => b.BatteryCapacity);

            foreach (var robot in robotReportCollection)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {
            var selectedRobots = this.robots.Models().Where(r => r.Model == model && r.BatteryLevel * 2 < r.BatteryCapacity);
            int robotsFed = 0;

            foreach (var robot in selectedRobots)
            {
                robot.Eating(minutes);
                robotsFed++;
            }

            return string.Format(OutputMessages.RobotsFed, robotsFed);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = this.supplements.Models().FirstOrDefault(x => x.GetType().Name == supplementTypeName);

            var selectedModels = this.robots.Models().Where(r => r.Model == model);
            var stillNotUpgraded = selectedModels.Where(r => r.InterfaceStandards.All(s => s != supplement.InterfaceStandard));
            var robotForUpgrade = stillNotUpgraded.FirstOrDefault();

            if (robotForUpgrade == null)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }


            robotForUpgrade.InstallSupplement(supplement);
            this.supplements.RemoveByName(supplementTypeName);

            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }
    }
}
