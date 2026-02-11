namespace Blackjack.Core.Models;

public sealed class Hand
{
    private readonly List<Card> _cards = new();

    public IReadOnlyList<Card> Cards => _cards;

    public void Add(Card card)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public int BestScore
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public bool IsBlackjack
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public bool IsBust
    {
        get
        {
            throw new NotImplementedException();
        }
    }
}
