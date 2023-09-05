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
    }
}
