using System;
using System.Collections.Generic;
using System.Linq;

namespace JueguitosPro.Models
{
    /// <summary>
    /// Represents a model for managing leaderboards data.
    /// </summary>
    public class LeaderboardModel : ModelBase
    {
        private event Action<List<LeaderboardData>> onLeaderboardsEvent;

        /// <summary>
        /// Retrieves the leaderboard data and invokes the provided callback when complete.
        /// </summary>
        /// <param name="onGetLeaderboards">Callback to be invoked with the leaderboard data.</param>
        public void GetLeaderboard(Action<List<LeaderboardData>> onGetLeaderboards)
        {
            onLeaderboardsEvent += onGetLeaderboards;
            GooglePlayGamesWrapper.GetLeaderboard(false, 10, LeaderboardsCallback);
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
