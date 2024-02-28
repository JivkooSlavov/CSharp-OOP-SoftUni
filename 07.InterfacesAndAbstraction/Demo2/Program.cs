
using Demo3.Renderer;
using Demo3;
using Renderers;

IRenderer renderer = new ConsoleRender();
//IRenderer renderer = new ConsoleRenderer();
List<IShape> shapes = new List<IShape>();

shapes.Add(new Circle(renderer));
shapes.Add(new Circle(renderer));
shapes.Add(new Square(renderer));
shapes.Add(new Circle(renderer));
shapes.Add(new Square(renderer));
shapes.Add(new Text(renderer, "Hello"));
shapes.Add(new Text(renderer, "How are you"));

foreach (var shape in shapes)
{
    shape.Draw();
}