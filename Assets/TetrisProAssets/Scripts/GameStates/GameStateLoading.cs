using System;
using JueguitosPro.Controllers;
using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.GameStates
{
    /// <summary>
    /// Represents a game state for loading content.
    /// </summary>
    public class GameStateLoading : GameStateBase
    {
        /// <inheritdoc/>
        public override void OnCreate(Action onCreated = null)
        {
            InstantiateView<LoadingView>(MainUI.CanvasLayer.Overlay, view =>
            {
                onCreated?.Invoke();
                LoadingModel model = new LoadingModel();
                LoadingController controller = new LoadingController(model, view);
            } );
        }
    }
}
