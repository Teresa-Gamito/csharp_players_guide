using Entities.Characters;

namespace Entities.Actions
{

public abstract class Attack : CharacterAction
{
    public abstract int Damage { get; set; }

    public override void Execute(Character user, Character target)
    {
        Console.WriteLine($"{user.Name} used {Name} on {target.Name}");

        target.HP -= Damage;
        if (target.HP < 0) target.HP = 0;

        Console.WriteLine($"{Name} dealt {Damage} to {target.Name}.");
        Console.WriteLine($"{target.Name} is now at {target.HP}/{target.MaxHP}.");
    }
}

}
