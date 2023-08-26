using System;
using Cysharp.Threading.Tasks.Triggers;
using JueguitosPro.GameStates;
using JueguitosPro.Models;
using JueguitosPro.Views;
using UnityEngine;

namespace JueguitosPro.Controllers
{
    public class LoadingController : ControllerBase<LoadingModel, LoadingView>
    {
        public LoadingController(LoadingModel model, LoadingView view) : base(model, view)
        {
        }
        
        public void Authenticate()
        {
            SetLoadingProgress(0.4f, () =>
            {
                model.PlayGoogleGamesAuthentication(AuthenticationCallback);
            });

        }

        private void SetLoadingProgress(float progress, Action eventCallback = null)
        {
            view.RegisterProgressEvent(progress, 1f, eventCallback);
        }

        private void AuthenticationCallback(bool success)
        {
            SetLoadingProgress(1f, () =>
            {
                if (success)
                {
                    // Go to MainMenu
                }
                else
                {
                    GameManager.Instance.GameStateManager.AddState(new GameStatePopUp
                    {
                        PrefabPath = Constants.PopUpView,
                        popUpMessage =
                            $"If you want to use all game's features we recommend to login with Google Play Games.",
                        okButtonCallback = () =>
                        {
                            // Go to MainMenu
                        }
                    });
                }
            });
        }
    }
}
