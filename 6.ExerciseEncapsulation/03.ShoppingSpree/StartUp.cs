using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> peopleKvP = new Dictionary<string, Person>();
            Dictionary<string, Product> productsKvP = new Dictionary<string, Product>();

            string[] people = Console.ReadLine().
                 Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
            string[] products = Console.ReadLine().
                Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                for (int i = 0; i < people.Length; i+=2)
                {
                    string name = people[i];
                    decimal money = decimal.Parse(people[i + 1]);

                    Person person = new Person(name, money);
                    peopleKvP.Add(name, person);
                }
                for (int i = 0; i < products.Length; i+=2)
                {
                    string name = products[i];
                    decimal cost = decimal.Parse(products[i + 1]);
                    Product product = new Product(name, cost);

                    productsKvP.Add(name, product);
                }
                string command = "";
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] commandInfo = command.Split();
                    string personName = commandInfo[0];
                    string productName = commandInfo[1];

                    Person person = peopleKvP[personName];
                    Product product = productsKvP[productName];
                    bool isAdded = person.AddProduct(product);
                    if (!isAdded)
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");

                    }
                    else
                    {
                        Console.WriteLine($"{personName} bought {productName}");
                    }
                }
                foreach (var (name, person) in peopleKvP)
                {
                    string productInfo = person.Products.Count > 0 ? string.Join(", ", person.Products.Select(x=>x.Name)) : "Nothing bought";

                    Console.WriteLine($"{name} - {productInfo}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
