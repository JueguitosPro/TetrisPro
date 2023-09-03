using System;
using JueguitosPro.GameStates;
using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.Controllers
{
    /// <summary>
    /// Represents a controller for managing loading operations.
    /// </summary>
    public class LoadingController : ControllerBase<LoadingModel, LoadingView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoadingController"/> class.
        /// </summary>
        /// <param name="model">The model for loading operations.</param>
        /// <param name="view">The view for displaying loading progress.</param>
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
                        allowOverlapping = true,
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
