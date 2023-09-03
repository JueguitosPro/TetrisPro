using System.Collections.Generic;
using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.Controllers
{
    /// <summary>
    /// Handles Leaderboard Game State to show and update leaderboard data
    /// </summary>
    public class LeaderboardController : ControllerBase<LeaderboardModel,LeaderboardView>
    {
        /// <inheritdoc/>
        public LeaderboardController(LeaderboardModel model, LeaderboardView view) : base(model, view)
        {
            view.onBackButtonClicked += OnBackButtonClicked;
#if UNITY_EDITOR
            // Mock Leaderboard Data
            List<LeaderboardData> leaderboardData = new List<LeaderboardData>()
            {
                new() { Rank = 1, Score = 100, Username = "Juan", UserID = "fsdfg46ds54" },
                new() { Rank = 2, Score = 95, Username = "Pedro", UserID = "fdsafsdf" },
                new() { Rank = 3, Score = 90, Username = "Jose", UserID = "fsdfg46hghgds54" },
                new() { Rank = 4, Score = 85, Username = "Emilio", UserID = "fsdfg4fgdhwer6ds54" },
                new() { Rank = 5, Score = 80, Username = "Follador25", UserID = "fdsf" }
            };
            
            view.SetLeaderboard(leaderboardData);
#else
            model.GetLeaderboard(GetLeaderboardsCallback);
#endif
        }

        private void GetLeaderboardsCallback(List<LeaderboardData> leaderboardData)
        {
            view.SetLeaderboard(leaderboardData);
        }

        private void OnBackButtonClicked()
        {
            GameManager.Instance.GameStateManager.PopState();
        }
    }
}
