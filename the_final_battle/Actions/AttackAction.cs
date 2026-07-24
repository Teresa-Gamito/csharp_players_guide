using Characters;

namespace Actions;

public class AttackAction : IAction
{
    public void Run(Battle battle, Character user)
    {
        Console.WriteLine($"{user.Name} ..."); // TODO:
    }
}
