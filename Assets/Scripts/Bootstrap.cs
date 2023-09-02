using GooglePlayGames;
using JueguitosPro.GameStates;
using UnityEngine;

namespace JueguitosPro
{
    /// <summary>
    /// Inits the game instantiating our <see cref="GameManager"/> and the first <see cref="GameStateBase"/>
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
