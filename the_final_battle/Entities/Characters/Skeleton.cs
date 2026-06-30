using Entities.Actions.Attacks;

namespace Entities.Characters
{

public class Skeleton : Character
{
    public override int MaxHP { get; } = 5;

    public Skeleton() : base("SKELETON")
    {
        Actions.Add(new BoneCrunch());
    }
}

}
