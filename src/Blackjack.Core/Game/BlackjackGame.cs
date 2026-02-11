using Blackjack.Core.Models;

namespace Blackjack.Core.Game;

public sealed class BlackjackGame
{
    private readonly Deck _deck;

    public GameState State { get; } = new();

    public BlackjackGame(Deck? deck = null)
    {
        _deck = deck ?? new Deck();
    }

    public void StartNewRound()
    {
        State.PlayerHand.Clear();
        State.DealerHand.Clear();
        _deck.Reset();

        State.PlayerHand.Add(_deck.DrawCard());
        State.DealerHand.Add(_deck.DrawCard());
        State.PlayerHand.Add(_deck.DrawCard());
        State.DealerHand.Add(_deck.DrawCard());

        bool playerBlackjack = State.PlayerHand.IsBlackjack;
        bool dealerBlackjack = State.DealerHand.IsBlackjack;

        if (playerBlackjack && dealerBlackjack)
        {
            EndRound(RoundResult.Push);
        }
        else if (playerBlackjack)
        {
            EndRound(RoundResult.PlayerWin);
        }
        else if (dealerBlackjack)
        {
            EndRound(RoundResult.DealerWin);
        }
        else
        {
            State.Phase = GamePhase.PlayerTurn;
        }

    }

    public void Hit()
    {
        
        State.PlayerHand.Add(_deck.DrawCard());
        if (State.PlayerHand.IsBust)
        {
            EndRound(RoundResult.PlayerBust);
        }

    }

    public void Stand()
    {
        while (State.DealerHand.BestScore < 17)
        {
            State.DealerHand.Add(_deck.DrawCard());
        }

        if (State.DealerHand.IsBust)
        {
            EndRound(RoundResult.DealerBust);
        }
        else if (State.DealerHand.BestScore > State.PlayerHand.BestScore)
        {
            EndRound(RoundResult.DealerWin);
        }
        else if (State.DealerHand.BestScore < State.PlayerHand.BestScore)
        {
            EndRound(RoundResult.PlayerWin);
        }
        else
        {
            EndRound(RoundResult.Push);
        }
    }

    private void EndRound(RoundResult result)
    {
        State.Result = result;
        State.Phase = GamePhase.RoundOver;
    }

    private void EnsurePhase(GamePhase expected)
    {
        if (State.Phase != expected)
        {
            throw new InvalidOperationException($"Invalid game phase. Expected: {expected}, Actual: {State.Phase}");
        }
    }
}
