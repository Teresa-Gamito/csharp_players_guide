using Entities;
using Players;

namespace TheFinalBattle
{

public class Game
{
    public Player PlayerHero { get; private set; }
    public Player PlayerMonster { get; private set; }

    public Party HeroParty { get; private set; }
    public Queue<Party> MonsterPartyQueue { get; private set; } = new();
    public Party CurrentMonsterParty => MonsterPartyQueue.First();

    public Game()
    {
        Console.WriteLine("Welcome to the Final Battle!");
        Console.WriteLine();

        (PlayerHero, PlayerMonster) = GetPlayers();

        HeroParty = new HeroParty(PlayerHero, GetName());

        MonsterPartyQueue.Enqueue(new MonsterParty1(PlayerMonster));
        MonsterPartyQueue.Enqueue(new MonsterParty2(PlayerMonster));
        MonsterPartyQueue.Enqueue(new UncodedOneParty(PlayerMonster));
    }

    private (Player heroPlayer, Player monsterPlayer) GetPlayers()
    {
        Console.WriteLine("Choose the players: ");
        Console.WriteLine("0 - Heroes: Player | Monsters: Computer");
        Console.WriteLine("1 - Heroes: Computer | Monsters: Computer");
        Console.WriteLine("2 - Heroes: Player | Monsters: Player");

        Console.Write("Option: ");
        string input = Console.ReadLine()!;
        int option = int.Parse(input);
        Console.WriteLine();

        return option switch
        {
            0 => (new HumanPlayer(), new AIPlayer()),
            1 => (new AIPlayer(), new AIPlayer()),
            _ => (new HumanPlayer(), new HumanPlayer())
        };
    }

    private string GetName()
    {
        Console.Write("What is your name? ");
        return Console.ReadLine()!;
    }

    public bool Run()
    {
        Battle battle = new Battle(HeroParty, CurrentMonsterParty);
        Party winningParty = battle.RunBattle();

        if (winningParty == HeroParty)
        {
            MonsterPartyQueue.Dequeue();
            if (MonsterPartyQueue.Count == 0)
            {
                Console.WriteLine("The hero's party won! The Uncoded One's army was destroyed!");
                return false;
            }
            else
            {
                Console.WriteLine("Enemy party was defeated!");
                return true;
            }
        }
        else
        {
            Console.WriteLine("The hero's party was defeated! The Uncoded One's army prevails...");
            return false;
        }
    }
}

}
