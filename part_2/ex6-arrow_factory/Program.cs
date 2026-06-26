Console.WriteLine("Choose your arrow: ");
Console.WriteLine("1 - Elite Arrow");
Console.WriteLine("2 - Beginner Arrow");
Console.WriteLine("3 - Marksman Arrow");
Console.WriteLine("4 - Create your own arrow");

Console.Write("Option: ");
string input = Console.ReadLine();
int option = Convert.ToInt32(input);

Arrow arrow;

if (option == 1) 
{
    arrow = Arrow.CreateEliteArrow();
}
else if (option == 2) 
{
    arrow = Arrow.CreateBeginnerArrow();
}
else if (option == 3) 
{
    arrow = Arrow.CreateMarksmanArrow();
}
else
{
    Arrowhead arrowhead = chooseArrowhead();
    float length = chooselength();
    Fletchling fletchling = chooseFletchling();
    arrow = new Arrow(arrowhead, length, fletchling);
}

float cost = arrow.Cost();
Console.WriteLine($"\nArrow cost: {cost} gold");

Arrowhead chooseArrowhead()
{
    Console.WriteLine("\nChoose the arrowhead type:");
    Console.WriteLine("1 - Steel - 10 gold");
    Console.WriteLine("2 - Wood - 3 gold");
    Console.WriteLine("3 - Obsidian - 5 gold");

    Console.Write("Option: ");
    string input = Console.ReadLine();
    return (Arrowhead)Convert.ToInt32(input);
}

float chooselength()
{
    float length = 0;
    while (length < 60 || length > 100)
    {
        Console.Write("\nChoose the length (60cm - 100cm) 0.05 gold/cm: ");
        string input = Console.ReadLine();
        length = Convert.ToSingle(input);
    }
    return length;
}

Fletchling chooseFletchling()
{
    Console.WriteLine("\nChoose the fletchling type:");
    Console.WriteLine("1 - Plastic - 10 gold");
    Console.WriteLine("2 - Turkey Feathers - 5 gold");
    Console.WriteLine("3 - Goose Feathers - 3 gold");

    Console.Write("Option: ");
    string input = Console.ReadLine();
    return (Fletchling)Convert.ToInt32(input);
}

public class Arrow
{
    private Arrowhead Arrowhead { get; init; }
    private float Length { get; init; }
    private Fletchling Fletchling { get; init; }
    private float LengthCost { get; } = 0.05f;

    public Arrow(Arrowhead arrowhead, float length, Fletchling fletchling)
    {
        Arrowhead = arrowhead;
        Length = length;
        Fletchling = fletchling;
    }

    public static Arrow CreateEliteArrow() => new Arrow(Arrowhead.Steel, 95.0f, Fletchling.Plastic);
    public static Arrow CreateBeginnerArrow() => new Arrow(Arrowhead.Wood, 75.0f, Fletchling.GooseFeathers);
    public static Arrow CreateMarksmanArrow() => new Arrow(Arrowhead.Steel, 65.0f, Fletchling.GooseFeathers);

    public float Cost()
    {
        float cost = 0;

        cost += Arrowhead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Wood => 3,
            Arrowhead.Obsidian => 5,
            _ => 0
        };

        cost += Length * LengthCost;

        cost += Fletchling switch
        {
            Fletchling.Plastic => 10,
            Fletchling.TurkeyFeathers => 5,
            Fletchling.GooseFeathers => 3,
            _ => 0
        };

        return cost;
    }
}

public enum Arrowhead
{
    Steel = 1,
    Wood,
    Obsidian,
}

public enum Fletchling
{
    Plastic = 1,
    TurkeyFeathers,
    GooseFeathers
}
