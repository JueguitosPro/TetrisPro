using System;
using JueguitosPro.Controllers;
using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.GameStates
{
    /// <summary>
    /// Represents a game state that manages the end game.
    /// </summary>
    public class GameStateScore : GameStateBase
    {
        /// <summary>
        /// The current score.
        /// </summary>
        public int Score;
        
        /// <inheritdoc/>
        public override void OnCreate(Action onCreated = null)
        {
            InstantiateView<ScoreView>(MainUI.CanvasLayer.Overlay, view =>
            {
                onCreated?.Invoke();
                ScoreModel model = new ScoreModel();
                ScoreController controller = new ScoreController(model, view, Score);
            });
        }
    }
}
