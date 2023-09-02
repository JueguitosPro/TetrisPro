using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JueguitosPro.Models
{
    public class MainMenuModel : ModelBase
    {
        public bool IsAuthenticated => GooglePlayGamesWrapper.IsAuthenticated;

        public void PlayGamesAuthentication(Action<bool> authenticationCallback)
        {
            GooglePlayGamesWrapper.GooglePlayGamesAuthentication(authenticationCallback);
        }

        public void SetLeaderboardScore(float score, Action<bool> setScoreCallback)
        {
            GooglePlayGamesWrapper.SetLeaderboardScore((long)score, setScoreCallback);
        }
    }
}
