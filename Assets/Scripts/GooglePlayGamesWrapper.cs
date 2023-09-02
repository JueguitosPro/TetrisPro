using System;
using System.Collections.Generic;
using System.Linq;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

namespace JueguitosPro
{ 
    /// <summary>
    /// Wrapper class that interacts with Google Play Games. It handles Authentication, and Leaderboards communication
    /// </summary>
    public static class GooglePlayGamesWrapper
    {
        /// <summary>
        /// Returns true when there is an account authenticated with Google Play Games
        /// </summary>
        public static bool IsAuthenticated => PlayGamesPlatform.Instance.IsAuthenticated();

        /// <summary>
        /// Authentication with Google Play Games
        /// </summary>
        /// <param name="authenticationCallback">Callback after authentication, true is it succeeded</param>
        public static void GooglePlayGamesAuthentication(Action<bool> authenticationCallback)
        {
            PlayGamesPlatform.Instance.Authenticate(status =>
            {
                authenticationCallback?.Invoke(status == SignInStatus.Success);
            });
        }

        /// <summary>
        /// Sets a new score to Google Play Games leaderboard
        /// </summary>
        /// <param name="score">New score to set to the leaderboard</param>
        /// <param name="setScoreCallback">Callback after score registration</param>
        public static void SetLeaderboardScore(long score, Action<bool> setScoreCallback = null)
        {
            Social.ReportScore(score, GPGSIds.leaderboard_high_score, setScoreCallback);
        }

        /// <summary>
        /// Gets the Game's leaderboard from Google Play Games
        /// </summary>
        /// <param name="getLeaderboardCallback">Callback after getting the leaderboard</param>
        public static void GetLeaderboard(Action<List<LeaderboardData>> getLeaderboardCallback)
        {
            PlayGamesPlatform.Instance.LoadScores(
                GPGSIds.leaderboard_high_score,
                LeaderboardStart.TopScores,
                10,
                LeaderboardCollection.Public,
                LeaderboardTimeSpan.AllTime,
                data =>
                {
                    List<LeaderboardData> leaderboardData = data.Scores.Select(score => 
                        new LeaderboardData
                        {
                            UserID = score.userID, 
                            Score = score.value, 
                            Rank = score.rank
                        }).ToList();

                    getLeaderboardCallback?.Invoke(leaderboardData);
                });
        }

        // Holi
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
