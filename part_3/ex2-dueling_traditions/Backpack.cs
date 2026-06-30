using Item;
namespace Backpack
{
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
}
