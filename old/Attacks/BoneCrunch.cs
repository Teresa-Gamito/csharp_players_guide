using Characters;

namespace Attacks;

public class BoneCrunch : Attack
{
    Random _random = new();

    public override string Name { get; } = "BONE CRUNCH";
    public override int Damage { get; } = 1;

    public override void Execute(Character target)
    {
        target.Damage(_random.Next(Damage + 1));

        Console.WriteLine($"{Name} dealt {Damage} to {target.Name}.");
        Console.WriteLine($"{target.Name} is now at {target.HP}/{target.MaxHP}.");
    }
}

