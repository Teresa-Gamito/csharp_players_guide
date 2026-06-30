namespace Item
{
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
}
