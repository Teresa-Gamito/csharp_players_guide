Arrowhead arrowhead = chooseArrowhead();
float length = chooselength();
Fletchling fletchling = chooseFletchling();

Arrow arrow = new Arrow(arrowhead, length, fletchling);

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
