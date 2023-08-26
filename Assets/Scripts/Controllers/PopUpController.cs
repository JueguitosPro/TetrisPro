using System;
using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.Controllers
{
    public class PopUpController : ControllerBase<PopUpModel, PopUpView>
    {
        private Action okButtonCallback;
        private Action cancelButtonCallback;
        
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
            view.Hide(okButtonCallback);
        }

        private void CancelButtonClicked()
        {
            view.Hide(cancelButtonCallback);
        }
    }
}
