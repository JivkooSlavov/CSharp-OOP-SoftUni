using Raiding.Core;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();
IHeroFactory heroFactory = new HeroFactory();

IEngine engine = new Engine(reader, writer, heroFactory);

engine.Run();