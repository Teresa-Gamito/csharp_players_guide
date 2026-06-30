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
}

public record BlockOffset(int RowOffset, int ColumnOffset);

public enum Direction 
{
    North,
    East,
    South,
    West
}
