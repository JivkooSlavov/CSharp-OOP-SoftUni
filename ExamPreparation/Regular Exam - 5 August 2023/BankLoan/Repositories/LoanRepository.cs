using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        private List<ILoan> allModels;
        public LoanRepository()
        {
                allModels = new List<ILoan>();
        }
        public IReadOnlyCollection<ILoan> Models => allModels.AsReadOnly();

        public void AddModel(ILoan model)
        {
            allModels.Add(model);
        }

        public ILoan FirstModel(string name)
        {
            return allModels.FirstOrDefault(x=>x.GetType().Name==name);
        }

        public bool RemoveModel(ILoan model)
        {
            return allModels.Remove(model);
        }
    }
}
