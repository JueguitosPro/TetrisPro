using System;
using JueguitosPro.Views;
using UnityEngine;
using UnityEngine.UI;

namespace JueguitosPro
{
    /// <summary>
    /// Represents the main menu view in the game.
    /// </summary>
    public class MainMenuView : ViewBase
    {
        [SerializeField] private Button playGameButton;
        [SerializeField] private Button leaderboardButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button playGamesLoginButton;

        /// <summary>
        /// Event triggered when the Play Game button is clicked.
        /// </summary>
        public event Action onPlayGameButtonClicked;

        /// <summary>
        /// Event triggered when the Leaderboard button is clicked.
        /// </summary>
        public event Action onLeaderboardButtonClicked;

        /// <summary>
        /// Event triggered when the Settings button is clicked.
        /// </summary>
        public event Action onSettingsButtonClicked;

        /// <summary>
        /// Event triggered when the Login with Google button is clicked.
        /// </summary>
        public event Action onLoginWithGoogleButtonClicked;

        /// <inheritdoc/>
        public override void Show(Action onShow = null)
        {
            base.Show(onShow);
            playGameButton.onClick.AddListener(OnPlayGameButtonClicked);
            leaderboardButton.onClick.AddListener(OnLeaderboardButtonClicked);
            settingsButton.onClick.AddListener(OnSettingsButtonClicked);
            playGamesLoginButton.onClick.AddListener(OnLoginWithGoogleButtonClicked);
        }

        /// <inheritdoc/>
        public override void Hide(Action onHide = null)
        {
            base.Hide(onHide);
            playGameButton.onClick.RemoveListener(OnPlayGameButtonClicked);
            leaderboardButton.onClick.RemoveListener(OnLeaderboardButtonClicked);
            settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
            playGamesLoginButton.onClick.RemoveListener(OnLoginWithGoogleButtonClicked);
        }

        private void OnDestroy()
        {
            onPlayGameButtonClicked = null;
            onLeaderboardButtonClicked = null;
            onSettingsButtonClicked = null;
            onLoginWithGoogleButtonClicked = null;
        }

        /// <summary>
        /// Allows enabling or disabling the Play Games login button.
        /// </summary>
        /// <param name="enableLogin">True to enable, false to disable the login button.</param>
        public void AllowPlayGamesLogin(bool enableLogin)
        {
            playGamesLoginButton.gameObject.SetActive(enableLogin);
        }

        private void OnPlayGameButtonClicked()
        {
            onPlayGameButtonClicked?.Invoke();
        }

        private void OnLeaderboardButtonClicked()
        {
            onLeaderboardButtonClicked?.Invoke();
        }

        private void OnSettingsButtonClicked()
        {
            onSettingsButtonClicked?.Invoke();
        }
        
        private void OnLoginWithGoogleButtonClicked()
        {
            onLoginWithGoogleButtonClicked?.Invoke();
        }
    }
}
