using Entities.Characters;

namespace Entities.Actions
{

public abstract class CharacterAction
{
    public abstract string? Name { get; }

    public abstract void Execute(Character user, Character target);
}

}
