using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JueguitosPro.Views
{
    public class LoadingView : ViewBase
    {
        [SerializeField] private Button _googleLoginButton;
        [SerializeField] private TextMeshProUGUI _developerText;
        [SerializeField] private Image _progressBar;

        public event Action OnLoginWithGoogleClicked;

        public override void Show(Action onShow = null)
        {
            SetActive(true);
            onShow?.Invoke();
        }

        public override void Hide(Action onHide = null)
        {
            SetActive(false);
            onHide?.Invoke();
        }

        private void OnClickGoogleLogin()
        {
            OnLoginWithGoogleClicked?.Invoke();
        }

        public void SetDeveloperText(string message, Color textColor)
        {
            _developerText.SetText(message);
            _developerText.color = textColor;
        }

        public void SetProgressBarProgress(float progress)
        {
            _progressBar.fillAmount = progress;
        }
    }
}

