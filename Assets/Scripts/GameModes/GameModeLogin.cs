using JueguitosPro.Controllers;
using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.GameModes
{
    public class GameModeLogin : GameModeBase
    {
        public override void OnCreate()
        {
            CreateView<LoginView>(RootUI.CanvasLayer.Overlay, view =>
            {
                var model = new LoginModel();
                var controller = new LoginController(model, view);
            } );
        }
    }
}
