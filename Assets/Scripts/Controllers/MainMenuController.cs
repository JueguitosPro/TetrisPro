using JueguitosPro.GameStates;
using JueguitosPro.Models;

namespace JueguitosPro.Controllers
{
    public class MainMenuController : ControllerBase<MainMenuModel,MainMenuView>
    {
        public MainMenuController(MainMenuModel model, MainMenuView view) : base(model, view)
        {
            view.onPlayGameButtonClicked += PlayGameClicked;
            view.onSettingsButtonClicked += SettingsClicked;
            view.onLoginWithGoogleButtonClicked += LoginWithGoogleClicked;
            
            view.AllowPlayGamesLogin(!model.IsAuthenticated);
        }

        private void LoginWithGoogleClicked()
        {
            model.PlayGamesAuthentication(AuthenticationCallback);
        }

        private void SettingsClicked()
        {
            // Open settings view
        }

        private void PlayGameClicked()
        {
            // Go to game screen
        }

        private void AuthenticationCallback(bool success)
        {
            GameManager.Instance.GameStateManager.AddState(new GameStatePopUp
            {
                PrefabPath = Constants.PopUpView,
                allowOverlaping = true,
                popUpMessage = success ? 
                    $"Thank you! You can enjoy leaderboards and achievements now." : 
                    $"Make sure you have an account in Google Play Games and try again."
            });
        }
    }
}
