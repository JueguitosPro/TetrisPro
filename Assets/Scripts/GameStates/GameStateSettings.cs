using System;
using JueguitosPro.Controllers;
using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.GameStates
{
    public class GameStateSettings : GameStateBase
    {
        public override void OnCreate(Action onCreated = null)
        {
            InstantiateView<SettingsView>(MainUI.CanvasLayer.Overlay, view =>
            {
                onCreated?.Invoke();
                SettingsModel model = new SettingsModel();
                SettingsController controller = new SettingsController(model, view);
            } );
        }
    }
}
