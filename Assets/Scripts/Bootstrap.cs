using GooglePlayGames;
using JueguitosPro.GameModes;
using UnityEngine;

namespace JueguitosPro
{
    public class Bootstrap : MonoBehaviour
    {
        private void Awake()
        {
            // recommended for debugging:
            PlayGamesPlatform.DebugLogEnabled = true;

            // Activate the Google Play Games platform
            PlayGamesPlatform.Activate();
        }

        void Start()
        {
            GameManager.Instance = new GameManager();
            
            GameManager.Instance.GameModeManager.Add(new GameModeLogin()
            {
                ViewPrefabPath = AssetManifest.LoginView
            });
        }
    }
}
