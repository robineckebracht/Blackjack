using Blackjack.Core.Models;

namespace Blackjack.Core.Game;

public sealed class BlackjackGame
{
    private readonly Deck _deck;

    public GameState State { get; } = new();

    public BlackjackGame(Deck? deck = null)
    {
        throw new NotImplementedException();
    }

    public void StartNewRound()
    {
        throw new NotImplementedException();
    }

    public void Hit()
    {
        throw new NotImplementedException();
    }

    public void Stand()
    {
        throw new NotImplementedException();
    }

    private void EndRound(RoundResult result)
    {
        throw new NotImplementedException();
    }

    private void EnsurePhase(GamePhase expected)
    {
        throw new NotImplementedException();
    }
}
