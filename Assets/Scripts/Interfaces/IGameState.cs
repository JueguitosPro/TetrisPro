using System;

namespace JueguitosPro.GameStates
{
    public interface IGameState
    {
        public void OnCreate(Action onCreated = null);

        public void OnActivate(Action onActivated = null);

        public void OnDeactivate(Action onDeactivated = null);
        
        public void OnRemove();
    }
}
