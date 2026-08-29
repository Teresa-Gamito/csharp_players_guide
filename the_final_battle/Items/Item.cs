namespace FinalBattle.Items;

using FinalBattle.Characters;

public interface IItem
{
    public string ToString();

    public void Use(Character target);
}

public class HealthPotion : IItem
{
    public override string ToString() => "HEALTH POTION";
    private int _healValue = 10;

    public void Use(Character target)
    {
        int initHP = target.HP;
        target.Heal(_healValue);
        int finalHP = target.HP;
        Console.WriteLine($"{target} was healed for {finalHP - initHP}HP");
    }
}

public class SimulasSoup : IItem
{
    public override string ToString() => "HEALTH POTION";

    public void Use(Character target)
    {
        int initHP = target.HP;
        target.Heal(target.MaxHP - target.HP);
        int finalHP = target.HP;
        Console.WriteLine($"{target} was healed for {finalHP - initHP}HP");
    }
}
