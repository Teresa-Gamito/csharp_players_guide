string input;

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

string text = option switch
{
    1 => "Rope costs 10 gold",
    2 => "Torches cost 16 gold",
    3 => "Climbing Equipment costs 24 gold",
    4 => "Clean Water costs 2 gold",
    5 => "Machete costs 20 gold",
    6 => "Canoe costs 200 gold",
    7 => "Food Supplies costs 2 gold",
    _ => "That number is not valid"
};
Console.WriteLine(text);
