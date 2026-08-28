namespace FinalBattle.Players;

using FinalBattle.Actions;
using FinalBattle.Characters;
using FinalBattle.Parties;

public interface IPlayer
{
    public string GetPlayerName();

    public IAction ChooseAction(Character character);
    public Character ChooseCharacter(Party party);
}

public class PlayerAI : IPlayer
{
    public string GetPlayerName()
    {
        return "AI";
    }

    public IAction ChooseAction(Character character)
    {
        Thread.Sleep(1000);
        return new AttackAction();
    }

    public Character ChooseCharacter(Party party)
    {
        return party.Characters[0];
    }
}

public class PlayerHuman : IPlayer
{
    public string GetPlayerName()
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine()!.ToUpper() ?? "TRUE PROGRAMMER";
        Console.WriteLine();
        return name;
    }

    public IAction ChooseAction(Character character)
    {
        Console.WriteLine($"1 - Standard attack ({character.Attack.Name})");
        Console.WriteLine($"2 - Do nothing");
        Console.Write("What do you want to do? ");
        string input = Console.ReadLine()!;
        Console.WriteLine();
        return input switch
        {
            "1" => new AttackAction(),
            "2" => new DoNothingAction(),
            _ => ChooseAction(character)
        };
    }

    public Character ChooseCharacter(Party party)
    {
        int i = 1;
        foreach (Character character in party.Characters)
        {
            Console.WriteLine($"{i} - {character.Name} ({character.HP}/{character.MaxHP})");
            i++;
        }
        Console.Write("Target: ");
        string input = Console.ReadLine()!;
        Console.WriteLine();
        int option = Convert.ToInt32(input);
        return party.Characters[option - 1];
    }

    public static (IPlayer player1, IPlayer player2) ChoosePlayers()
    {
        Console.WriteLine("Choose players: ");
        Console.WriteLine("1 - Player vs AI");
        Console.WriteLine("2 - AI vs AI");
        Console.WriteLine("3 - Player vs Player");

        Console.Write("Option: ");
        string input = Console.ReadLine()!;
        Console.WriteLine();
        return input switch
        {
            "1" => (new PlayerHuman(), new PlayerAI()),
            "2" => (new PlayerAI(), new PlayerAI()),
            "3" => (new PlayerHuman(), new PlayerHuman()),
            _ => ChoosePlayers()
        };
    }
}
