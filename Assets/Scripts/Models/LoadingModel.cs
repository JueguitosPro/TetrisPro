using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

namespace JueguitosPro.Models
{
    public class LoadingModel : ModelBase
    {
        public void PlayGoogleGamesAuthentication(Action<bool> authenticateCallback)
        {
            PlayGamesPlatform.Instance.Authenticate(status =>
            {
                authenticateCallback?.Invoke(status == SignInStatus.Success);
            });
        }
    }
}
