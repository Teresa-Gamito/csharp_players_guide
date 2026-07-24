using Characters;

namespace Attacks;

public class Unraveling : Attack
{
    Random _random = new();

    public override string Name { get; } = "UNRAVELING";
    public override int Damage { get; } = 2;

    public override void Execute(Character target)
    {
        target.Damage(_random.Next(Damage + 1));

        Console.WriteLine($"{Name} dealt {Damage} to {target.Name}.");
        Console.WriteLine($"{target.Name} is now at {target.HP}/{target.MaxHP}.");
    }
}
