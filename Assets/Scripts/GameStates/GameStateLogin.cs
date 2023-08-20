using JueguitosPro.Controllers;
using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.GameStates
{
    public class GameStateLogin : GameStateBase
    {
        public override void OnCreate()
        {
            InstantiateView<LoadingView>(MainUI.CanvasLayer.Overlay, view =>
            {
                var model = new LoadingModel();
                var controller = new LoadingController(model, view);
            } );
        }
    }
}
