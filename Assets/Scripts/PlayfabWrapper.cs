using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using PlayFab;
using UnityEngine;
using PlayFab.ClientModels;

namespace JueguitosPro
{
    public static class PlayfabWrapper
    {
        public static void LoginWithDeviceID(Action<LoginResult> onSuccess, Action<string> onFailure)
        {
            //Get the device id from native android
            AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = up.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject contentResolver = currentActivity.Call<AndroidJavaObject>("getContentResolver");
            AndroidJavaClass secure = new AndroidJavaClass("android.provider.Settings$Secure");
            string deviceId = secure.CallStatic<string>("getString", contentResolver, "android_id");
            
            #if UNITY_ANDROID
            PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest()
            {
                TitleId = PlayFabSettings.TitleId,
                AndroidDevice = SystemInfo.deviceModel,
                OS = SystemInfo.operatingSystem,
                AndroidDeviceId = deviceId,
                CreateAccount = true
            }, result =>
            {
                onSuccess?.Invoke(result);
            }, error =>
            {
                onFailure?.Invoke(error.ErrorMessage);
            });
            #endif
            #if UNITY_IOS
            #endif
        }
        
        public static void LoginWithGoogle(Action<LoginResult> onSuccess, Action<string> onFailure)
        {
            PlayGamesPlatform.Instance.Authenticate(success => {
                if (success == SignInStatus.Success)
                {
                    PlayGamesPlatform.Instance.RequestServerSideAccess(false, code =>
                    {
                        Debug.Log("Server Auth Code: " + code);
                    
                        PlayFabClientAPI.LoginWithGooglePlayGamesServices(new LoginWithGooglePlayGamesServicesRequest()
                        {
                            TitleId = PlayFabSettings.TitleId,
                            ServerAuthCode = code,
                            CreateAccount = true
                        }, (result) =>
                        {
                            onSuccess?.Invoke(result);
                        }, error =>
                        {
                            onFailure?.Invoke(error.ErrorMessage);
                        } );
                    });
                }
                else
                {
                    onFailure?.Invoke("Fail to Authenticate");
                }
            });
        }
    }
}
