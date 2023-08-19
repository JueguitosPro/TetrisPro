using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.Controllers
{
    public class LoadingController : ControllerBase<LoadingModel, LoadingView>
    {
        public LoadingController(LoadingModel model, LoadingView view) : base(model, view)
        {
            this.model.onSuccess += LoadingSuccess;
            this.model.onFailure += LoadingFailure;

            this.view.OnLoginWithGoogleClicked += LoadingWithGoogle;
        }

        private void LoadingWithGoogle()
        {
            view.SetDeveloperText("Trying to login with google", Constants.ERROR_COLOR);
            model .LoginWithGoogle();
        }

        private void LoadingSuccess()
        {
            view.SetDeveloperText("Successful Login", Constants.LOG_COLOR);
        }

        private void LoadingFailure(string errorMessage)
        {
            view.SetDeveloperText(errorMessage, Constants.ERROR_COLOR);
        }
    }
}
