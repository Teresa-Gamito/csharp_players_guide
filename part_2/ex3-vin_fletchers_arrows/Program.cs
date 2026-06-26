Arrow arrow = new Arrow();

arrow.arrowHead = chooseArrowhead();
arrow.length = chooselength();
arrow.fletchling = chooseFletchling();

Console.WriteLine($"\nArrow cost: {arrow.getCost()} gold");

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

class Arrow
{
    public Arrowhead arrowHead;
    public float length;
    public Fletchling fletchling;

    private float costPerCM = 0.05f;

    public float getCost()
    {
        float cost = 0;

        cost += arrowHead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Wood => 3,
            Arrowhead.Obsidian => 5,
            _ => 0
        };

        cost += length * costPerCM;

        cost += fletchling switch
        {
            Fletchling.Plastic => 10,
            Fletchling.TurkeyFeathers => 5,
            Fletchling.GooseFeathers => 3,
            _ => 0
        };

        return cost;
    }

}

enum Arrowhead
{
    Steel = 1,
    Wood,
    Obsidian,
}

enum Fletchling
{
    Plastic = 1,
    TurkeyFeathers,
    GooseFeathers
}

