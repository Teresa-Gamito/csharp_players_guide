using Entities.Actions.Attacks;

namespace Entities.Characters
{

public class UncodedOne : Character
{
    public override int MaxHP { get; } = 15;

    public UncodedOne() : base("UNCODED ONE")
    {
        Actions.Add(new Unraveling());
    }
}

}
