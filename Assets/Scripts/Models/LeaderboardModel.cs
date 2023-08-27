using System;
using System.Collections.Generic;
using System.Linq;

namespace JueguitosPro.Models
{
    public class LeaderboardModel : ModelBase
    {
        private event Action<List<LeaderboardData>> onLeaderboardsEvent;

        public void GetLeaderboard(Action<List<LeaderboardData>> onGetLeaderboards)
        {
            onLeaderboardsEvent += onGetLeaderboards;
            GooglePlayGamesWrapper.GetLeaderboard(LeaderboardsCallback);
        }
        
        private void LeaderboardsCallback(List<LeaderboardData> leaderboardsData)
        {
            List<string> usersID = leaderboardsData.Select(leaderboardData => leaderboardData.UserID).ToList();

            GooglePlayGamesWrapper.GetUsernameWithUserID(usersID, users =>
            {
                foreach (var leaderboardData in leaderboardsData)
                {
                    string username = users[leaderboardData.UserID];
                    leaderboardData.Username = username;
                }
                onLeaderboardsEvent?.Invoke(leaderboardsData);
                onLeaderboardsEvent = null;
            });
        }
    }
}
