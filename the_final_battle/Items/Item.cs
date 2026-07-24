using Characters;

namespace Items
{

public abstract class Item
{
    public abstract string Name { get; }

    public abstract void Use(Character target);
}

}
