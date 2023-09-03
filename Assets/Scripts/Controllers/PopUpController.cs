using System;
using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.Controllers
{
    /// <summary>
    /// Handles PopUp Game State, it could show 1 or 2 buttons and a informative text
    /// </summary>
    public class PopUpController : ControllerBase<PopUpModel, PopUpView>
    {
        private Action okButtonCallback;
        private Action cancelButtonCallback;
        
        /// <summary>
        /// Creates a new controller and assigns its model and view, also takes a popup message, if callbacks are not
        /// null it show its button, if both are null, it will show a standard button without callback to close the
        /// PopUp
        /// </summary>
        /// <param name="model"><see cref="PopUpModel"/></param>
        /// <param name="view"><see cref="PopUpView"/></param>
        /// <param name="popUpMessage">Message to show in the PopUp</param>
        /// <param name="okButtonCallback">Ok button's callback</param>
        /// <param name="cancelButtonCallback">Cancel button's callback</param>
        public PopUpController(PopUpModel model, PopUpView view, string popUpMessage, 
            Action okButtonCallback = null, Action cancelButtonCallback = null) : base(model, view)
        {
            this.okButtonCallback = okButtonCallback;
            this.cancelButtonCallback = cancelButtonCallback;
            
            view.onOkButtonClicked += OkButtonClicked;
            view.onCancelButtonClicked += CancelButtonClicked;
            view.SetPopUpMessage(popUpMessage);
            view.InitButtons(okButtonCallback!=null, cancelButtonCallback!=null);
        }

        private void OkButtonClicked()
        {
            view.Destroy();
            okButtonCallback?.Invoke();
        }

        private void CancelButtonClicked()
        {
            view.Destroy();
            cancelButtonCallback?.Invoke();
        }
    }
}
