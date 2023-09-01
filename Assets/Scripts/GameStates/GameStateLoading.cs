using System;
using JueguitosPro.Controllers;
using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.GameStates
{
    public class GameStateLoading : GameStateBase
    {
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
