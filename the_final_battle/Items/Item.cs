namespace FinalBattle.Items;

using FinalBattle.Characters;

public interface IItem
{
    public string Name { get; }

    public void Use(Character target);
}

public class HealthPotion : IItem
{
    public string Name { get; } = "HEALTH POTION";
    private int _healValue = 10;

    public void Use(Character target)
    {
        int initHP = target.HP;
        target.Heal(_healValue);
        int finalHP = target.HP;
        Console.WriteLine($"{target.Name} was healed for {finalHP - initHP}HP");
    }
}
