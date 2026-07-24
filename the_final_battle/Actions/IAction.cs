using Characters;

namespace Actions;

public interface IAction
{
    public void Run(Battle battle, Character user);
}
