using System;
using System.Collections;
using System.Collections.Generic;
using JueguitosPro.Controllers;
using JueguitosPro.Models;
using JueguitosPro.Views;
using UnityEngine;

namespace JueguitosPro.GameStates
{
    public class GameStateLeaderboard : GameStateBase
    {
        public override void OnCreate(Action onCreated = null)
        {
            InstantiateView<LeaderboardView>(MainUI.CanvasLayer.Overlay, view =>
            {
                onCreated?.Invoke();
                LeaderboardModel model = new LeaderboardModel();
                LeaderboardController controller = new LeaderboardController(model, view);
            });
        }
    }
}
