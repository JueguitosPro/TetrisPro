using JueguitosPro.GameStates;
using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.Controllers
{
    /// <summary>
    /// ScoreController handles the control logic for managing scores in the game.
    /// </summary>
    public class ScoreController : ControllerBase<ScoreModel,ScoreView>
    {
        /// <summary>
        /// Initializes a new instance of the ScoreController class.
        /// </summary>
        /// <param name="model">The score model.</param>
        /// <param name="view">The score view.</param>
        /// <param name="score">The initial score.</param>
        public ScoreController(ScoreModel model, ScoreView view, int score) : base(model, view)
        {
            view.onContinueButtonClicked += OnContinueButtonClicked;
            view.SetScore(score, model.IsHighScore(score));
        }

        private void OnContinueButtonClicked()
        {
            SetLeaderboardScore();
        }
        
        private void SetLeaderboardScore()
        {
            model.SetLeaderboardScore(success =>
            {
                GameManager.Instance.GameStateManager.PopStatesUntil<GameStateMainMenu>();
            });
        }
    }
}
