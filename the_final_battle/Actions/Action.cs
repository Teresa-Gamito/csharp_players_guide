namespace FinalBattle.Actions;

using FinalBattle.Characters;
using FinalBattle.Attacks;

public interface IAction
{
    public void Run(Character user, Character target);
}

public class DoNothingAction : IAction
{
    public void Run(Character user, Character target)
    {
        Console.WriteLine(user.Name + " did NOTHING");
    }
}

public class AttackAction : IAction
{
    public void Run(Character user, Character target)
    {
        IAttack attack = user.Attack;
        int damage = attack.GetData().Damage;
        target.Damage(damage);
        Console.WriteLine($"{user.Name} used {attack.Name} on {target.Name}.");
        Console.WriteLine($"{attack.Name} dealt {damage} damage to {target.Name}.");
        Console.WriteLine($"{target.Name} is now at {target.HP}/{target.MaxHP} HP");
    }
}
