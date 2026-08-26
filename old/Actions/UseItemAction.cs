using Characters;

namespace Actions;

public class UseItemAction : IAction
{
    public void Run(Battle battle, Character user)
    {
        Console.WriteLine($"{user.Name} used... "); // TODO:
    }
}
