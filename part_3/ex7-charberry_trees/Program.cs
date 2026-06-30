CharberryTree tree = new CharberryTree();
Notifier notifier = new Notifier(tree);
Harvester harvester = new Harvester(tree);

while (true)
    tree.MaybeGrow();

public class CharberryTree
{
    public event Action? Ripened;
    private Random _random = new Random();
    public bool Ripe { get; set; } = false;

    public void MaybeGrow()
    {
        // only a tiny chance of ripening eacj time, but we try a lot!
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            if (Ripened != null) Ripened();
        }
    }
}

public class Notifier
{
    public Notifier(CharberryTree tree)
    {
        tree.Ripened += Notify;
    }

    public void Notify()
    {
        Console.WriteLine("A charberry fruit has ripened!");
    }
}

public class Harvester
{
    private CharberryTree _tree;

    public Harvester(CharberryTree tree)
    {
        _tree = tree;
        tree.Ripened += Harvest;
    }

    public void Harvest()
    {
        _tree.Ripe = false;
        Console.WriteLine("Fruit was harvested.");
    }
}
