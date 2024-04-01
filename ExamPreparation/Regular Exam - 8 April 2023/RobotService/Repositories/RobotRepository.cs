using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> _robots;
        public RobotRepository()
        {
            _robots = new List<IRobot>();
        }
        public void AddNew(IRobot model)
        {
            _robots.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            var findRobot = _robots.FirstOrDefault(x => x.InterfaceStandards.Any(y => y == interfaceStandard));
            return findRobot;
        }

        public IReadOnlyCollection<IRobot> Models() => _robots.AsReadOnly();

        public bool RemoveByName(string typeName)
        {
            var firstRobot = _robots.FirstOrDefault(x => x.GetType().Name == typeName);
            if (firstRobot is null)
            {
                return false;
            }
            return true;
        }
    }
}
