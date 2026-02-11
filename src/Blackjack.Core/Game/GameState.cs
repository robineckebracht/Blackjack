
using Blackjack.Core.Models;

namespace Blackjack.Core.Game;

public sealed class GameState
{
    public Hand PlayerHand { get; } = new();
    public Hand DealerHand { get; } = new();

    public GamePhase Phase { get; internal set; } = GamePhase.NotStarted;
    public RoundResult Result { get; internal set; } = RoundResult.None;

    public bool IsRoundOver
    {
        get
        {
            return Phase == GamePhase.RoundOver;
        }
    }
}
