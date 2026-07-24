using Characters;

namespace Items
{

public class HealthPotion : Item
{
    public override string Name { get; } = "HEALTH POTION";

    public const int HealFactor = 10;

    public override void Use(Character user, Character target)
    {
        user.Heal(HealFactor);
    }
}

}
