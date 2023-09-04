using System;

namespace JueguitosPro.Models
{
    /// <summary>
    /// Represents a model for managing scores and set them in a leaderboard.
    /// </summary>
    public class ScoreModel : ModelBase
    {
        private int score;
        
        /// <summary>
        /// Checks if the provided score is a new high score.
        /// </summary>
        /// <param name="score">The score to check.</param>
        /// <returns>True if the score is a new high score, false otherwise.</returns>
        public bool IsHighScore(int score)
        {
            this.score = score;
            if (score <= GameManager.Instance.DataManager.UserData.UserHighestScore)
            {
                return false;
            }
            
            GameManager.Instance.DataManager.UserData.UserHighestScore = score;
            return true;
        }
        
        /// <summary>
        /// Sets the player's score on the leaderboard and invokes the provided callback upon completion.
        /// </summary>
        /// <param name="score">The player's score to set on the leaderboard.</param>
        /// <param name="setScoreCallback">A callback to be invoked with the result of setting the score.</param>
        public void SetLeaderboardScore(Action<bool> setScoreCallback)
        {
            if (GooglePlayGamesWrapper.IsAuthenticated)
            {
                GooglePlayGamesWrapper.SetLeaderboardScore(score, setScoreCallback);
                return;
            }
            
            setScoreCallback?.Invoke(false);
        }
    }
}
