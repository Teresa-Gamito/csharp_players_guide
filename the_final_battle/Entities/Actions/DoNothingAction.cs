using Entities.Characters;

namespace Entities.Actions
{

public class DoNothingAction : CharacterAction
{
    public override string Name { get; } = "DO NOTHING";
    public override void Execute(Character user, Character target)
    {
        Console.WriteLine($"{user.Name} did NOTHING.");
    }
}

}
