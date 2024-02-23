using _01.Person;

public class StarUp
{
    public static void Main(string[] args)
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());

        if (age<=15)
        {
            Child person = new Child(name, age);
            Console.WriteLine(person.ToString());
        }
        else
        {
            Person person = new Person(name, age);
            Console.WriteLine(person.ToString());
        }
    }
}