using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

namespace JueguitosPro.Models
{
    public class LoadingModel : ModelBase
    {
        public void PlayGamesAuthentication(Action<bool> authenticationCallback)
        {
            GooglePlayGamesWrapper.GooglePlayGamesAuthentication(authenticationCallback);
        }
    }
}
