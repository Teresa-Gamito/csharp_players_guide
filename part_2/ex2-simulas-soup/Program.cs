(Type soupType, Ingredient mainIngredient, Seasoning seasoning) soup;

Console.WriteLine("Make a soup!\n");

soup.soupType = chooseType();
soup.mainIngredient = chooseIngredient();
soup.seasoning = chooseSeasoning();

Console.WriteLine($"\nYou made {soup.seasoning} {soup.mainIngredient} {soup.soupType}!");

Type chooseType()
{
    while (true)
    {
        Console.WriteLine("Choose the type:");
        Console.WriteLine("1 - Soup");
        Console.WriteLine("2 - Stew");
        Console.WriteLine("3 - Gumbo");
        Console.Write("Option: ");

        string input;
        input = Console.ReadLine();
        return (Type)Convert.ToInt32(input);
    }
}

Ingredient chooseIngredient()
{
    while (true)
    {
        Console.WriteLine("Choose the main ingredient:");
        Console.WriteLine("1 - Mushrooms");
        Console.WriteLine("2 - Chicken");
        Console.WriteLine("3 - Carrots");
        Console.WriteLine("4 - Potatoes");
        Console.Write("Option: ");

        string input;
        input = Console.ReadLine();
        return (Ingredient)Convert.ToInt32(input);
    }
}

Seasoning chooseSeasoning()
{
    while (true)
    {
        Console.WriteLine("Choose the seasoning:");
        Console.WriteLine("1 - Spicy");
        Console.WriteLine("2 - Salty");
        Console.WriteLine("3 - Sweet");
        Console.Write("Option: ");

        string input;
        input = Console.ReadLine();
        return (Seasoning)Convert.ToInt32(input);
    }
}

enum Type
{
    Soup = 1,
    Stew,
    Gumbo
}

enum Ingredient
{
    Mushrooms = 1,
    Chicken,
    Carrots,
    Potatoes
}

enum Seasoning
{
    Spicy = 1,
    Salty,
    Sweet
}
