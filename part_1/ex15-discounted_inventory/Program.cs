string input;
string discountedName = "Tessy";
double discount = 0.5;

Console.WriteLine("The following items are available:");
Console.WriteLine("1 - Rope");
Console.WriteLine("2 - Torches");
Console.WriteLine("3 - Climbing Equipment");
Console.WriteLine("4 - Clean Water");
Console.WriteLine("5 - Machete");
Console.WriteLine("6 - Canoe");
Console.WriteLine("7 - Food Supplies");

Console.Write("What number do you want to see the price of? ");
input = Console.ReadLine();
int option = Convert.ToInt32(input);

double cost = option switch
{
    1 => 10,
    2 => 16,
    3 => 24,
    4 => 2,
    5 => 20,
    6 => 200,
    7 => 2,
    _ => -1
};

Console.Write("What is your name? ");
string name = Console.ReadLine();
if (name == discountedName) 
{
    cost *= discount;
}

string text = option switch
{
    1 => $"Rope costs {cost} gold",
    2 => $"Torches cost {cost} gold",
    3 => $"Climbing Equipment costs {cost} gold",
    4 => $"Clean Water costs {cost} gold",
    5 => $"Machete costs {cost} gold",
    6 => $"Canoe costs {cost} gold",
    7 => $"Food Supplies costs {cost} gold",
    _ => "That number is not valid"
};
Console.WriteLine(text);
