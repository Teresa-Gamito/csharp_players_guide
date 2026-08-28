namespace FinalBattle.Actions;

using FinalBattle.Characters;
using FinalBattle.Attacks;
using FinalBattle.Battle;
using FinalBattle.Players;
using FinalBattle.Parties;
using FinalBattle.Items;

public interface IAction
{
    public string Name { get; }
    public void Run(Character user, Battle battle);
}

public class DoNothingAction : IAction
{
    public string Name { get; } = "Do nothing";

    public void Run(Character user, Battle battle)
    {
        Console.WriteLine(user.Name + " did NOTHING");
    }
}

public class AttackAction : IAction
{
    public string Name { get; } = "Attack";

    public void Run(Character user, Battle battle)
    {
        Party party = battle.GetCharacterParty(user);
        IPlayer player = party.Player;
        Character target = player.ChooseCharacter(battle.GetOpposingParty(user));

        IAttack attack = player.ChooseAttack(user);
        int damage = attack.GetData().Damage;

        target.Damage(damage);
        Console.WriteLine($"{user.Name} used {attack.Name} on {target.Name}.");
        Console.WriteLine($"{attack.Name} dealt {damage} damage to {target.Name}.");
        Console.WriteLine($"{target.Name} is now at {target.HP}/{target.MaxHP} HP");
    }
}

public class UseItemAction : IAction
{
    public string Name { get; } = "Use item";

    public void Run(Character user, Battle battle)
    {
        Party party = battle.GetCharacterParty(user);
        IPlayer player = party.Player;

        IItem item = player.ChooseItem(party);
        Character target = player.ChooseCharacter(party);

        Console.WriteLine($"{user.Name} used {item.Name} on {target.Name}.");

        item.Use(target);
        party.Items.Remove(item);
    }
}
