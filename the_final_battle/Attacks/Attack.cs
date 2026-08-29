namespace FinalBattle.Attacks;

public interface IAttack
{
    public string Name { get; }

    public AttackData GetData();
}

public class PunchAttack : IAttack
{
    public string Name { get; } = "PUNCH";

    public AttackData GetData() => new AttackData(1);
}

public class BoneCrunchAttack : IAttack
{
    private Random _random = new Random();
    public string Name { get; } = "BONE CRUNCH";

    public AttackData GetData() => new AttackData(_random.Next(1 + 1));
}

public class UnravelingAttack : IAttack
{
    private Random _random = new Random();
    public string Name { get; } = "UNRAVELING";

    public AttackData GetData() => new AttackData(_random.Next(2 + 1));
}

public class SlashAttack : IAttack
{
    public string Name { get; } = "SLASH";

    public AttackData GetData() => new AttackData(2);
}

public class StabAttack : IAttack
{
    public string Name { get; } = "STAB";

    public AttackData GetData() => new AttackData(1);
}
