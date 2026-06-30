
Console.Write("Name: ");
string? name = Console.ReadLine();
int score = 0;

string fileName = name + ".txt";
if (File.Exists(fileName))
{
    string input = File.ReadAllText(fileName);
    score = Convert.ToInt32(input);
}
else
{
    File.CreateText(fileName);
}

Console.Clear();
Console.WriteLine("Score: " + score);
while (Console.ReadKey().Key != ConsoleKey.Enter)
{
    score++;
    Console.Clear();
    Console.Write("Score: " + score);
}

File.WriteAllText(fileName, score.ToString());
