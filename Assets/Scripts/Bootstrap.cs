using GooglePlayGames;
using JueguitosPro.GameStates;
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
            
            GameManager.Instance.GameStateManager.AddState(new GameStateLogin()
            {
                PrefabPath = Constants.LoadingView
            });
        }
    }
}
