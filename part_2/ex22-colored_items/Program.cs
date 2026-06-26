ColoredItem<Sword> blueSword = new ColoredItem<Sword>(new Sword(), ConsoleColor.Blue);
ColoredItem<Bow> redSword = new ColoredItem<Bow>(new Bow(), ConsoleColor.Red);
ColoredItem<Axe> greenSword = new ColoredItem<Axe>(new Axe(), ConsoleColor.Green);

blueSword.Display();
redSword.Display();
greenSword.Display();

public class Sword { }
public class Bow { }
public class Axe { }

public class ColoredItem<T>
{
    public T Item { get; }
    public ConsoleColor Color { get; }

    public ColoredItem(T item, ConsoleColor color)
    {
        Item = item;
        Color = color;
    }

    public void Display()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(Item!.ToString());
    }
}
