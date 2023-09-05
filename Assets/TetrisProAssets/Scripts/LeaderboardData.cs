
namespace JueguitosPro
{
    /// <summary>
    /// Represents leaderboard data for a user including their ID, username, score, and rank.
    /// </summary>
    public class LeaderboardData
    {
        /// <summary>
        /// Gets or sets the unique user ID associated with the leaderboard data.
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// Gets or sets the username of the user associated with the leaderboard data.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the user's score in the leaderboard.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets the rank of the user in the leaderboard.
        /// </summary>
        public int Rank { get; set; }
    }
}
