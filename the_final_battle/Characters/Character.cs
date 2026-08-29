namespace FinalBattle.Characters;

using FinalBattle.Attacks;
using FinalBattle.Gear;

public abstract class Character
{
    public abstract int MaxHP { get; }
    public abstract string Name { get; }
    public abstract IAttack Attack { get; }
    public IGear? Gear { get; set; } = null;

    public int HP;
    public bool IsDefeated => HP == 0;
    public bool HasGear => Gear != null;

    public Character() => HP = MaxHP;

    public void Damage(int value)
    {
        HP -= value;
        if (HP < 0) HP = 0;
    }
    
    public void Heal(int value)
    {
        HP += value;
        if (HP > MaxHP) HP = MaxHP;
    }

    public IGear? EquipGear(IGear gear)
    {
        IGear? oldGear = Gear;
        Gear = gear;
        return oldGear;
    }

    public IGear? UnequipGear()
    {
        IGear? oldGear = Gear;
        Gear = null;
        return oldGear;
    }
}

public class Skeleton : Character
{
    public override int MaxHP { get; } = 5;
    public override string Name { get; } = "SKELETON";
    public override IAttack Attack { get; } = new BoneCrunchAttack();
}

public class TrueProgrammer : Character
{
    public override int MaxHP { get; } = 25;
    public override string Name { get; }
    public override IAttack Attack { get; } = new PunchAttack();

    public TrueProgrammer(string name) : base()
    {
        Name = name; 
    }
}

public class UncodedOne : Character
{
    public override int MaxHP { get; } = 15;
    public override string Name { get; } = "THE UNCODED ONE";
    public override IAttack Attack { get; } = new UnravelingAttack();
}
