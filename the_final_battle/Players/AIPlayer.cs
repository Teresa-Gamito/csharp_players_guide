namespace Players
{

public class AIPlayer : Player
{
    Random _random = new Random();

    public override int ChooseOption(int optionCount)
    {
        Thread.Sleep(500);
        return _random.Next(optionCount);
    }
}

}
