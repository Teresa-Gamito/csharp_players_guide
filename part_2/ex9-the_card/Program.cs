Card[] deck = Card.Deck();

foreach (Card card in deck)
    card.Print();


public class Card
{
    public Color Color { get; init; }
    public Rank Rank { get; init; }

    public Card(Color color, Rank rank)
    {
        Color = color;
        Rank = rank;
    }

    public bool IsFace()
    {
        return Rank >= Rank.Dollar;
    }

    public static Card[] Deck()
    {
        int deckSize = (int)Color.Count * (int)Rank.Count;
        Card[] deck = new Card[deckSize];

        for (int i = 0; i < deck.Length; i++)
        {
            Color color = (Color)(i / (deckSize / (int)Color.Count));
            Rank rank = (Rank)(i % (int)Rank.Count);
            deck[i] = new Card(color, rank);
        }

        return deck;
    }

    public void Print()
    {
        Console.WriteLine($"The {Color} {Rank}");
    }
}

public enum Color
{
    Red,
    Green,
    Blue,
    Yellow,

    Count
}

public enum Rank
{
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Dollar,
    Percent,
    Caret,
    Ampersand,

    Count
}
