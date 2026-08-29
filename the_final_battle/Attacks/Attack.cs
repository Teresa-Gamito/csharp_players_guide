namespace FinalBattle.Attacks;

public interface IAttack
{
    public string ToString();

    public int BaseDamage { get; }
    public float HitChance { get; }
    public int Damage { get; }
    public DamageType Type { get; }

    public AttackData GetData();
}

public enum DamageType
{
    Normal,
    Decoding
}

public class PunchAttack : IAttack
{
    public override string ToString() => "PUNCH";

    public int BaseDamage { get; } = 1;
    public float HitChance { get ; } = 1.0f;
    public DamageType Type { get; } = DamageType.Normal;

    public int Damage => BaseDamage;

    public AttackData GetData() => new AttackData(Damage, HitChance, Type);
}

public class BoneCrunchAttack : IAttack
{
    private Random _random = new Random();

    public override string ToString() => "BONE CRUNCH";

    public int BaseDamage { get; } = 1;
    public float HitChance { get ; } = 1.0f;
    public DamageType Type { get; } = DamageType.Normal;

    public int Damage => _random.Next(BaseDamage + 1);

    public AttackData GetData() => new AttackData(Damage, HitChance, Type);
}

public class UnravelingAttack : IAttack
{
    private Random _random = new Random();
    public override string ToString() => "UNRAVELING";

    public int BaseDamage { get; } = 4;
    public float HitChance { get ; } = 1.0f;
    public DamageType Type { get; } = DamageType.Decoding;

    public int Damage => _random.Next(BaseDamage + 1);

    public AttackData GetData() => new AttackData(Damage, HitChance, Type);
}

public class SlashAttack : IAttack
{
    public override string ToString() => "SLASH";

    public int BaseDamage { get; } = 2;
    public float HitChance { get ; } = 1.0f;
    public DamageType Type { get; } = DamageType.Normal;

    public int Damage => BaseDamage;

    public AttackData GetData() => new AttackData(Damage, HitChance, Type);
}

public class StabAttack : IAttack
{
    public override string ToString() => "STAB";

    public int BaseDamage { get; } = 1;
    public float HitChance { get ; } = 1.0f;
    public DamageType Type { get; } = DamageType.Normal;

    public int Damage => BaseDamage;

    public AttackData GetData() => new AttackData(Damage, HitChance, Type);
}

public class QuickShotAttack : IAttack
{
    public override string ToString() => "QUICK ATTACK";

    public int BaseDamage { get; } = 3;
    public float HitChance { get ; } = 0.5f;
    public DamageType Type { get; } = DamageType.Normal;

    public int Damage => BaseDamage;

    public AttackData GetData() => new AttackData(Damage, HitChance, Type);
}

public class BiteAttack : IAttack
{
    public override string ToString() => "BITE";

    public int BaseDamage { get; } = 1;
    public float HitChance { get ; } = 1.0f;
    public DamageType Type { get; } = DamageType.Normal;

    public int Damage => BaseDamage;

    public AttackData GetData() => new AttackData(Damage, HitChance, Type);
}
