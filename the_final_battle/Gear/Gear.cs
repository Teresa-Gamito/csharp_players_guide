namespace FinalBattle.Gear;

using FinalBattle.Attacks;

public interface IGear
{
    public string Name { get; }

    public IAttack Attack { get; }
}

public class Sword : IGear
{
    public string Name { get; } = "SWORD";

    public IAttack Attack { get; } = new SlashAttack();
}

public class Dagger : IGear
{
    public string Name { get; } = "DAGGER";

    public IAttack Attack { get; } = new StabAttack();
}
