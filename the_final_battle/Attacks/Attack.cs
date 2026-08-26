namespace FinalBattle.Attacks;

public interface IAttack
{
    public string Name { get; }

    public AttackData GetData();
}

public class PunchAttack : IAttack
{
    public string Name { get; } = "PUNCH";

    public AttackData GetData()
    {
        return new AttackData(1);
    }
}

public class BoneCrunchAttack : IAttack
{
    private Random _random = new Random();
    public string Name { get; } = "BONE CRUNCH";

    public AttackData GetData()
    {
        return new AttackData(_random.Next(1 + 1));
    }
}
