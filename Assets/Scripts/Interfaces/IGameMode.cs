using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JueguitosPro.GameModes
{
    public interface IGameMode
    {
        public void OnCreate();

        public void OnActivate(Action enabled = null);
        
        public void OnRemove();
    }
}
