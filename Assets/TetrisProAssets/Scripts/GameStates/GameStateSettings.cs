using System;
using JueguitosPro.Controllers;
using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.GameStates
{
    /// <summary>
    /// Represents a game state for managing settings.
    /// </summary>
    public class GameStateSettings : GameStateBase
    {
        /// <inheritdoc/>
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
