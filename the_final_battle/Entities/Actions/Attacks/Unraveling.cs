using Entities.Characters;

namespace Entities.Actions.Attacks
{

public class Unraveling : Attack
{
    Random _random = new();

    private const int _damage = 2;
    public override int Damage { get; set; } = _damage;

    public override string? Name { get; } = "UNRAVELING";

    public override void Execute(Character user, Character target)
    {
        Damage = _random.Next(_damage + 1);
        base.Execute(user, target);
    }
}

}
