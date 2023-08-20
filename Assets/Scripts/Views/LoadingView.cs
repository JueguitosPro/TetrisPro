using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace JueguitosPro.Views
{
    public class LoadingView : ViewBase
    {
        [SerializeField] private Button googleLoginButton;
        [SerializeField] private TextMeshProUGUI developerText;
        [SerializeField] private Image progressBar;

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
            developerText.SetText(message);
            developerText.color = textColor;
        }

        public void SetProgressBarProgress(float progress)
        {
            progressBar.fillAmount = progress;
        }
    }
}

