using System;
using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.Controllers
{
    /// <summary>
    /// Controller for managing pop-up dialogs.
    /// </summary>
    public class PopUpController : ControllerBase<PopUpModel, PopUpView>
    {
        private Action okButtonCallback;
        private Action cancelButtonCallback;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="PopUpController"/> class.
        /// </summary>
        /// <param name="model">The pop-up model.</param>
        /// <param name="view">The pop-up view.</param>
        /// <param name="popUpMessage">The message to display in the pop-up.</param>
        /// <param name="okButtonCallback">Callback to invoke when the OK button is clicked (optional).</param>
        /// <param name="cancelButtonCallback">Callback to invoke when the Cancel button is clicked (optional).</param>
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
