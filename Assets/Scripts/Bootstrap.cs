using GooglePlayGames;
using JueguitosPro.GameStates;
using UnityEngine;

namespace JueguitosPro
{
    /// <summary>
    /// The `Bootstrap` class initializes and configures the game upon startup.
    /// </summary>
    public class Bootstrap : MonoBehaviour
    {
        private void Awake()
        {
            // recommended for debugging:
            PlayGamesPlatform.DebugLogEnabled = true;

            // Activate the Google Play Games platform
            PlayGamesPlatform.Activate();
        }

        private void Start()
        {
            GameManager.Instance = new GameManager();

            GameManager.Instance.GameStateManager.AddState(new GameStateLoading
            {
                PrefabPath = Constants.LoadingView
            });
        }
    }
}
