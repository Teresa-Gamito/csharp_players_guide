namespace FinalBattle.Attacks;

public interface IAttackModifier
{
    public string ToString();

    public AttackData Modify(AttackData data);
}

public class StoneArmorModifier : IAttackModifier
{
    public override string ToString() => "STONE ARMOR";
    public int Defence { get; } = 1;

    public AttackData Modify(AttackData data)
    {
        if (data.Damage < Defence) return data;
        AttackData newData = new AttackData(data.Damage - Defence, data.HitChance, data.Type);
        Console.WriteLine($"{this} reduced the attack by {Defence} point.");
        return newData;
    }
}

public class ObjectSightModifier : IAttackModifier
{
    public override string ToString() => "OBJECT SIGHT";
    public int Defence { get; } = 2;

    public AttackData Modify(AttackData data)
    {
        if (data.Damage < Defence) return data;
        if (data.Type != DamageType.Decoding) return data;

        AttackData newData = new AttackData(data.Damage - Defence, data.HitChance, data.Type);
        Console.WriteLine($"{this} reduced the attack by {Defence} point.");
        return newData;
    }
}
