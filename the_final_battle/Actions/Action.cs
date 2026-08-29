namespace FinalBattle.Actions;

using FinalBattle.Characters;
using FinalBattle.Attacks;
using FinalBattle.Battle;
using FinalBattle.Players;
using FinalBattle.Parties;
using FinalBattle.Items;
using FinalBattle.Gear;

public interface IAction
{
    public string ToString();
    public void Run(Character user, Battle battle);
}

public class DoNothingAction : IAction
{
    public override string ToString() => "Do nothing";

    public void Run(Character user, Battle battle)
    {
        Console.WriteLine($"{user} did NOTHING");
    }
}

public class AttackAction : IAction
{
    public override string ToString() => "Attack";

    public Character Target;
    public IAttack Attack;

    public AttackAction(Character target, IAttack attack)
    {
        Target = target;
        Attack = attack;
    }

    public void Run(Character user, Battle battle)
    {
        AttackData data = Attack.GetData();

        Random random = new Random();
        if (random.NextSingle() > data.HitChance)
        {
            Console.WriteLine($"{user} MISSED!");
            return;
        }

        Console.WriteLine($"{user} used {Attack} on {Target}.");

        if (Target.HasModifier)
        {
            data = Target.Modifier!.Modify(data);
        }

        Target.Damage(data.Damage);
        Console.WriteLine($"{Attack} dealt {data.Damage} damage to {Target}.");
        Console.WriteLine($"{Target} is now at {Target.HP}/{Target.MaxHP} HP");

        if (!Target.IsDefeated) return;

        Party party = battle.GetCharacterParty(Target);

        if (battle.ActiveParty == battle.Heroes)
        {
            if (Target.HasGear) battle.ActiveParty.Loot(Target.Gear!);
        }
        party.Characters.Remove(Target);
        Console.WriteLine(Target + " has been defeated!");
        Console.WriteLine();
    }
}

public class UseItemAction : IAction
{
    public override string ToString() => "Use item";

    public IItem Item { get; }

    public UseItemAction(IItem item)
    {
        Item = item;
    }

    public void Run(Character user, Battle battle)
    {
        Party party = battle.GetCharacterParty(user);
        IPlayer player = party.Player;

        Console.WriteLine($"{user} used {Item}");

        Item.Use(user);
        party.Items.Remove(Item);
    }
}

public class EquipGearAction : IAction
{
    public override string ToString() => "Equip gear";

    public IGear Gear { get; }

    public EquipGearAction(IGear gear)
    {
        Gear = gear;
    }

    public void Run(Character user, Battle battle)
    {
        Party party = battle.GetCharacterParty(user);
        IPlayer player = party.Player;

        party.UnequipedGear.Remove(Gear);

        IGear? oldGear = user.EquipGear(Gear);

        if (oldGear != null)
        {
            party.UnequipedGear.Add(oldGear);
            Console.WriteLine($"{user} unequiped {oldGear}");
        }

        Console.WriteLine($"{user} equiped {Gear}");
        Console.WriteLine();
    }
}
