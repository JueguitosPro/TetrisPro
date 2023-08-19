using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JueguitosPro.GameStates
{
    public interface IGameState
    {
        public void OnCreate();

        public void OnActivate(Action activated = null);

        public void OnDeactivate(Action deactivated = null);
        
        public void OnRemove();
    }
}
