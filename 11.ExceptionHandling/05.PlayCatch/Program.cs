namespace _05.PlayCatch
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int countOfExceptions = 0;

            while (countOfExceptions < 3)
            {
                string[] currentInput = Console.ReadLine().Split();
                string command = currentInput[0];

                try
                {
                    if (command == "Replace")
                    {
                        int firstIndex = int.Parse(currentInput[1]);
                        int element = int.Parse(currentInput[2]);

                        input[firstIndex] = element;
                    }
                    else if (command == "Show")
                    {
                        int firstIndex = int.Parse(currentInput[1]);
                        Console.WriteLine(input[firstIndex]);
                    }
                    else if (command == "Print")
                    {
                        int firstIndex = int.Parse(currentInput[1]);
                        int secondIndex = int.Parse(currentInput[2]);   

                        if (firstIndex<0 || firstIndex>=input.Length 
                            || secondIndex<0 || secondIndex>=input.Length)
                        {
                            throw new IndexOutOfRangeException();
                        }
                        for (int i = firstIndex; i <= secondIndex -1 ; i++)
                        {
                            Console.Write(input[i] + ", ");
                        }
                        Console.WriteLine(input[secondIndex]);
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("The index does not exist!");
                    countOfExceptions++;
                }
                catch(FormatException ex)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    countOfExceptions++;
                }
            }
            Console.WriteLine(string.Join(", ", input));
        }
    }
}