Console.Write("Provide a word: ");
string input = Console.ReadLine()!;

DateTime startTime = DateTime.Now;

Task<int> task = RandomlyRecreateAsync(input);
int result = await task;

TimeSpan timeElapsed = DateTime.Now - startTime;

Console.WriteLine($"Took {timeElapsed.Hours}h {timeElapsed.Minutes}m {timeElapsed.Seconds}s to randomly generate that word in {result} attempts.");



int RandomlyRecreate(string word)
{
    Random random = new Random();

    string guessWord = word.ToLower();
    int length = guessWord.Length;

    string randomWord = "";

    int count = 0;

    while (guessWord != randomWord)
    {
        randomWord = "";
        for (int i = 0; i < length; i++)
        {
            randomWord += (char)('a' + random.Next(26));
        }
        count++;
    }
    return count;
}

Task<int> RandomlyRecreateAsync(string word)
{
    return Task.Run(() => RandomlyRecreate(word));
}
