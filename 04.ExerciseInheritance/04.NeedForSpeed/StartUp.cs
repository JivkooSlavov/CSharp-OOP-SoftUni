using NeedForSpeed;

namespace NeedForSpeed;

public class StartUp
{
    public static void Main(string[] args)
    {
        CrossMotorcycle car = new CrossMotorcycle(100, 100);
        car.Drive(9);
        Console.WriteLine(car.Fuel);
    }
}