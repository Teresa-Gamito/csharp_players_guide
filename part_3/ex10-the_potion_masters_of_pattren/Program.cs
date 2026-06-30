Potion potion = new Potion();

Console.WriteLine("\nMake a potion!\n");
Potion.DisplayIngredients();
Console.WriteLine("\nYour potion: " + potion.ToString());

while (true)
{
    Console.Write("Add an ingredient: ");
    string? input = Console.ReadLine();

    Ingredient ingredient = input switch
    {
        "stardust" => Ingredient.Stardust,
        "snake venom" => Ingredient.SnakeVenom,
        "dragon breath" => Ingredient.DragonBreath,
        "shadow glass" => Ingredient.ShadowGlass,
        "eyeshine gem" => Ingredient.EyeshineGem,
        _ => Ingredient.Invalid
    };

    if (ingredient == Ingredient.Invalid)
    {
        Console.WriteLine("Invalid ingredient\n");
        continue;
    }

    potion.AddIngredient(ingredient);

    Console.WriteLine("\nYour potion: " + potion.ToString() + "\n");

    Console.Write("Do you wish to continue? ");
    input = Console.ReadLine();
    if (input == "yes" || input == "y" || input == "") continue;
    else break;
}

Console.WriteLine("\nYou made: " + potion.ToString() + "!");



public class Potion
{
    public PotionType Type { get; private set; } = PotionType.Water;

    public void AddIngredient(Ingredient ingredient)
    {
        Type = (Type, ingredient) switch
        {
            (PotionType.Water,          Ingredient.Stardust)        =>  PotionType.Elixir,
            (PotionType.Elixir,         Ingredient.SnakeVenom)      =>  PotionType.Poison,
            (PotionType.Elixir,         Ingredient.DragonBreath)    =>  PotionType.Flying,
            (PotionType.Elixir,         Ingredient.ShadowGlass)     =>  PotionType.Invisibility,
            (PotionType.Elixir,         Ingredient.EyeshineGem)     =>  PotionType.NightSight,
            (PotionType.NightSight,     Ingredient.ShadowGlass)     =>  PotionType.CloudyBrew,
            (PotionType.Invisibility,   Ingredient.EyeshineGem)     =>  PotionType.CloudyBrew,
            (PotionType.CloudyBrew,     Ingredient.Stardust)        =>  PotionType.Wraith,
            _ => PotionType.Ruined
        };
    }

    public override string ToString()
    {
        return Type switch
        {
            PotionType.Water => "water bottle",
            PotionType.Ruined => "ruined potion",
            PotionType.Elixir => "elixir",
            PotionType.Poison => "poison potion",
            PotionType.Flying => "flying potion",
            PotionType.Invisibility => "invisibility potion",
            PotionType.NightSight => "noght sight potion",
            PotionType.CloudyBrew => "clowdy brew",
            PotionType.Wraith => "wraith potion",
            _ => "invalid"
        };
    }

    public static void DisplayIngredients()
    {
        Console.WriteLine("Available ingredients: ");
        Console.WriteLine("stardust");
        Console.WriteLine("snake venom");
        Console.WriteLine("dragon breath");
        Console.WriteLine("shadow glass");
        Console.WriteLine("eyeshine gem");
    }
}

public enum PotionType
{
    Water,
    Ruined,
    Elixir,
    Poison,
    Flying,
    Invisibility,
    NightSight,
    CloudyBrew,
    Wraith
}

public enum Ingredient
{
    Stardust,
    SnakeVenom,
    DragonBreath,
    ShadowGlass,
    EyeshineGem,
    Invalid
}
