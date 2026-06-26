Game game = new Game("Luni", "Tessy");

while (game.Play());

public class Game
{
    private Board _board = new Board();
    private Player[] _players = new Player[2];
    private Player activePlayer;

    public Game(string player1Name, string player2Name)
    {
        _players[0] = new Player(player1Name, 'X');
        _players[1] = new Player(player2Name, 'O');
        activePlayer = _players[0];
    }

    public bool Play()
    {
        if (PlayTurn(activePlayer))
        {
            AdvanceTurn();
            return true;
        }
        else 
        {
            return false;
        }
    }

    private void AdvanceTurn()
    {
        if (activePlayer == _players[0]) activePlayer = _players[1];
        else activePlayer = _players[0];
    }

    private bool PlayTurn(Player player)
    {
        while (true)
        {
            Console.WriteLine($"It is {player.Name}'s turn");
            _board.Print();
            Console.Write("What square do you want to play in? ");
            string input = Console.ReadLine()!;
            int tile = Convert.ToInt32(input);
            if (player.Play(_board, tile)) break;
            Console.WriteLine("Invalid play");
        }

        if (_board.IsGameOver())
        {
            _board.Print();
            Console.WriteLine($"{player.Name} won!");
            return false;
        }
        return true;
    }

    private class Player
    {
        public string Name { get; init; }
        public char Piece { get; init; }

        public Player(string name, char piece)
        {
            Name = name;
            Piece = piece;
        }

        public bool Play(Board board, int tile)
        {
            return board.Play(tile, Piece);
        }
    }

    private class Board
    {
        private static int Width = 3;
        private static int Height = 3;
        private char[,] _board = new char[Width, Height];

        public Board()
        {
            for (int row = 0; row < Height; row++)
                for (int col = 0; col < Width; col++)
                    _board[col, row] = ' ';
        }

        public void Print()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    Console.Write($" {_board[col, row]} ");
                    if (col < Width - 1) Console.Write("|");
                }
                if (row < Height - 1) Console.WriteLine("\n---+---+---");
            }
            Console.WriteLine();
        }

        public bool IsGameOver()
        {
            char piece;
            piece = GetPieceAt(1);
            if (piece != ' ')
            {
                if (piece == GetPieceAt(5) && piece == GetPieceAt(9)) return true;
                if (piece == GetPieceAt(4) && piece == GetPieceAt(7)) return true;
                if (piece == GetPieceAt(2) && piece == GetPieceAt(3)) return true;
            }
            piece = GetPieceAt(4);
            if (piece != ' ')
            {
                if (piece == GetPieceAt(5) && piece == GetPieceAt(6)) return true;
            }
            piece = GetPieceAt(7);
            if (piece != ' ')
            {
                if (piece == GetPieceAt(8) && piece == GetPieceAt(9)) return true;
                if (piece == GetPieceAt(5) && piece == GetPieceAt(3)) return true;
            }
            piece = GetPieceAt(2);
            if (piece != ' ')
            {
                if (piece == GetPieceAt(5) && piece == GetPieceAt(8)) return true;
            }
            piece = GetPieceAt(3);
            if (piece != ' ')
            {
                if (piece == GetPieceAt(6) && piece == GetPieceAt(9)) return true;
            }
            return false;
        }

        private char GetPieceAt(int tile)
        {
            int col = (tile - 1) % 3;
            int row = (_board.Length - tile) / 3;
            return _board[col, row];
        }

        public bool Play(int tile, char piece)
        {
            int col = (tile - 1) % 3;
            int row = (_board.Length - tile) / 3;
            if (_board[col, row] != ' ') return false;
            _board[col, row] = piece;
            return true;
        }
    }
}

