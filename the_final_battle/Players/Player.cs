namespace FinalBattle.Players;

using FinalBattle.Actions;
using FinalBattle.Attacks;
using FinalBattle.Characters;
using FinalBattle.Parties;
using FinalBattle.Items;
using FinalBattle.Battle;

public interface IPlayer
{
    public string GetPlayerName();

    public IAction ChooseAction(Character character, Battle battle);
    public Character ChooseCharacter(Party party);
    public IAttack ChooseAttack(Character character);
    public IItem ChooseItem(Party party);
}

public class PlayerAI : IPlayer
{
    private Random _random = new Random();

    public string GetPlayerName()
    {
        return "AI";
    }

    public IAction ChooseAction(Character character, Battle battle)
    {
        Thread.Sleep(1000);
        Party party = battle.GetCharacterParty(character);
        if (character.HP <= character.MaxHP / 4 && party.Items.Count > 0)
        {
            return new UseItemAction();
        }
        return new AttackAction();
    }

    public Character ChooseCharacter(Party party) 
    {
        Character lowHPCharacter = party.Characters[0];
        foreach (Character character in party.Characters)
        {
            if (character.HP < lowHPCharacter.HP )
            {
                lowHPCharacter = character;
            }
        }
        return lowHPCharacter;
    }

    public IAttack ChooseAttack(Character character) 
    {
        return ChooseRandom(character.Attacks);
    }

    public IItem ChooseItem(Party party)
    {
        return ChooseRandom(party.Items);
    }

    private T ChooseRandom<T>(List<T> list)
    {
        int optionCount = list.Count;
        int index = _random.Next(optionCount);
        return list[index];
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

    public IAction ChooseAction(Character user, Battle battle)
    {
        Party party = battle.GetCharacterParty(user);
        bool hasItem = party.Items.Count > 0;
        Console.WriteLine($"1 - Attack");
        if (hasItem) Console.WriteLine($"2 - Use item");
        Console.WriteLine($"3 - Do nothing");
        Console.Write("What do you want to do? ");
        string input = Console.ReadLine()!;
        Console.WriteLine();
        return input switch
        {
            "1" => new AttackAction(),
            "2" => hasItem ? new UseItemAction() : ChooseAction(user, battle),
            "3" => new DoNothingAction(),
            _ => ChooseAction(user, battle)
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
        int option = Convert.ToInt32(input);
        Console.WriteLine();
        return party.Characters[option - 1];
    }

    public IAttack ChooseAttack(Character character)
    {
        int i = 1;
        foreach (IAttack attack in character.Attacks)
        {
            Console.WriteLine($"{i} - {attack.Name}");
            i++;
        }
        Console.Write("What do you want to do? ");
        string input = Console.ReadLine()!;
        int option = Convert.ToInt32(input);
        Console.WriteLine();
        return character.Attacks[option - 1];
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

    public IItem ChooseItem(Party party)
    {
        int i = 1;
        foreach (IItem item in party.Items)
        {
            Console.WriteLine($"{i} - {item.Name}");
            i++;
        }
        Console.Write("Which item do you want to use? ");
        string input = Console.ReadLine()!;
        int option = Convert.ToInt32(input);
        Console.WriteLine();
        return party.Items[option - 1];
    }
}
