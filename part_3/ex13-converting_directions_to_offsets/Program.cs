public record BlockCoordinate(int Row, int Column)
{
    public static BlockCoordinate operator +(BlockCoordinate coordinate, BlockOffset offset) =>
        new BlockCoordinate(coordinate.Row + offset.RowOffset, coordinate.Column + offset.ColumnOffset);

    public static BlockCoordinate operator +(BlockOffset offset, BlockCoordinate coordinate) =>
        coordinate + offset;

    public static BlockCoordinate operator +(BlockCoordinate coordinate, Direction direction)
    {
        return direction switch
        {
            Direction.North => new BlockCoordinate(coordinate.Row - 1, coordinate.Column),
            Direction.East => new BlockCoordinate(coordinate.Row, coordinate.Column + 1),
            Direction.South => new BlockCoordinate(coordinate.Row + 1, coordinate.Column),
            Direction.West => new BlockCoordinate(coordinate.Row, coordinate.Column - 1),
            _ => coordinate
        };
    }

    public static BlockCoordinate operator +(Direction direction, BlockCoordinate coordinate) =>
        coordinate + direction;

    public int this[int i] => i == 0 ? Row : Column;
}

public record BlockOffset(int RowOffset, int ColumnOffset)
{
    public static explicit operator BlockOffset(Direction direction)
    {
        return direction switch
        {
            Direction.North => new BlockOffset(-1, 0),
            Direction.East => new BlockOffset(0, 1),
            Direction.South => new BlockOffset(1, 0),
            Direction.West => new BlockOffset(0, +1),
            _ => new BlockOffset(0, 0)
        };
    }
}

public enum Direction 
{
    North,
    East,
    South,
    West
}
