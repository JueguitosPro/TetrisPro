using System.Collections.Generic;
using JueguitosPro.GameStates;
using JueguitosPro.Models;
using UnityEngine;

namespace JueguitosPro.Controllers
{
    public class MainMenuController : ControllerBase<MainMenuModel,MainMenuView>
    {
        public MainMenuController(MainMenuModel model, MainMenuView view) : base(model, view)
        {
            view.onPlayGameButtonClicked += PlayGameClicked;
            view.onLeaderboardButtonClicked += LeaderboardClicked;
            view.onSetLeaderboardScoreButtonClicked += SetLeaderboardScoreClicked;
            view.onSettingsButtonClicked += SettingsClicked;
            view.onLoginWithGoogleButtonClicked += LoginWithGoogleClicked;
            
            view.AllowPlayGamesLogin(!model.IsAuthenticated);
        }

        private void LoginWithGoogleClicked()
        {
            model.PlayGamesAuthentication(AuthenticationCallback);
        }

        private void LeaderboardClicked()
        {
            #if UNITY_EDITOR
            GameManager.Instance.GameStateManager.AddState(new GameStateLeaderboard()
            {
                PrefabPath = Constants.LeaderboardView
            });
            #else
            if (model.IsAuthenticated)
            {
                GameManager.Instance.GameStateManager.AddState(new GameStateLeaderboard()
                {
                    PrefabPath = Constants.LeaderboardView
                });
            }
            else
            {
                GameManager.Instance.GameStateManager.AddState(new GameStatePopUp
                {
                    PrefabPath = Constants.PopUpView,
                    allowOverlaping = true,
                    popUpMessage = $"Please login with Play Games to compete with worldwide players."
                });
            }
            #endif
        }

        private void SetLeaderboardScoreClicked()
        {
            if (model.IsAuthenticated)
            {
                model.SetLeaderboardScore(100, success =>
                {
                    Debug.Log("score setted");
                });
            }
        }

        private void SettingsClicked()
        {
            GameManager.Instance.GameStateManager.AddState(new GameStateSettings
            {
                PrefabPath = Constants.SettingsView,
                allowOverlaping = false
            });
        }

        private void PlayGameClicked()
        {
            // Go to game screen
        }

        private void AuthenticationCallback(bool success)
        {
            GameManager.Instance.GameStateManager.AddState(new GameStatePopUp
            {
                PrefabPath = Constants.PopUpView,
                allowOverlaping = true,
                popUpMessage = success ? 
                    $"Thank you! You can enjoy leaderboards and achievements now." : 
                    $"Make sure you have an account in Google Play Games and try again."
            });
        }
    }
}
