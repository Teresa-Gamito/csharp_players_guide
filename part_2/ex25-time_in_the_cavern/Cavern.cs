using Entities;

namespace Caverns
{

public abstract class Cavern
{
    public abstract int Width { get; init; }
    public abstract int Height { get; init; }
    private Room[,] _layout;

    private List<Monster> _monsters = new List<Monster>();

    public bool IsFountainActive { get; private set; } = false;

    public Cavern()
    {
        _layout = new Room[Height, Width];
    }

    public void Wrap(Entity entity)
    {
        int row = Math.Abs(entity.Position.Row) % Height;
        int col = Math.Abs(entity.Position.Col) % Width;
        entity.Position = new Position(row, col);
    }

    public void Clamp(Entity entity)
    {
        int row = Math.Clamp(entity.Position.Row, 0, Height - 1);
        int col = Math.Clamp(entity.Position.Col, 0, Width - 1);
        entity.Position = new Position(row, col);
    }

    public void ActivateFountain() 
    {
        IsFountainActive = true;
    }

    protected void SetRoom(Position position, Room room)
    {
        _layout[position.Row, position.Col] = room;
    }

    public bool IsEntrance(Position position)
    {
        return _layout[position.Row, position.Col] == Room.Entrance;
    }

    public bool IsFountain(Position position)
    {
        return _layout[position.Row, position.Col] == Room.Fountain;
    }

    public bool IsPit(Position position)
    {
        return _layout[position.Row, position.Col] == Room.Pit;
    }

    public bool HasPitAdjacent(Position position)
    {
        foreach (Position pos in Position.GetAdjacent(position))
        {
            if (!IsPositionValid(pos)) continue;
            if (IsPit(pos)) return true;
        }
        return false;
    }

    public Monster? GetMonsterAt(Position position)
    {
        foreach (Monster monster in _monsters)
        {
            if (monster.Position == position) return monster;
        }
        return null;
    }

    protected void AddMonster(Monster monster)
    {
        _monsters.Add(monster);
    }

    public void KillMonster(Monster monster)
    {
        _monsters.Remove(monster);
    }

    public bool HasMaelstrom(Position position)
    {
        return GetMonsterAt(position) is Maelstrom;
    }

    public bool HasMaelstromAdjacent(Position position)
    {
        foreach (Position pos in Position.GetAdjacent(position))
        {
            if (!IsPositionValid(pos)) continue;
            if (HasMaelstrom(pos)) return true;
        }
        return false;
    }

    public bool HasAmarok(Position position)
    {
        return GetMonsterAt(position) is Amarok;
    }

    public bool HasAmarokAdjacent(Position position)
    {
        foreach (Position pos in Position.GetAdjacent(position))
        {
            if (!IsPositionValid(pos)) continue;
            if (HasAmarok(pos)) return true;
        }
        return false;
    }

    public bool IsPositionValid(Position position)
    {
        if (position.Row < 0 || position.Row >= Height) return false;
        if (position.Col < 0 || position.Col >= Width) return false;
        return true;
    }

    protected enum Room
    {
        None,
        Entrance,
        Fountain,
        Pit
    }
}

public class Cavern4x4 : Cavern
{
    public override int Width { get; init; } = 4;
    public override int Height { get; init; } = 4;

    public Cavern4x4()
    {
        SetRoom(new Position(0, 0), Room.Entrance);
        SetRoom(new Position(0, 2), Room.Fountain);
        SetRoom(new Position(2, 2), Room.Pit);
        AddMonster(new Maelstrom(new Position(2, 0)));
        AddMonster(new Amarok(new Position(3, 0)));
    }
}

public class Cavern6x6 : Cavern
{
    public override int Width { get; init; } = 6;
    public override int Height { get; init; } = 6;

    public Cavern6x6()
    {
        SetRoom(new Position(0, 0), Room.Entrance);
        SetRoom(new Position(0, 3), Room.Fountain);
        SetRoom(new Position(2, 2), Room.Pit);
        SetRoom(new Position(4, 4), Room.Pit);
        AddMonster(new Maelstrom(new Position(3, 0)));
        AddMonster(new Amarok(new Position(4, 0)));
        AddMonster(new Amarok(new Position(4, 5)));
    }
}

public class Cavern8x8 : Cavern
{
    public override int Width { get; init; } = 8;
    public override int Height { get; init; } = 8;

    public Cavern8x8()
    {
        SetRoom(new Position(0, 0), Room.Entrance);
        SetRoom(new Position(0, 4), Room.Fountain);
        SetRoom(new Position(2, 2), Room.Pit);
        SetRoom(new Position(4, 4), Room.Pit);
        SetRoom(new Position(6, 6), Room.Pit);
        AddMonster(new Maelstrom(new Position(3, 0)));
        AddMonster(new Maelstrom(new Position(5, 3)));
        AddMonster(new Amarok(new Position(4, 0)));
        AddMonster(new Amarok(new Position(4, 5)));
        AddMonster(new Amarok(new Position(7, 5)));
    }
}

}
