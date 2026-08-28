namespace FinalBattle.Characters;

using FinalBattle.Attacks;

public abstract class Character
{
    public abstract int MaxHP { get; }
    public abstract string Name { get; }
    public List<IAttack> Attacks { get; } = new List<IAttack>();

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

    public Skeleton()
    {
        Attacks.Add(new BoneCrunchAttack());
    }

}

public class TrueProgrammer : Character
{
    public override int MaxHP { get; } = 25;
    public override string Name { get; }

    public TrueProgrammer(string name) : base()
    {
        Name = name; 
        Attacks.Add(new PunchAttack());
    }
}

public class UncodedOne : Character
{
    public override int MaxHP { get; } = 15;
    public override string Name { get; } = "THE UNCODED ONE";

    public UncodedOne()
    {
        Attacks.Add(new UnravelingAttack());
    }
}
