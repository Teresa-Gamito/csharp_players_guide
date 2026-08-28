namespace FinalBattle.Characters;

using FinalBattle.Attacks;

public abstract class Character
{
    public abstract int MaxHP { get; }
    public abstract string Name { get; }
    public abstract IAttack Attack { get; } 

    public int HP;
    public bool IsDefeated => HP == 0;

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

    public TrueProgrammer(string name) : base() => Name = name;
}

public class UncodedOne : Character
{
    public override int MaxHP { get; } = 15;
    public override string Name { get; } = "THE UNCODED ONE";
    public override IAttack Attack { get; } = new UnravelingAttack();
}
