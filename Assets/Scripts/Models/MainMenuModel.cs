using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JueguitosPro.Models
{
    public class MainMenuModel : ModelBase
    {
        public bool IsAuthenticated => GooglePlayGamesWrapper.IsAuthenticated;

        public void PlayGamesAuthentication(Action<bool> authenticationCallback)
        {
            GooglePlayGamesWrapper.GooglePlayGamesAuthentication(authenticationCallback);
        }
    }
}
