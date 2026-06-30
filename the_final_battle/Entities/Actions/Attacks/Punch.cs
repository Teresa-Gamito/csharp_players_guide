using Entities.Characters;

namespace Entities.Actions.Attacks
{

public class Punch : Attack
{
    public override string? Name { get; } = "PUNCH";
    public override int Damage { get; set; } = 1;

    public override void Execute(Character user, Character target)
    {
        base.Execute(user, target);
    }
}

}
