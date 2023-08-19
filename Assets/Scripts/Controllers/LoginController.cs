using JueguitosPro.Models;
using JueguitosPro.Views;
using UnityEngine;
using GooglePlayGames;

namespace JueguitosPro.Controllers
{
    public class LoginController : MonoBehaviour
    {
        [SerializeField] private LoginView _loginView;
        
        private LoginModel _loginModel;

        private void Start()
        {
            _loginModel = new LoginModel();
            _loginModel.onSuccess += OnLoginSuccess;
            _loginModel.onFailure += OnLoginFailure;
            
            _loginView.OnLoginWithGoogleClicked += LoginWithGoogle;

            // recommended for debugging:
            PlayGamesPlatform.DebugLogEnabled = true;

            // Activate the Google Play Games platform
            PlayGamesPlatform.Activate();
        }

        private void LoginWithGoogle()
        {
            _loginView.SetDeveloperText("Trying to login with google", Constants.ERROR_COLOR);
            _loginModel.LoginWithGoogle();
        }

        private void OnLoginSuccess()
        {
            _loginView.SetDeveloperText("Successful Login", Constants.LOG_COLOR);
        }

        private void OnLoginFailure(string errorMessage)
        {
            _loginView.SetDeveloperText(errorMessage, Constants.ERROR_COLOR);
        }
    }
}
