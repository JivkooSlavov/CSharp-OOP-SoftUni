namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IDrawable circle = new Circle(5);
            IDrawable rectangle = new Rectangle(5, 7);

            circle.Draw();
            rectangle.Draw();
        }
    }
}