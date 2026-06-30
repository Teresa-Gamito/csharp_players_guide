using Players;
using Entities.Characters;

namespace Entities
{

public class Party
{
    public Player Player { get; }
    public List<Character> Members { get; } = new List<Character>();

    public bool IsDefeated => Members.Count == 0;

    public Party(Player player, params Character[] members)
    {
        Player = player;

        foreach (Character character in members)
        {
            Members.Add(character);
        }
    }

    public void DisplayMembers()
    {
        int i = 0;
        foreach (Character member in Members)
        {
            Console.WriteLine($"{i} - {member.Name}");
            i++;
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
    public MonsterParty1(Player player) : base(player, new Skeleton()) {}
}

public class MonsterParty2 : Party
{
    public MonsterParty2(Player player) : base(player, new Skeleton(), new Skeleton()) {}
}

public class UncodedOneParty : Party
{
    public UncodedOneParty(Player player) : base(player, new UncodedOne()) {}
}

public class HeroParty : Party
{
    public HeroParty(Player player, string name) : base(player, new TrueProgrammer(name)) {}
}

}

