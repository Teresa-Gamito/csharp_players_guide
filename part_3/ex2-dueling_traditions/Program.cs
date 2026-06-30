using Backpack;
using Item;

internal class Program
{
    static void Main()
    {
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
    }
}

