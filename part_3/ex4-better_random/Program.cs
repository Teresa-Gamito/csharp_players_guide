Random random = new Random();
double randomDouble = random.NextDouble(10);
string randomDirection = random.NextString("Up", "Down", "Left", "Right");
bool randomCoin = random.CoinFlip(0.7);

Console.WriteLine($"Random double: {randomDouble}");
Console.WriteLine($"Random direction: {randomDirection}");
Console.WriteLine($"Random coin: {randomCoin}");

public static class RandomExtensions
{
    public static double NextDouble(this Random random, double max) => 
        random.NextDouble() * max;

    public static string NextString(this Random random, params string[] words) => 
        words[random.Next(words.Length)];

    public static bool CoinFlip(this Random random, double chance = 0.5) =>
        random.NextDouble() < chance;
}
