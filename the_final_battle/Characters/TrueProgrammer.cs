using Attacks;

namespace Characters;

public class TrueProgrammer : Character
{
    public override int MaxHP { get; } = 25;

    public TrueProgrammer(string name) : base(name)
    {
        Actions.Add(new Punch());
    }
}
