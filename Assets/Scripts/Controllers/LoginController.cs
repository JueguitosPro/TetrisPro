using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.Controllers
{
    public class LoginController
    {
        private LoginView _loginView;
        private LoginModel _loginModel;

        public LoginController(LoginModel model, LoginView view)
        {
            _loginModel = model;
            _loginModel.onSuccess += OnLoginSuccess;
            _loginModel.onFailure += OnLoginFailure;

            _loginView = view;
            _loginView.OnLoginWithGoogleClicked += LoginWithGoogle;
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
