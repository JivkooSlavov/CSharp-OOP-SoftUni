using _04.WildFarm.Entities.Animals;
using _04.WildFarm.Entities.Foods;

namespace _04.WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>();
            string command = "";
            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] animalInfo = command.Split();
                    string[] foodInfo = Console.ReadLine().Split();

                    string type = animalInfo[0];
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);

                    IAnimal animal = null;
                    if (type == "Cat" || type == "Tiger")
                    {
                        string livingRegion = animalInfo[3];
                        string breed = animalInfo[4];

                        if (type == "Cat")
                        {
                            animal = new Cat(name, weight, livingRegion, breed);
                        }
                        else
                        {
                            animal = new Tiger(name, weight, livingRegion, breed);
                        }
                    }
                    else if (type == "Hen" || type == "Owl")
                    {
                        double wingSizes = double.Parse(animalInfo[3]);
                        if (type == "Hen")
                        {
                            animal = new Hen(name, weight, wingSizes);
                        }
                        else
                        {

                            animal = new Owl(name, weight, wingSizes);
                        }
                    }
                    else
                    {
                        string livingRegion = animalInfo[3];

                        if (type == "Dog")
                        {
                            animal = new Dog(name, weight, livingRegion);
                        }
                        else
                        {
                            animal = new Mouse(name, weight, livingRegion);
                        }
                    }
                    Console.WriteLine(animal.ProduceSound());
                    animals.Add(animal);

                    string foodType = foodInfo[0];
                    int qty = int.Parse(foodInfo[1]);

                    IFood food = null;
                    if (foodType == "Vegetable")
                    {
                        food = new Vegetable(qty);
                    }
                    else if (foodType == "Meat")
                    {
                        food = new Meat(qty);
                    }
                    else if (foodType == "Fruit")
                    {
                        food = new Fruit(qty);
                    }
                    else
                    {
                        food = new Seeds(qty);
                    }
                    animal.Eat(food);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}