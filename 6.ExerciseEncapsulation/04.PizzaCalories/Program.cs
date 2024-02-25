using _04.PizzaCalories;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] inputPizza = Console.ReadLine().Split();
        string name = inputPizza[1];

        string[] inputDough = Console.ReadLine().Split();
        string type = inputDough[0];
        string flourType = inputDough[1];
        string backingTechnique = inputDough[2];
        int weight = int.Parse(inputDough[3]);
        try
        {


            Dough dough = new Dough(flourType, backingTechnique, weight);
            Pizza pizza = new Pizza(name, dough);

            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                string[] toppingInfo = input.Split();
                string toppingType = toppingInfo[1];
                int toppingWeight = int.Parse(toppingInfo[2]);

                Topping topping = new Topping(toppingType, toppingWeight);
                pizza.AddTopping(topping);
            }

            Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
    }
}