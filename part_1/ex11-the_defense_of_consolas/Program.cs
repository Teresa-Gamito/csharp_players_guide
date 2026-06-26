Console.Clear();
Console.Title = "Defese of Consolas";
Console.BackgroundColor = ConsoleColor.White;

Console.WriteLine("Deploy magical barrier!\n");

Console.Write("Target Row? ");
int row = Convert.ToInt32(Console.ReadLine());

Console.Write("Target Column? ");
int col = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Deploy to:");
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine($"({row + 1},{col})");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"({row},{col + 1})");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"({row - 1},{col})");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"({row},{col - 1})");
Console.Beep();
