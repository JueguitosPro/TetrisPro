using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace JueguitosPro.Views
{
    public class LoginView : MonoBehaviour
    {
        [SerializeField] private Button _googleLoginButton;
        [SerializeField] private TextMeshProUGUI _developerText;

        public event Action OnLoginWithGoogleClicked;

        private void Start()
        {
            _googleLoginButton.onClick.AddListener(OnClickGoogleLogin);
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
    }
}

