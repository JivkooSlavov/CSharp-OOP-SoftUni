namespace Raiding.Core
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string str) => Console.WriteLine(str);
    }
}
