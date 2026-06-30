Sieve sieve = new Sieve();

Console.WriteLine("Check if a number is good\n");
Console.WriteLine("Choose a filter:");
Console.WriteLine("1 - even");
Console.WriteLine("2 - positive");
Console.WriteLine("3 - multiple of 10");
Console.Write("Option: ");

string? input;

input = Console.ReadLine();
int filterNumber = Convert.ToInt32(input);

Predicate<int> filter = filterNumber switch
{
    2 => x => x > 0,
    3 => x => x % 10 == 0,
    _ => x => x % 2 == 0
};

Console.WriteLine("Provide the numbers to check");
while (true)
{
    input = Console.ReadLine();
    int number = Convert.ToInt32(input);
    Console.WriteLine($"Is good - {sieve.IsGood(number, filter)}");
}

public class Sieve
{
    public bool IsGood(int number, Predicate<int> func) => func(number);
}
