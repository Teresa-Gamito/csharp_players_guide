Board board = new Board(4, 4);

while (true)
{
    board.Print();

    if (board.IsSolved())
    {
        Console.WriteLine("You Won!");
        break;
    }

    string input = Console.ReadLine()!;
    int tile = Convert.ToInt32(input);

    board.MoveTile(tile);
}


public class Board
{
    private int Width { get; }
    private int Height { get; }

    public int[,] Tiles { get; private set; }

    public Board(int width, int height)
    {
        Width = width;
        Height = height;

        Tiles = new int[Width, Height];

        int curr = 1;
        for (int col = 0; col < Width; col++)
        {
            for (int row = 0; row < Height; row++)
            {
                Tiles[col, row] = curr;
                curr++;
            }
        }
    }

    private void Randomize()
    {
    }

    public void Print()
    {
        for (int col = 0; col < Width; col++)
        {
            for (int row = 0; row < Height; row++)
            {
                if (Tiles[col, row] == Tiles.Length)
                {
                    Console.Write("   ");
                    continue;
                }
                Console.Write($"{Tiles[col, row], -3}");
            }
            Console.WriteLine();
        }
    }

    public bool IsSolved()
    {
        int curr = 1;
        for (int col = 0; col < Width; col++)
        {
            for (int row = 0; row < Height; row++)
            {
                if (Tiles[col, row] != curr)
                {
                    return false;
                }
                curr++;
            }
        }
        return true;
    }

    public void MoveTile(int tile)
    {
        Position emptyPos = GetTile(Tiles.Length)!;

        Position up = new Position(emptyPos.Col - 1, emptyPos.Row);
        Position down = new Position(emptyPos.Col + 1, emptyPos.Row);
        Position left = new Position(emptyPos.Col, emptyPos.Row - 1);
        Position right = new Position(emptyPos.Col, emptyPos.Row + 1);

        if (up.IsValid(Width, Height) && tile == GetTile(up))
        {
            SwapTiles(emptyPos, up);
        }
        else if (down.IsValid(Width, Height) && tile == GetTile(down))
        {
            SwapTiles(emptyPos, down);
        }
        else if (left.IsValid(Width, Height) && tile == GetTile(left))
        {
            SwapTiles(emptyPos, left);
        }
        else if (right.IsValid(Width, Height) && tile == GetTile(right))
        {
            SwapTiles(emptyPos, right);
        }
    }

    private Position? GetTile(int tile)
    {
        for (int col = 0; col < Width; col++)
        {
            for (int row = 0; row < Height; row++)
            {
                if (Tiles[col, row] == tile)
                {
                    return new Position(col, row);
                }
            }
        }
        return null;
    }

    private int GetTile(Position position)
    {
        return Tiles[position.Col, position.Row];
    }

    private void SwapTiles(Position pos1, Position pos2)
    {
        (Tiles[pos1.Col, pos1.Row], Tiles[pos2.Col, pos2.Row]) = (Tiles[pos2.Col, pos2.Row], Tiles[pos1.Col, pos1.Row]);
    }
}

public class Position
{
    public int Col { get; set; }
    public int Row { get; set; }

    public Position(int col, int row)
    {
        Col = col;
        Row = row;
    }

    public bool IsValid(int colNum, int rowNum)
    {
        if (Col < 0 || Col >= colNum) return false;
        if (Row < 0 || Row >= rowNum) return false;
        return true;
    }
}
