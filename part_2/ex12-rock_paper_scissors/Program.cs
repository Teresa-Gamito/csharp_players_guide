Game game = new Game("Luni", "Tessy");

while (true)
{
    game.PlayRound();
}


public class Game
{
    public Player[] players = new Player[2];

    public Game(string player1Name, string player2Name)
    {
        players[0] = new Player(player1Name);
        players[1] = new Player(player2Name);
    }

    public void PlayRound()
    {
        players[0].Play();
        players[1].Play();
        Player.ComparePlays(players[0], players[1]);
    }
}

public class Player
{
    public string Name { get; set; } = "Player";
    public Action Action { get; private set; }

    public Player(string name)
    {
        Name = name;
    }

    public void Play()
    {
        Console.Clear();
        Console.Write($"{Name}, choose your action (rock, paper, scissors): ");
        string input = Console.ReadLine()!;
        Action = input switch
        {
            "rock" => Action.Rock,
            "paper" => Action.Paper,
            "scissors" => Action.Scissors,
            _ => Action.Rock,
        };
    }

    public static void ComparePlays(Player player1, Player player2)
    {
        Console.Clear();
        if (player1.Action == player2.Action)
        {
            Console.Write("Draw!");
        }
        else if (player1.Action == player2.Action + 1 || player1.Action == player2.Action - 2)
        {
            Console.Write($"{player1.Name} wins!");
        }
        else
        {
            Console.Write($"{player2.Name} wins!");
        }
        Console.ReadLine();
    }
}

public enum Action
{
    Rock,
    Paper,
    Scissors
}
