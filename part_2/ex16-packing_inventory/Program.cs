Pack pack = new Pack(10, 50.0f, 50.0f);

while (true)
{
    Console.Clear();
    Console.WriteLine($"Pack - Items: {pack.ItemCount}/{pack.MaxItems} | Weight: {pack.Weight}/{pack.MaxWeight} | Volume: {pack.Volume}/{pack.MaxVolume}");
    Console.WriteLine("Available items:");
    Console.WriteLine("1 - Arrow - Weight: 0.1 | Volume: 0.05");
    Console.WriteLine("2 - Bow - Weight: 1 | Volume: 4");
    Console.WriteLine("3 - Rope - Weight: 1 | Volume: 1.5");
    Console.WriteLine("4 - Water - Weight: 2 | Volume: 3");
    Console.WriteLine("5 - Food Rations - Weight: 1 | Volume: 0.5");
    Console.WriteLine("6 - Sword - Weight: 5 | Volume: 3");

    Console.Write("Add: ");
    string input = Console.ReadLine()!;
    int option = Convert.ToInt32(input);

    InventoryItem? item = option switch
    {
        1 => new Arrow(),
        2 => new Bow(),
        3 => new Rope(),
        4 => new Water(),
        5 => new FoodRations(),
        6 => new Sword(),
        _ => null
    };
    if (item == null) continue;

    if (!pack.Add(item))
    {
        Console.WriteLine("Could not add item");
    }

}

public class Pack
{
    private InventoryItem[] _items;

    public int MaxItems { get; init; }
    public float MaxWeight { get; init; }
    public float MaxVolume { get; init; }

    public int ItemCount
    {
        get
        {
            int count = 0;
            foreach (InventoryItem item in _items)
            {
                if (item != null) count++;
            }
            return count;
        }
    }

    public float Weight
    {
        get
        {
            float weight = 0;
            foreach (InventoryItem item in _items)
            {
                if (item == null) continue;
                weight += item.Weight;
            }
            return weight;
        }
    }

    public float Volume
    {
        get
        {
            float volume = 0;
            foreach (InventoryItem item in _items)
            {
                if (item == null) continue;
                volume += item.Volume;
            }
            return volume;
        }
    }

    public Pack(int maxItems, float maxWeight, float maxVolume)
    {
        MaxItems = maxItems;
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;
        _items = new InventoryItem[maxItems];
    }


    public bool Add(InventoryItem item)
    {
        if (item.Weight + Weight > MaxWeight) return false;
        if (item.Volume + Volume > MaxVolume) return false;

        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] == null)
            {
                _items[i] = item;
                return true;
            }
        }
        return false;
    }


}

public class InventoryItem
{
    public float Weight { get; protected set; }
    public float Volume { get; protected set; }

    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
}

public class Arrow : InventoryItem
{
    public Arrow() : base(0.1f, 0.05f) {}
}

public class Bow : InventoryItem
{
    public Bow() : base(1.0f, 4.0f) {}
}

public class Rope : InventoryItem
{
    public Rope() : base(1.0f, 1.5f) {}
}

public class Water : InventoryItem
{
    public Water() : base(2.0f, 3.0f) {}
}

public class FoodRations : InventoryItem
{
    public FoodRations() : base(1.0f, 0.5f) {}
}

public class Sword : InventoryItem
{
    public Sword() : base(5.0f, 3.0f) {}
}
