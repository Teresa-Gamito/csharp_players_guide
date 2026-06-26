Coordinate c1 = new Coordinate(0, 0);
Coordinate c2 = new Coordinate(1, 0);
Coordinate c3 = new Coordinate(0, 1);
Coordinate c4 = new Coordinate(-1, 0);
Coordinate c5 = new Coordinate(0, -1);
Coordinate c6 = new Coordinate(1, -1);

Console.WriteLine(c1.IsAdjacent(c2));
Console.WriteLine(c1.IsAdjacent(c3));
Console.WriteLine(c1.IsAdjacent(c4));
Console.WriteLine(c1.IsAdjacent(c5));
Console.WriteLine(!c1.IsAdjacent(c6));

public struct Coordinate
{
    public int Row { get; }
    public int Col { get; }

    public Coordinate(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public bool IsAdjacent(Coordinate that)
    {
        if (Math.Abs(this.Row - that.Row) == 1 && this.Col == that.Col) return true;
        if (Math.Abs(this.Col - that.Col) == 1 && this.Row == that.Row) return true;
        return false;
    }
}
