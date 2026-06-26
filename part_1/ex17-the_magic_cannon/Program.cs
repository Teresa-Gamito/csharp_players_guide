for (int i = 0; i < 100; i++)
{
    string attackType;

    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        attackType = "Electric and Fire";
    }
    else if (i % 3 == 0) 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        attackType = "Fire";
    }
    else if (i % 5 == 0) 
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        attackType = "Electric";
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.White;
        attackType = "Normal";
    }

    Console.WriteLine($"{i + 1}: {attackType}");
}
