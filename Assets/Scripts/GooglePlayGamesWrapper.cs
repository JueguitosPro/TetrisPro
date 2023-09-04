using System;
using System.Collections.Generic;
using System.Linq;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace JueguitosPro
{
    /// <summary>
    /// A static class providing access to Google Play Games functionality.
    /// </summary>
    public static class GooglePlayGamesWrapper
    {
        /// <summary>
        /// Checks if the player is authenticated in Google Play Games.
        /// </summary>
        public static bool IsAuthenticated => PlayGamesPlatform.Instance.IsAuthenticated();

        /// <summary>
        /// Gets the local user if authenticated, or returns null.
        /// </summary>
        public static ILocalUser LocalUser
        {
            get
            {
                if (IsAuthenticated)
                {
                    return Social.localUser;
                }

                return null;
            }
        }

        /// <summary>
        /// Authenticate the player with Google Play Games.
        /// </summary>
        /// <param name="authenticationCallback">Callback to invoke after authentication.</param>
        public static void GooglePlayGamesAuthentication(Action<bool> authenticationCallback)
        {
            PlayGamesPlatform.Instance.Authenticate(status =>
            {
                authenticationCallback?.Invoke(status == SignInStatus.Success);
            });
        }

        /// <summary>
        /// Sets the player's score on a leaderboard.
        /// </summary>
        /// <param name="score">The player's score to set.</param>
        /// <param name="setScoreCallback">Callback to invoke after setting the score (optional).</param>
        public static void SetLeaderboardScore(long score, Action<bool> setScoreCallback = null)
        {
            Social.ReportScore(score, GPGSIds.leaderboard_high_score, setScoreCallback);
        }

        /// <summary>
        /// Gets the leaderboard data.
        /// </summary>
        /// <param name="isPlayerCentered">Indicates whether the player's score should be at the center of the leaderboard.</param>
        /// <param name="rowCount">The number of leaderboard entries to retrieve.</param>
        /// <param name="getLeaderboardCallback">Callback to invoke with the leaderboard data.</param>
        public static void GetLeaderboard(bool isPlayerCentered, int rowCount,
            Action<List<LeaderboardData>> getLeaderboardCallback)
        {
            PlayGamesPlatform.Instance.LoadScores(
                GPGSIds.leaderboard_high_score,
                isPlayerCentered ? LeaderboardStart.PlayerCentered : LeaderboardStart.TopScores,
                rowCount,
                LeaderboardCollection.Public,
                LeaderboardTimeSpan.AllTime,
                data =>
                {
                    List<LeaderboardData> leaderboardData = data.Scores.Select(score => 
                        new LeaderboardData
                        {
                            UserID = score.userID, 
                            Score = (int)score.value, 
                            Rank = score.rank
                        }).ToList();

                    getLeaderboardCallback?.Invoke(leaderboardData);
                });
        }

        /// <summary>
        /// Gets the usernames associated with the given user IDs.
        /// </summary>
        /// <param name="usersID">List of user IDs.</param>
        /// <param name="getUsersCallback">Callback to invoke with the user IDs and usernames.</param>
        public static void GetUsernameWithUserID(List<string> usersID, Action<Dictionary<string,string>> getUsersCallback)
        {
            Social.LoadUsers(usersID.ToArray(), users =>
            {
                Dictionary<string, string> usersDictionary = users.ToDictionary(user => user.id, user => user.userName);

                getUsersCallback?.Invoke(usersDictionary);
            });
        }
    }
}
