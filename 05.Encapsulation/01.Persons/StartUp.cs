namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string firstName = input[0];
                string lastName = input[1];
                int age = int.Parse(input[2]);
                Person person = new Person(firstName, lastName, age);
                persons.Add(person);
            }

            foreach (var person in persons.OrderBy(x=>x.FirstName).ThenBy(y=>y.Age))
            {
                Console.WriteLine(person);
            }
        }
    }
}
