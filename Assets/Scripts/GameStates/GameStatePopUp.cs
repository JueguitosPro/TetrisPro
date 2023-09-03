using System;
using JueguitosPro.Controllers;
using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.GameStates
{
    /// <summary>
    /// Represents a game state for displaying a pop-up message.
    /// </summary>
    public class GameStatePopUp : GameStateBase
    {
        /// <summary>
        /// The message to display in the pop-up.
        /// </summary>
        public string popUpMessage;

        /// <summary>
        /// A callback action to execute when the OK button is pressed.
        /// </summary>
        public Action okButtonCallback;

        /// <summary>
        /// A callback action to execute when the Cancel button is pressed.
        /// </summary>
        public Action cancelButtonCallback;
        
        /// <inheritdoc/>
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
