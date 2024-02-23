using Animals;

namespace Animals;

public class StartUp
{
    public static void Main(string[] args)
    {
        while (true)
        {
            string type =  Console.ReadLine();
            if (type == "Beast!")
            {
                break;
            }
            string[] animalInfo = Console.ReadLine().Split().ToArray();

            string name = animalInfo[0];
            int age = int.Parse(animalInfo[1]);
            if (age<0)
            {
                Console.WriteLine("Invalid input");
                continue;
            }
            Animal animal = default; // null;
            if (type == "Cat")
            {
                animal = new Cat(name, age, animalInfo[2]);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, age, animalInfo[2]);
            }
            else if (type == "Frog")
            {
                animal = new Frog(name, age, animalInfo[2]);

            }
            else if (type == "Kitten")
            {
                animal = new Kitten(name, age);
            }
            else if (type == "Tomcat")
            {
                animal = new Tomcat(name, age);
            }
            Console.WriteLine(type);
            Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
            Console.WriteLine(animal.ProduceSound());
        }
    }
}