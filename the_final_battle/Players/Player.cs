namespace Players
{

public abstract class Player
{
    public abstract int ChooseOption(int optionCount);
    public T Choose<T>(List<T> list) => list[ChooseOption(list.Count)];
}

}
