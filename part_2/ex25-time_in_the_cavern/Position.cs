public record Position(int Row, int Col)
{
    public Position North => this with { Row = Row - 1 };
    public Position South => this with { Row = Row + 1 };
    public Position East => this with { Col = Col + 1 };
    public Position West => this with { Col = Col - 1 };
    public Position NorthEast => this.North.East;
    public Position SouthEast => this.South.East;
    public Position NorthWest => this.North.West;
    public Position SouthWest => this.South.West;

    public override string ToString()
    {
        return $"(Row={Row} Column={Col})";
    }

    public static List<Position> GetAdjacent(Position position)
    {
        List<Position> adjacent = new List<Position>();
        for (int row = position.Row - 1; row <= position.Row + 1; row++)
        {
            for (int col = position.Col - 1; col <= position.Col + 1; col++)
            {
                Position pos = new Position(row, col);
                if (pos == position) continue;
                adjacent.Add(pos);
            }
        }
        return adjacent;
    }
}
