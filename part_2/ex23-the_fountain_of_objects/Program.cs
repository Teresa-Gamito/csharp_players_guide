using Caverns;
using Entities;


FountainGame game = new FountainGame();
while (game.PlayRound());


public class FountainGame
{
    private Player _player;
    private Cavern _cavern;

    private bool IsGameWon => _cavern.IsFountainActive && _cavern.IsEntrance(_player.Position);

    public FountainGame()
    {
        Console.Clear();
        Console.WriteLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search of the Fountain of Objects\nLight is visible only in the entrance, and no other light is seen anywhere in the caverns\nYou must navigate the Caverns with your other senses\nFind the Fountain of Objects, activate it, and return to the entrance.\nLook out for pits. You will feel a breeze if a pit is in an adjacent room. If you enter a room with a pit, you will die.\nMaelstroms are violent forces of sentient wind. Entering a room with onr could transport you to any other location in the caverns. You will be able to hear their growling and groaning in nearby rooms.\nAmaroks roam the caverns. Encountering one is certain death, but you can smell their rotten stench in nearby rooms.\nYou carry with you a bow and a quiver of arrows. You can use them to shoot monsters in the caverns but be warned: you have a limited supply.\nType 'help' for a list of commands");
        Console.WriteLine();

        Console.WriteLine("Choose a cave size:");
        Console.WriteLine("1 - 4x4");
        Console.WriteLine("2 - 6x6");
        Console.WriteLine("3 - 8x8");
        Console.Write("Option: ");
        string input = Console.ReadLine()!;
        int option = Convert.ToInt32(input);

        Position entrance = new Position(0, 0);
        _cavern = option switch
        {
            1 => new Cavern4x4(),
            2 => new Cavern6x6(),
            3 => new Cavern8x8(),
            _ => new Cavern4x4()
        };

        _player = new Player(entrance);
    }

    public bool PlayRound()
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"You are in the room at {_player.Position.ToString()}.");
        Console.WriteLine($"You have {_player.ArrowCount} arrows left.");

        while (_cavern.HasMaelstrom(_player.Position))
        {
            Maelstrom maelstrom = (Maelstrom)_cavern.GetMonsterAt(_player.Position)!;

            maelstrom.Attack(_player);
            _cavern.Wrap(_player);
            _cavern.Wrap(maelstrom);

            Console.WriteLine($"You got attacked by a maelstrom! You moved to {_player.Position.ToString()}");
        }

        if (_cavern.IsPit(_player.Position))
        {
            Console.WriteLine("You fell into a pit. You died :(");
            return false;
        }

        if (_cavern.HasAmarok(_player.Position))
        {
            Console.WriteLine("You were attacked by an amarok. You died :(");
            return false;
        }

        if (IsGameWon)
        {
            Console.WriteLine("The Fountain of Objects has been reactivated, and you escaped with your life!");
            Console.WriteLine("You win! :3");
            return false;
        }

        if (_cavern.HasPitAdjacent(_player.Position))
        {
            Console.WriteLine("You feel a draft. There is a pit in a nearby room.");
        }

        if (_cavern.HasMaelstromAdjacent(_player.Position))
        {
            Console.WriteLine("You hear the growling and groaning of a maelstrom nearby.");
        }

        if (_cavern.HasAmarokAdjacent(_player.Position))
        {
            Console.WriteLine("You can smell the rotten stench of an amarok in a nearby room.");
        }

        if (_cavern.IsFountain(_player.Position))
        {
            if (_cavern.IsFountainActive)
            {
                Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
            }
            else
            {
                Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
            }
        }

        if (_cavern.IsEntrance(_player.Position))
        {
            Console.WriteLine("You see light coming from the cavern entrance.");
        }

        Command();

        return true;
    }

    private void Command()
    {
        Console.WriteLine("What do you want to do? ");
        string? input = Console.ReadLine();
        switch (input)
        {
            case "activate fountain": ActivateFountain(); break;

            case "move north": _player.Move(_player.Position.North); break;
            case "move south": _player.Move(_player.Position.South); break;
            case "move east": _player.Move(_player.Position.East); break;
            case "move west": _player.Move(_player.Position.West); break;

            case "shoot north": PlayerShoot(_player.Position.North); break;
            case "shoot south": PlayerShoot(_player.Position.South); break;
            case "shoot east": PlayerShoot(_player.Position.East); break;
            case "shoot west": PlayerShoot(_player.Position.West); break;

            case "help": DisplayCommands(); break;
        }
        _cavern.Clamp(_player);
    }

    private void DisplayCommands()
    {
        Console.WriteLine("\n'move < north | south | east | west >' - move one room in that direction\n'shoot < north | south | east | west >' - shoot an arrow in the room in that direction\n'activate fountain' - activates the Fountain of Objects if you are in the room containing it\n'help' - displays the available commands\n");
    }

    private void ActivateFountain()
    {
        if (!_cavern.IsFountainActive && _cavern.IsFountain(_player.Position))
        {
            _cavern.ActivateFountain();
        }
    }
    private void PlayerShoot(Position position)
    {
        if (!_player.HasArrows()) return;

        _player.ShootArrow();

        Monster? monster = _cavern.GetMonsterAt(position);
        if (monster == null) return;
        Console.WriteLine($"You killed a {monster.ToString()}!");
        _cavern.KillMonster(monster);
    }
}
