namespace Blackjack.Core.Models;

public sealed class Hand
{
    private readonly List<Card> _cards = new();

    public IReadOnlyList<Card> Cards => _cards;

    public void Add(Card card)
    {
        _cards.Add(card);
    }

    public void Clear()
    {
        _cards.Clear();
    }

    public int BestScore
    {
        get
        {
            int score = 0;
            int aceCount = 0;

            foreach (var card in _cards)
            {
                if (card.Rank == Rank.Ace)
                {
                    aceCount++;
                    score += 11; 
                }
                else if (card.Rank >= Rank.Jack && card.Rank <= Rank.King)
                {
                    score += 10;
                }
                else
                {
                    score += (int)card.Rank;
                }
            }   

            while (score > 21 && aceCount > 0)
            {
                score -= 10;
                aceCount--;
            }

            return score;
        }
    }

    public bool IsBlackjack
    {
        get
        {
            return _cards.Count == 2 && BestScore == 21;
        }
    }

    public bool IsBust
    {
        get 
        {
            if (BestScore > 21)
            {
                return true;
            }
            return false;
        }
    }
}
