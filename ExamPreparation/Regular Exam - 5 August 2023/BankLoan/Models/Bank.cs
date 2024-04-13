using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private List<ILoan> allLoans;
        private List<IClient> allClients;

        protected Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            allClients = new List<IClient>();
            allLoans    = new List<ILoan>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }
                name = value;
            }
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<ILoan> Loans => allLoans.AsReadOnly();

        public IReadOnlyCollection<IClient> Clients => allClients.AsReadOnly();

        public void AddClient(IClient Client)
        {
            if (Clients.Count< Capacity)
            {
                allClients.Add(Client);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }
        }
        public void RemoveClient(IClient Client)
        {
            allClients.Remove(Client);
        }


        public void AddLoan(ILoan loan)
        {
            allLoans.Add(loan);
        }

        public double SumRates()
        {
            if (allLoans.Count==0)
            {
                return 0;
            }
            return double.Parse(allLoans.Select(x=>x.InterestRate).Sum().ToString());
        }
        public string GetStatistics()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Name: {Name}, Type: {GetType().Name}");
            if (allClients.Count==0)
            {
                sb.AppendLine("Clients: none");
            }
            else
            {
                sb.AppendLine($"Clients: {string.Join(", ", allClients.Select(c=>c.Name))}");
            }
            sb.AppendLine($"Loans: {allLoans.Count}, Sum of Rates: {SumRates()}");
            return sb.ToString().Trim();
        }

    }
}
