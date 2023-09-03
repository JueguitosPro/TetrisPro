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

        /// <summary>
        /// Retrieves user information and sets it in the game manager.
        /// </summary>
        /// <param name="getUserInformationCallback">Callback function to handle the retrieval of user information.</param>
        public void GetUserInformation(Action getUserInformationCallback)
        {
            GooglePlayGamesWrapper.GetLeaderboard(true, 1, leaderboardData =>
            {
                UserData userData = new UserData
                {
                    UserId = GooglePlayGamesWrapper.LocalUser.id
                };
                
                foreach (var data in leaderboardData)
                {
                    if (data.UserID == GooglePlayGamesWrapper.LocalUser.id)
                    {
                        userData.UserHighestScore = data.Score;
                    }
                }
                
                GameManager.Instance.DataManager.SetUserData(userData);
                getUserInformationCallback?.Invoke();
            });
        }
    }
}
