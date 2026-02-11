using Blackjack.Core.Game;
using Blackjack.Core.Models;

namespace Blackjack.App;

internal static class Program
{
    private static void Main()
    {
        var game = new BlackjackGame();

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== Blackjack ===");
        Console.WriteLine("Commands: (n)ew round, (h)it, (s)tand, (q)uit");
        Console.WriteLine();

        game.StartNewRound();
        Render(game, revealDealerHoleCard: false);

        while (true)
        {
            Console.Write("> ");
            var input = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

            if (input is "q" or "quit")
                break;

            try
            {
                switch (input)
                {
                    case "n":
                    case "new":
                        game.StartNewRound();
                        Render(game, revealDealerHoleCard: false);
                        break;

                    case "h":
                    case "hit":
                        game.Hit();
                        Render(game, revealDealerHoleCard: game.State.IsRoundOver);
                        break;

                    case "s":
                    case "stand":
                        game.Stand();
                        Render(game, revealDealerHoleCard: true);
                        break;

                    default:
                        Console.WriteLine("Unknown command. Use n/h/s/q.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            if (game.State.IsRoundOver)
            {
                Console.WriteLine();
                Console.WriteLine($"Round Over: {game.State.Result}");
                Console.WriteLine("Type 'n' for next round or 'q' to quit.");
                Console.WriteLine();
            }
        }
    }

    private static void Render(BlackjackGame game, bool revealDealerHoleCard)
    {
        Console.WriteLine();
        Console.WriteLine($"Phase: {game.State.Phase} | Result: {game.State.Result}");
        Console.WriteLine();

        // Dealer anzeigen
        Console.WriteLine("Dealer:");
        RenderHand(game.State.DealerHand, hideSecondCard: !revealDealerHoleCard && !game.State.IsRoundOver);
        Console.WriteLine();

        // Player anzeigen
        Console.WriteLine("Player:");
        RenderHand(game.State.PlayerHand, hideSecondCard: false);
        Console.WriteLine();
    }

    private static void RenderHand(Hand hand, bool hideSecondCard)
    {
        // Karten
        for (int i = 0; i < hand.Cards.Count; i++)
        {
            if (hideSecondCard && i == 1)
            {
                Console.Write("[Hidden] ");
            }
            else
            {
                Console.Write($"{hand.Cards[i]}, ");
            }
        }

        Console.WriteLine();

        // Score
        if (hideSecondCard && hand.Cards.Count >= 2)
        {
            // Score nicht vollständig verraten
            Console.WriteLine("Score: ?");
        }
        else
        {
            Console.WriteLine($"Score: {hand.BestScore}");
        }
    }
}
