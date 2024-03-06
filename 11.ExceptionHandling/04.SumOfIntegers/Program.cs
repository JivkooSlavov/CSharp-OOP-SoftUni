namespace _04.SumOfIntegers
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int sum = 0;
            foreach (string value in input)
            {
                try
                {
                    int number = int.Parse(value);
                    sum += number;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"The element '{value}' is in wrong format!");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"The element '{value}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{value}' processed - current sum: {sum}");
                }
            }
            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}