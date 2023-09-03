using System;
using JueguitosPro.Controllers;
using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.GameStates
{
    /// <summary>
    /// Represents a game state for the leaderboard screen.
    /// </summary>
    public class GameStateLeaderboard : GameStateBase
    {
        /// <inheritdoc/>
        public override void OnCreate(Action onCreated = null)
        {
            InstantiateView<LeaderboardView>(MainUI.CanvasLayer.Overlay, view =>
            {
                onCreated?.Invoke();
                LeaderboardModel model = new LeaderboardModel();
                LeaderboardController controller = new LeaderboardController(model, view);
            });
        }
    }
}
