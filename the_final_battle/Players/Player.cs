namespace FinalBattle.Players;

using FinalBattle.Actions;
using FinalBattle.Attacks;
using FinalBattle.Characters;
using FinalBattle.Parties;
using FinalBattle.Items;
using FinalBattle.Gear;
using FinalBattle.GameConsole;
using FinalBattle.Battle;

public interface IPlayer
{
    public string GetPlayerName();

    public IAction ChooseAction(Character character, Battle battle);
    public Character ChooseCharacter(Party party);
    public IAttack ChooseAttack(Character character);
    public IItem ChooseItem(Party party);
    public IGear ChooseGear(Party party);
}

public class PlayerAI : IPlayer
{
    private Random _random = new Random();
    private int _speed = 500;
    private float _chooseItemChance = 0.25f;
    private float _chooseGearChance = 0.5f;

    public string GetPlayerName()
    {
        return "AI";
    }

    public T ChooseRandom<T>(List<T> list)
    {
        return list[_random.Next(list.Count - 1)];
    }

    public IAction ChooseAction(Character character, Battle battle)
    {
        Thread.Sleep(_speed);

        Party party = battle.GetCharacterParty(character);

        if (character.HP <= character.MaxHP / 4 && party.Items.Count > 0)
        {
            if (_random.NextSingle() < _chooseItemChance)
            {
                IItem item = ChooseItem(party);
                return new UseItemAction(item);
            }
        }

        if (party.UnequipedGear.Count > 0 && !character.HasGear)
        {
            if (_random.NextSingle() < _chooseGearChance)
            {
                IGear gear = ChooseGear(party);
                return new EquipGearAction(gear);
            }
        }

        Party opposingParty = battle.GetOpposingParty(character);
        Character target = ChooseCharacter(opposingParty);
        IAttack attack = ChooseAttack(character);
        return new AttackAction(target, attack);
    }

    public Character ChooseCharacter(Party party) 
    {
        return ChooseRandom(party.Characters);
        
        // Character lowHPCharacter = party.Characters[0];
        // foreach (Character character in party.Characters)
        // {
        //     if (character.HP < lowHPCharacter.HP )
        //     {
        //         lowHPCharacter = character;
        //     }
        // }
        // return lowHPCharacter;
    }

    public IAttack ChooseAttack(Character character)
    {
        if (character.HasGear)
        {
            return character.Gear!.Attack;
        }
        return character.Attack;
    }

    public IItem ChooseItem(Party party) => ChooseRandom(party.Items);

    public IGear ChooseGear(Party party) => ChooseRandom(party.UnequipedGear);

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


    public IAction ChooseAction(Character character, Battle battle)
    {
        Party party = battle.GetCharacterParty(character);

        bool hasItem = party.Items.Count > 0;
        bool hasGear = party.UnequipedGear.Count > 0;

        Console.WriteLine("1 - Attack");
        Console.WriteLine("2 - Do nothing");
        if (hasItem) Console.WriteLine("3 - Use item");
        if (hasGear) Console.WriteLine("4 - Equip gear");

        Console.Write("What do you want to do? ");
        string? input = Console.ReadLine();
        Console.WriteLine();

        switch (input)
        {
            case "1":
                Party opposingParty = battle.GetOpposingParty(character);
                Character target = ChooseCharacter(opposingParty);
                IAttack attack = ChooseAttack(character);
                return new AttackAction(target, attack);

            case "2":
                return new DoNothingAction();

            case "3":
                if (!hasItem) return ChooseAction(character, battle);
                IItem item = ChooseItem(party);
                return new UseItemAction(item);

            case "4":
                if (!hasGear) return ChooseAction(character, battle);
                IGear gear = ChooseGear(party);
                return new EquipGearAction(gear);

            case null:
            default:
                return ChooseAction(character, battle);
        }
    }

    public Character ChooseCharacter(Party party)
    {
        return Choose("Which character do you want to target? ", party.Characters);
    }

    public IAttack ChooseAttack(Character character)
    {
        List<IAttack> options = new List<IAttack>();
        options.Add(character.Attack);
        if (character.HasGear) options.Add(character.Gear!.Attack);

        return Choose("Which attack do you want to use? ", options);
    }

    public IItem ChooseItem(Party party)
    {
        return Choose("Which item do you want to use? ", party.Items);
    }

    public IGear ChooseGear(Party party)
    {
        return Choose("Which gear do you want to equip? ", party.UnequipedGear);
    }

    public T Choose<T>(string prompt, List<T> list)
    {
        GameConsole.DisplayOptions(list);
        return GameConsole.ChooseOption(prompt, list);
    }
}
