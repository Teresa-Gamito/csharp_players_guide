using Characters;

namespace Actions;

public class DoNothingAction : IAction
{
    public void Run(Battle battle, Character user)
    {
        Console.WriteLine($"{user.Name} did NOTHING");
    }
}
