using System;
using JueguitosPro.Controllers;
using JueguitosPro.Models;

namespace JueguitosPro.GameStates
{
    public class GameStateMainMenu : GameStateBase
    {
        public override void OnCreate(Action onCreated = null)
        {
            InstantiateView<MainMenuView>(MainUI.CanvasLayer.Overlay, view =>
            {
                onCreated?.Invoke();
                MainMenuModel model = new MainMenuModel();
                MainMenuController controller = new MainMenuController(model, view);
            });
        }
    }
}
