using Entities.Characters;

namespace Entities.Actions.Attacks
{

public class BoneCrunch : Attack
{
    Random _random = new();

    private const int _damage = 1;
    public override int Damage { get; set; } = _damage;

    public override string? Name { get; } = "BONE CRUNCH";

    public override void Execute(Character user, Character target)
    {
        Damage = _random.Next(_damage + 1);
        base.Execute(user, target);
    }
}

}

