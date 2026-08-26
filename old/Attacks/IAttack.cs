using Characters;
using Actions;

namespace Attacks;

public interface IAttack : IAction
{
    public string Name { get; }
    public int Damage { get; }

    public virtual void Execute(Character target)
    {
        target.Damage(Damage);

        Console.WriteLine($"{Name} dealt {Damage} damage to {target.Name}.");
        Console.WriteLine($"{target.Name} is now at {target.HP}/{target.MaxHP}.");
    }

    public void Run(Battle battle, Character user)
    {

    }
}
