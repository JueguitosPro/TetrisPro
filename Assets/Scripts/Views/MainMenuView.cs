using System;
using JueguitosPro.Views;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace JueguitosPro
{
    public class MainMenuView : ViewBase
    {
        [SerializeField] private Button playGameButton;
        [SerializeField] private Button leaderboardButton;
        [SerializeField] private Button setLeaderboardScoreButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button playGamesLoginButton;

        public event Action onPlayGameButtonClicked;
        public event Action onLeaderboardButtonClicked;
        public event Action onSetLeaderboardScoreButtonClicked;
        public event Action onSettingsButtonClicked;
        public event Action onLoginWithGoogleButtonClicked;

        public override void Show(Action onShow = null)
        {
            base.Show(onShow);
            playGameButton.onClick.AddListener(OnPlayGameButtonClicked);
            leaderboardButton.onClick.AddListener(OnLeaderboardButtonClicked);
            setLeaderboardScoreButton.onClick.AddListener(OnSetLeaderboardScoreButtonClicked);
            settingsButton.onClick.AddListener(OnSettingsButtonClicked);
            playGamesLoginButton.onClick.AddListener(OnLoginWithGoogleButtonClicked);
        }

        public override void Hide(Action onHide = null)
        {
            base.Hide(onHide);
            playGameButton.onClick.RemoveListener(OnPlayGameButtonClicked);
            leaderboardButton.onClick.RemoveListener(OnLeaderboardButtonClicked);
            setLeaderboardScoreButton.onClick.RemoveListener(OnSetLeaderboardScoreButtonClicked);
            settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
            playGamesLoginButton.onClick.RemoveListener(OnLoginWithGoogleButtonClicked);
        }

        private void OnDestroy()
        {
            onPlayGameButtonClicked = null;
            onLeaderboardButtonClicked = null;
            onSetLeaderboardScoreButtonClicked = null;
            onSettingsButtonClicked = null;
            onLoginWithGoogleButtonClicked = null;
        }

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

        private void OnSetLeaderboardScoreButtonClicked()
        {
            onSetLeaderboardScoreButtonClicked?.Invoke();
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
