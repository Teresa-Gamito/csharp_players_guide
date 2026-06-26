string input;

Console.Write("x: ");
input = Console.ReadLine();
int x = Convert.ToInt32(input);

Console.Write("y: ");
input = Console.ReadLine();
int y = Convert.ToInt32(input);

string direction = "";

if (y > 0) direction += "north";
else if (y < 0) direction += "south";

if (x > 0) direction += "east";
else if (x < 0) direction += "west";

if (x == 0 && y == 0)
    Console.WriteLine("The enemy is here!");
else
    Console.WriteLine($"The enemy is to the {direction}!");
