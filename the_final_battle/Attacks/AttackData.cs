namespace FinalBattle.Attacks;

public class AttackData
{
    public int Damage { get; init; }
    public float HitChance { get; init; }
    public DamageType Type { get; }

    public AttackData(int damage, float hitChance, DamageType type)
    {
        Damage = damage;
        HitChance = hitChance;
        Type = type;
    }
}
