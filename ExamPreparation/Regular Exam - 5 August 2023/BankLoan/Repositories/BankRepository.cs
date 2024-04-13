using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private List<IBank> allBanks;
        public BankRepository()
        {
                allBanks = new List<IBank>();
        }
        public IReadOnlyCollection<IBank> Models => allBanks;

        public void AddModel(IBank model)
        {
            allBanks.Add(model);
        }

        public IBank FirstModel(string name)
        {
            return allBanks.FirstOrDefault(x=>x.Name== name); 
        }

        public bool RemoveModel(IBank model)
        {
            return allBanks.Remove(model);
        }
    }
}
