using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private LoanRepository loans;
        private BankRepository banks;
        private string[] bankType = new string[] { typeof(CentralBank).Name, typeof(BranchBank).Name };
        private string[] loanType = new string[] { typeof(MortgageLoan).Name, typeof(StudentLoan).Name };
        private string[] clientType = new string[] { typeof(Student).Name, typeof(Adult).Name };

        public Controller()
        {
            loans = new LoanRepository();
            banks = new BankRepository();
        }

        public string AddBank(string bankTypeName, string name)
        {
            if (!bankType.Contains(bankTypeName))
            {
                throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
            }
            IBank bank = null;
            if (bankTypeName == typeof(CentralBank).Name)
            {
              bank = new CentralBank(name);
            }
            else if (bankTypeName == typeof(BranchBank).Name)
            {
                bank = new BranchBank(name);
            }
            banks.AddModel(bank);
            return String.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
        }
        public string AddLoan(string loanTypeName)
        {

            if (!loanType.Contains(loanTypeName))
            {
                throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
            }
            ILoan loan = null;
            if (loanTypeName == typeof(MortgageLoan).Name)
            {
                loan = new MortgageLoan();
            }
            else if(loanTypeName == typeof(StudentLoan).Name)
            {
                loan = new StudentLoan();
            }
            loans.AddModel(loan);
            return String.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }
        public string ReturnLoan(string bankName, string loanTypeName)
        {
            var loan = loans.FirstModel(loanTypeName);
            if (loan == null)
            {
                string message = string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName);
                throw new ArgumentException(message);
            }
            else
            {
                var bank = banks.FirstModel(bankName);
                bank.AddLoan(loan);
                loans.RemoveModel(loan);
                return String.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
            }
        }
        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            if (!clientType.Contains(clientTypeName))
            {
                throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
            }
            var bank = banks.FirstModel(bankName);
            if (clientTypeName == "Student" && bank.GetType().Name == "CentralBank")
            {
                return string.Format(OutputMessages.UnsuitableBank);
            }
            if (clientTypeName == "Adult" && bank.GetType().Name == "BranchBank")
            {
                return string.Format(OutputMessages.UnsuitableBank);
            }
            IClient client;
            if (clientTypeName == "Student")
            {
                client = new Student(clientName, id, income);
            }
            else //Adult
            {
                client = new Adult(clientName, id, income);
            }
            bank.AddClient(client);
            return String.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);

        }

        public string FinalCalculation(string bankName)
        {
            var bank = banks.FirstModel(bankName);
            var incomeAmount = bank.Clients.Select(c => c.Income).DefaultIfEmpty(0).Sum();
            var loansAmount = bank.Loans.Select(c => c.Amount).DefaultIfEmpty(0).Sum();

            return $"The funds of bank {bankName} are {(incomeAmount + loansAmount):F2}.";

        }
        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var bank in banks.Models)
            {
                sb.AppendLine(bank.GetStatistics());
            }
            return sb.ToString().Trim();
        }
    }
}
