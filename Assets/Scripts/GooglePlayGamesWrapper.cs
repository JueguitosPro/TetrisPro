using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

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
    }
}
