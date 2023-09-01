using System;
using System.Collections.Generic;
using System.Linq;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

namespace JueguitosPro
{ 
    public static class GooglePlayGamesWrapper
    {
        public static bool IsAuthenticated => PlayGamesPlatform.Instance.IsAuthenticated();

        public static void GooglePlayGamesAuthentication(Action<bool> authenticationCallback)
        {
            PlayGamesPlatform.Instance.Authenticate(status =>
            {
                authenticationCallback?.Invoke(status == SignInStatus.Success);
            });
        }

        public static void SetLeaderboardScore(long score, Action<bool> setScoreCallback = null)
        {
            Social.ReportScore(score, GPGSIds.leaderboard_high_score, setScoreCallback);
        }

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
