namespace Entities
{

public abstract class Entity
{
    public Position Position { get; set; }

    public Entity(Position position)
    {
        Position = position;
    }

    public void Move(Position position) => Position = position;
}

public class Player : Entity
{
    public int ArrowCount { get; private set; } = 5;
    public Player(Position position) : base(position) {}

    public bool HasArrows() => ArrowCount > 0;
    public void ShootArrow()
    {
        if (HasArrows()) ArrowCount--;
    }
}

public abstract class Monster : Entity
{
    public Monster(Position position) : base(position) {}
    public virtual void Attack(Player player) {}
}

public class Maelstrom : Monster
{
    public Maelstrom(Position position) : base(position) {}
    public override string ToString() => "Maelstrom";

    public override void Attack(Player player)
    {
        Position = Position.South.West.West;
        player.Position = player.Position.North.East.East;
    }
}

public class Amarok : Monster
{
    public Amarok(Position position) : base(position) {}
    public override string ToString() => "Amarok";
}

}
