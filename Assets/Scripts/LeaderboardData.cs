
namespace JueguitosPro
{
    /// <summary>
    /// Holds the data used to show Leaderboards
    /// </summary>
    public class LeaderboardData
    {
        /// <summary>
        /// Id of the user that is registered in the leaderboard
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// Username of the player registered in the leaderboard
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// User's high score
        /// </summary>
        public float Score { get; set; }
        /// <summary>
        /// User's rank in the leaderboard
        /// </summary>
        public int Rank { get; set; }
    }
}
