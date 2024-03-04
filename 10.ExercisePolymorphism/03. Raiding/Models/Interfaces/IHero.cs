namespace Raiding.Core
{
    public interface IHero
    {
        string Name { get; }

        int Power { get; }

        string CastAbility();
    }
}
