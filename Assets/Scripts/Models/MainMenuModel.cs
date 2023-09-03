using System;

namespace JueguitosPro.Models
{
    /// <summary>
    /// Represents the model for the main menu, providing access to authentication and leaderboard functionality.
    /// </summary>
    public class MainMenuModel : ModelBase
    {
        /// <summary>
        /// Gets a value indicating whether the user is authenticated with Google Play Games.
        /// </summary>
        public bool IsAuthenticated => GooglePlayGamesWrapper.IsAuthenticated;

        /// <summary>
        /// Authenticates the user with Google Play Games and invokes the provided callback upon completion.
        /// </summary>
        /// <param name="authenticationCallback">A callback to be invoked with the authentication result.</param>
        public void PlayGamesAuthentication(Action<bool> authenticationCallback)
        {
            GooglePlayGamesWrapper.GooglePlayGamesAuthentication(authenticationCallback);
        }

        /// <summary>
        /// Sets the player's score on the leaderboard and invokes the provided callback upon completion.
        /// </summary>
        /// <param name="score">The player's score to set on the leaderboard.</param>
        /// <param name="setScoreCallback">A callback to be invoked with the result of setting the score.</param>
        public void SetLeaderboardScore(float score, Action<bool> setScoreCallback)
        {
            GooglePlayGamesWrapper.SetLeaderboardScore((long)score, setScoreCallback);
        }
    }
}
