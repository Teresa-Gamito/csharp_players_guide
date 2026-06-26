Sword sword1 = new Sword(Material.Iron, Gemstone.None, 10.0f);
Sword sword2 = sword1 with { Material = Material.Steel };
Sword sword3 = sword1 with { Material = Material.Binarium, Gemstone = Gemstone.Bitstone };

Console.WriteLine(sword1);
Console.WriteLine(sword2);
Console.WriteLine(sword3);

public record Sword(Material Material, Gemstone Gemstone, float CrossguardWidth);

public enum Material
{
    Wood,
    Bronze,
    Iron,
    Steel,
    Binarium
}

public enum Gemstone
{
    Emerald,
    Amber,
    Sapphire,
    Diamond,
    Bitstone,
    None
}
