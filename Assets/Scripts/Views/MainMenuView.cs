using System;
using JueguitosPro.Views;
using UnityEngine;
using UnityEngine.UI;

namespace JueguitosPro
{
    public class MainMenuView : ViewBase
    {
        [SerializeField] private Button playGameButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button loginWithGoogleButton;

        public event Action onPlayGameButtonClicked;
        public event Action onSettingsButtonClicked;
        public event Action onLoginWithGoogleButtonClicked;

        public override void Show(Action onShow = null)
        {
            base.Show(onShow);
            playGameButton.onClick.AddListener(OnPlayGameButtonClicked);
            settingsButton.onClick.AddListener(OnSettingsButtonClicked);
            loginWithGoogleButton.onClick.AddListener(OnLoginWithGoogleButtonClicked);
        }

        public override void Hide(Action onHide = null)
        {
            base.Hide(onHide);
            playGameButton.onClick.RemoveListener(OnPlayGameButtonClicked);
            settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
            loginWithGoogleButton.onClick.RemoveListener(OnLoginWithGoogleButtonClicked);
        }

        private void OnPlayGameButtonClicked()
        {
            onPlayGameButtonClicked?.Invoke();
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
