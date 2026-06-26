Game game = new Game("LuniIsTheBest");

Console.Clear();

while (game.PlayRound());

public class Game
{
    private Word _word;
    private bool[] _triedLetters = new bool[26];

    private int MaxTries { get; } = 5;
    private int _tries = 0;

    public Game(string word)
    {
        _word = new Word(word);
    }

    public bool PlayRound()
    {
        PrintStatus();
        string input = Console.ReadLine()!;

        char guess = input[0];
        GuessLetter(guess);

        if (_word.IsGuessed())
        {
            Console.WriteLine("You won :3");
            return false;
        }
        if (MaxTries - _tries <= 0)
        {
            Console.WriteLine("You lost :(");
            return false;
        }

        return true;
    }

    public void PrintStatus()
    {
        Console.Write($"Word: ");
        _word.Print();

        if (_word.IsGuessed()) return;

        Console.Write(" | ");
        Console.Write($"Remaining: {MaxTries - _tries}");
        Console.Write(" | ");
        Console.Write("Incorrect: ");
        PrintIncorrectLetters();
        Console.Write(" | ");

        Console.Write("Guess: ");
    }

    public void PrintIncorrectLetters()
    {
        for (int i = 0; i < _triedLetters.Length; i++)
        {
            if (_triedLetters[i])
            {
                char letter = (char)(i + 'A');
                if (_word.HasLetter(letter)) continue;
                Console.Write(letter);
            }
        }
    }

    public void GuessLetter(char letter)
    {
        if (!char.IsLetter(letter))
        {
            return;
        }

        int index = char.ToUpper(letter) - 'A';
        if (_triedLetters[index])
        {
            Console.WriteLine("Letter already tried");
            return;
        }

        _triedLetters[index] = true;

        if (_word.GuessLetter(letter))
        {
            Console.WriteLine("Correct guess");
        }
        else
        {
            Console.WriteLine("Incorrect guess");
            _tries++;
        }
    }
}

public class Word
{
    private string _word;
    private bool[] _guessedLetters;

    public Word(string word)
    {
        _word = word;
        _guessedLetters = new bool[_word.Length];
    }

    public bool GuessLetter(char letter)
    {
        letter = char.ToUpper(letter);
        bool hasLetter = false;
        for (int i = 0; i < _word.Length; i++)
        {
            char c = char.ToUpper(_word[i]);
            if (c == letter)
            {
                _guessedLetters[i] = true;
                hasLetter = true;
            }
        }
        return hasLetter;
    }

    public bool HasLetter(char letter)
    {
        foreach (char c in _word)
        {
            char temp = char.ToUpper(c);
            letter = char.ToUpper(letter);
            if (temp == letter) return true;
        }
        return false;
    }

    public bool IsGuessed()
    {
        foreach (bool guess in _guessedLetters)
        {
            if (guess == false) return false;
        }
        return true;
    }

    public void Print()
    {
        for (int i = 0; i < _word.Length; i++)
        {
            if (_guessedLetters[i])
            {
                Console.Write(_word[i]);
            }
            else
            {
                Console.Write("_");
            }
            Console.Write(" ");
        }
    }
}
