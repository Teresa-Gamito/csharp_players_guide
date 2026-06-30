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
    1 => sieve.IsEven,
    2 => sieve.IsPositive,
    3 => sieve.IsMultipleOf10,
    _ => sieve.IsEven
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

    public bool IsEven(int number) => number % 2 == 0;
    public bool IsPositive(int number) => number > 0;
    public bool IsMultipleOf10(int number) => number % 10 == 0;
}
