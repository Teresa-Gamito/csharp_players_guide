Game game = new Game();
Player player1 = new Player("Luni");
Player player2 = new Player("Tessy");

while (true)
{
    try
    {
        game.PlayRound(player1, player2);
    }
    catch
    {
        Console.WriteLine("You ate the raisin cookie! You lost :(");
        return;
    }

}

public class Game
{
    public int MaxCookies { get; }
    private int RaisinCookie { get; }
    private List<int> _eatenCookies = new List<int>();

    public Game(int maxCookies = 10)
    {
        MaxCookies = maxCookies;
        Random random = new Random();
        RaisinCookie = random.Next(MaxCookies);
    }

    public bool PlayTurn(Player player)
    {
        while (true)
        {
            Console.Write($"{player.Name}, choose a cookie (0 - {MaxCookies}): ");

            string? input = Console.ReadLine();
            int cookie = Convert.ToInt32(input);

            if (WasCookieEaten(cookie))
            {
                Console.WriteLine("That cookie was already eaten, choose again.");
                continue;
            }

            bool isRaisinCookie = EatCookie(cookie);
            if (isRaisinCookie)
            {
                throw new RaisinCookieException();
                //return false;
            }
            Console.WriteLine("You ate a chocolate cookie!\n");
            return true;
        }
    }

    public bool PlayRound(params Player[] players)
    {
        foreach (Player player in players)
        {
            if (PlayTurn(player) == false) return false;
        }
        return true;
    }

    public bool WasCookieEaten(int cookie) => _eatenCookies.Contains(cookie);

    public bool EatCookie(int cookie)
    {
        _eatenCookies.Add(cookie);
        return cookie == RaisinCookie;
    }
}

public class Player
{
    public string Name { get; }
    public Player(string name) => Name = name;
}

public class RaisinCookieException : Exception
{
    public RaisinCookieException() {}
    public RaisinCookieException(string message) : base(message) {}
}
