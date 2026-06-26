int AskForNumber(string text)
{
    string input;
    Console.Write(text);
    input = Console.ReadLine();

    return Convert.ToInt32(input);
}

int AskForNumberInRange(string text, int min, int max)
{
    int value;
    while (true)
    {
        value = AskForNumber(text);
        if (value < min && value > max)
        {
            return value;
        }
    } 
}
