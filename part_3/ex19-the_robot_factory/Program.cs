using System.Dynamic;


int id = 1;
while (true)
{
    dynamic robot = new ExpandoObject();

    robot.ID = id;
    Console.WriteLine("You are producing robot #" + robot.ID);

    Console.Write("Do you want to name this robot? ");
    if (Confirm())
    {
        Console.Write("What is its name? ");
        robot.Name = Console.ReadLine();
    }

    Console.Write("Does this robot have a specific size? ");
    if (Confirm())
    {
        Console.Write("What is its height? ");
        robot.Height = Convert.ToInt32(Console.ReadLine());
        Console.Write("What is its width? ");
        robot.Width = Convert.ToInt32(Console.ReadLine());
    }

    Console.Write("Does this robot need to be a specific color? ");
    if (Confirm())
    {
        Console.Write("What color? ");
        robot.Color = Console.ReadLine();
    }

    foreach (KeyValuePair<string, object> property in (IDictionary<string, object>)robot)
    {
        Console.WriteLine($"{property.Key}: {property.Value}");
    }

    id++;
}

bool Confirm()
{
    string? input = Console.ReadLine();
    if (input == "yes" || input == "y") return true;
    return false;
}
