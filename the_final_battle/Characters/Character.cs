using Attacks;

namespace Characters;

public abstract class Character
{
    public abstract string? Name { get; }

    public abstract int MaxHP { get; }
    public int HP { get; set; }

    public List<IAttack> Attacks { get; set; } = new();

    public bool IsDefeated => HP <= 0;

    public void Heal(int healFactor)
    {
        HP += healFactor;
        if (HP > MaxHP) HP = MaxHP;
    }

    public void Damage(int damage)
    {
        HP -= damage;
        if (HP < 0) HP = 0;
    }
}
