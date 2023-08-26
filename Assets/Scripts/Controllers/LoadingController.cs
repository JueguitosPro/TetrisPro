using Cysharp.Threading.Tasks.Triggers;
using JueguitosPro.Models;
using JueguitosPro.Views;
using UnityEngine;

namespace JueguitosPro.Controllers
{
    public class LoadingController : ControllerBase<LoadingModel, LoadingView>
    {
        public LoadingController(LoadingModel model, LoadingView view) : base(model, view)
        {
            view.SetActive(true);
        }
        
        public void Authenticate()
        {
            // model.PlayGoogleGamesAuthentication(AuthenticationCallback);
            SetLoadingProgress(0.4f);
            SetLoadingProgress(.8f);
            SetLoadingProgress(1f);
        }

        private void SetLoadingProgress(float progress)
        {
            view.RegisterProgressEvent(progress, 2f);
        }

        private void AuthenticationCallback(bool success)
        {
            if (success)
            {
                Debug.Log("Successful Login");
                SetLoadingProgress(.4f);
                SetLoadingProgress(.2f);
            }
            else
            {
                
            }
        }
    }
}
