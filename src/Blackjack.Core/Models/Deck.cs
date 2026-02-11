namespace Blackjack.Core.Models;

public class Deck
{
    private readonly List<Card> _cards;
    public int Count => _cards.Count;
    public Deck()
    {
        _cards = new List<Card>();
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                _cards.Add(new Card(suit, rank));
            }
        }
    }

    public void Shuffle()
    {
        Random rng = new Random();
        int n = _cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = _cards[k];
            _cards[k] = _cards[n];
            _cards[n] = value;
        }
    }

    public Card DrawCard()
    {
        if (_cards.Count == 0)
            throw new InvalidOperationException("No more cards in the deck.");

        Card card = _cards[0];
        _cards.RemoveAt(0);
        return card;
    }

    public void Dump()
    {
        foreach (var card in _cards)
        {
            Console.WriteLine(card);
        }
    }

    public void Reset(bool shuffle = true)
    {
        _cards.Clear();
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                _cards.Add(new Card(suit, rank));
            }
        }
        if (shuffle)
        {
            Shuffle();
        }
    }       
}