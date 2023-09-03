using System;

namespace JueguitosPro.Models
{
    /// <summary>
    /// Model class for managing loading-related functionality.
    /// </summary>
    public class LoadingModel : ModelBase
    {
        /// <summary>
        /// Initiates Google Play Games authentication.
        /// </summary>
        /// <param name="authenticationCallback">Callback function to handle authentication result.</param>
        public void PlayGamesAuthentication(Action<bool> authenticationCallback)
        {
            GooglePlayGamesWrapper.GooglePlayGamesAuthentication(authenticationCallback);
        }
    }
}
