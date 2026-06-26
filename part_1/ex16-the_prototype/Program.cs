string input;

int target;
while (true)
{
    Console.Write("User 1, enter a number between 0 and 100: ");
    input = Console.ReadLine();
    target = Convert.ToInt32(input);
    if (target < 0 || target > 100)
    {
        Console.WriteLine("Invalid number!");
    }
    else break;
}

Console.Clear();

Console.WriteLine("User 2, guess the number.");
int guess;
while (true)
{
    Console.Write("What is your next guess? ");
    input = Console.ReadLine();
    guess = Convert.ToInt32(input);

    if (guess < target)
    {
        Console.WriteLine(guess + " is too low.");
    }
    else if (guess > target)
    {
        Console.WriteLine(guess + " is too high.");
    }
    else
    {
        Console.WriteLine("You guessed the number!");
        break;
    }
}
