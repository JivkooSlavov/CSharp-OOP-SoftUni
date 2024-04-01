using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private List<ISupplement> _supplements;
        public SupplementRepository()
        {
             _supplements = new List<ISupplement>();
        }
        public void AddNew(ISupplement model)
        {
            _supplements.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            var findInterface = _supplements.FirstOrDefault(x=>x.InterfaceStandard == interfaceStandard);
            return findInterface;
        }

        public IReadOnlyCollection<ISupplement> Models() => _supplements.AsReadOnly();

        public bool RemoveByName(string typeName)
        {
            var firstSuplement = _supplements.FirstOrDefault(x=>x.GetType().Name == typeName);
            if (firstSuplement is null)
            {
                return false;
            }
            return true;
        }
    }
}
