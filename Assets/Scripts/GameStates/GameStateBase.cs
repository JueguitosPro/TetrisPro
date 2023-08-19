using System;
using JueguitosPro.Views;

namespace JueguitosPro.GameStates
{
    public abstract class GameStateBase : IGameState
    {
        public string PrefabPath;

        private ViewBase _viewBase;

        public void InstantiateView<T>(MainUI.CanvasLayer canvasLayer, Action<T> callback) where T : ViewBase
        {
            _viewBase = GameManager.Instance.ViewManager.InstantiateView<T>(PrefabPath, canvasLayer, callback);
        }

        public abstract void OnCreate();

        public virtual void OnActivate(Action activated = null)
        {
            if (_viewBase != null)
            {
                _viewBase.Show(activated);
            }
            else
            {
                activated?.Invoke();
            }
        }

        public virtual void OnDeactivate(Action deactivated = null)
        {
            if (_viewBase != null)
            {
                _viewBase.Hide(deactivated);
            }
            else
            {
                deactivated?.Invoke();
            }
        }

        public virtual void OnRemove()
        {
            _viewBase.Destroy();
        }
    }
}
