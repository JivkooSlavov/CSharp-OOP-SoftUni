namespace Raiding.Core
{
    public interface IHeroFactory
    {
        IHero Create(string type, string name);
    }
}
