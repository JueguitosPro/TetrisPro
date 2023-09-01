using System;
using JueguitosPro.GameStates;
using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.Controllers
{
    public class LoadingController : ControllerBase<LoadingModel, LoadingView>
    {
        public LoadingController(LoadingModel model, LoadingView view) : base(model, view)
        {
            SetLoadingProgress(0.4f, () =>
            {
                model.PlayGamesAuthentication(AuthenticationCallback);
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
                    GameManager.Instance.GameStateManager.PopAllStates();
                    GameManager.Instance.GameStateManager.AddState(new GameStateMainMenu
                    {
                        PrefabPath = Constants.MainMenuView
                    });
                }
                else
                {
                    GameManager.Instance.GameStateManager.AddState(new GameStatePopUp
                    {
                        PrefabPath = Constants.PopUpView,
                        allowOverlaping = true,
                        popUpMessage =
                            $"If you want to use all game's features we recommend to login with Google Play Games.",
                        okButtonCallback = () =>
                        {
                            GameManager.Instance.GameStateManager.PopAllStates();
                            GameManager.Instance.GameStateManager.AddState(new GameStateMainMenu
                            {
                                PrefabPath = Constants.MainMenuView
                            });
                        }
                    });
                }
            });
        }
    }
}
