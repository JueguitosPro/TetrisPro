using System.Globalization;
using TMPro;
using UnityEngine;

namespace JueguitosPro
{
    public class LeaderboardEntry : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI rankText;
        [SerializeField] private TextMeshProUGUI usernameText;
        [SerializeField] private TextMeshProUGUI scoreText;

        public void InitLeaderboardEntry(int rank, string username, float score)
        {
            rankText.SetText(rank.ToString());
            usernameText.SetText(username);
            scoreText.SetText(score.ToString(CultureInfo.InvariantCulture));
        }
    }
}
