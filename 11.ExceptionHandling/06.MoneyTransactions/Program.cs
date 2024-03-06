using System.Security.Principal;

namespace _06.MoneyTransactions
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(",");
            Dictionary<int, double> result = new Dictionary<int, double>();
            foreach (string line in input)
            {
                string[] currentLine = line.Split('-'); 
                int acc = int.Parse(currentLine[0]);
                double value = double.Parse(currentLine[1]);

                result.Add(acc, value);
            }
            string command = "";
            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] commandInfo = command.Split();
                    string commandName = commandInfo[0];
                    int acountNumber = int.Parse(commandInfo[1]);
                    double value = double.Parse((commandInfo[2]));

                    if (commandName== "Deposit")
                    {
                        result[acountNumber] += value;

                    }
                    else if (commandName == "Withdraw")
                    {
                        if (value > result[acountNumber])
                        {
                            throw new InvalidOperationException("Insufficient balance!");
                        }
                        result[acountNumber] -= value;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                    Console.WriteLine($"Account {acountNumber} has new balance: {result[acountNumber]:f2}");
                }
                catch (KeyNotFoundException ex)
                {
                    Console.WriteLine("Invalid account!");
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }

        }
    }
}
