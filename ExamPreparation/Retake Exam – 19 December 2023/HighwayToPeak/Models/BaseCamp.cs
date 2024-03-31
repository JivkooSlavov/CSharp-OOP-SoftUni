using HighwayToPeak.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public class BaseCamp : IBaseCamp
    {
        private SortedSet<string> allClimbers;
        public IReadOnlyCollection<string> Residents => allClimbers;
        public BaseCamp()
        {
             allClimbers= new SortedSet<string>();
        }

        public void ArriveAtCamp(string climberName)
        {
            allClimbers.Add(climberName);
        }

        public void LeaveCamp(string climberName)
        {
            allClimbers.Remove(climberName);
        }
    }
}
