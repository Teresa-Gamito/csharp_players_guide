namespace FinalBattle.Gear;

using FinalBattle.Attacks;

public interface IGear
{
    public string ToString();

    public IAttack Attack { get; }
}

public class Sword : IGear
{
    public override string ToString() => "SWORD";

    public IAttack Attack { get; } = new SlashAttack();
}

public class Dagger : IGear
{
    public override string ToString() => "DAGGER";

    public IAttack Attack { get; } = new StabAttack();
}

public class VimsBow : IGear
{
    public override string ToString() => "VIM'S BOW";

    public IAttack Attack { get; } = new QuickShotAttack();
}
