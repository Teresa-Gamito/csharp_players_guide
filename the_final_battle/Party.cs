using Players;


public class Party
{
    public List<Character> Members { get; } = new();
    public List<Item> Items { get; } = new();

    public bool IsDefeated => Members.Count == 0;

    public Party(params Character[] members)
    {
        foreach (Character character in members)
        {
            Members.Add(character);
        }
    }

    public void Battle(Party enemyParty)
    {
        foreach (Character member in Members)
        {
            Console.WriteLine();
            Console.WriteLine($"It is {member.Name}'s turn...");
            member.Battle(Player, enemyParty);
            if (IsDefeated) return;
        }
    }
}

public class MonsterParty1 : Party
{
    public MonsterParty1(Player player) : base(player) 
    {
        Members.Add(new Skeleton());
        Items.Add(new HealthPotion());
    }
}

public class MonsterParty2 : Party
{
    public MonsterParty2(Player player) : base(player)
    {
        Members.Add(new Skeleton());
        Members.Add(new Skeleton());
        Items.Add(new HealthPotion());
    }
}

public class UncodedOneParty : Party
{
    public UncodedOneParty(Player player) : base(player)
    {
        Members.Add(new UncodedOne());
        Items.Add(new HealthPotion());
    }
}

public class HeroParty : Party
{
    public HeroParty(Player player, string name) : base(player)
    {
        Members.Add(new TrueProgrammer(name));
        Items.Add(new HealthPotion());
        Items.Add(new HealthPotion());
        Items.Add(new HealthPotion());
    }
}
