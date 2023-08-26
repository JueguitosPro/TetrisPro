using System;
using JueguitosPro.Controllers;
using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.GameStates
{
    public class GameStatePopUp : GameStateBase
    {
        public string popUpMessage;
        public Action okButtonCallback;
        public Action cancelButtonCallback;
        
        public override void OnCreate(Action onCreated = null)
        {
            InstantiateView<PopUpView>(MainUI.CanvasLayer.Overlay, view =>
            {
                onCreated?.Invoke();
                PopUpModel model = new PopUpModel();
                PopUpController controller = new PopUpController(model, view, popUpMessage, okButtonCallback, cancelButtonCallback);
            });
        }
    }
}
