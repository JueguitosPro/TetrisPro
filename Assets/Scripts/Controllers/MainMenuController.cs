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
        }

        private void LoginWithGoogleClicked()
        {
            throw new System.NotImplementedException();
        }

        private void SettingsClicked()
        {
            throw new System.NotImplementedException();
        }

        private void PlayGameClicked()
        {
            throw new System.NotImplementedException();
        }
    }
}
