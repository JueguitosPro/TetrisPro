using System;
using JueguitosPro.Views;

namespace JueguitosPro.GameStates
{
    public abstract class GameStateBase : IGameState
    {
        public string PrefabPath;

        private ViewBase viewBase;

        public void InstantiateView<T>(MainUI.CanvasLayer canvasLayer, Action<T> callback) where T : ViewBase
        {
            viewBase = GameManager.Instance.ViewManager.InstantiateView<T>(PrefabPath, canvasLayer, callback);
        }

        public abstract void OnCreate();

        public virtual void OnActivate(Action activated = null)
        {
            if (viewBase != null)
            {
                viewBase.Show(activated);
            }
            else
            {
                activated?.Invoke();
            }
        }

        public virtual void OnDeactivate(Action deactivated = null)
        {
            if (viewBase != null)
            {
                viewBase.Hide(deactivated);
            }
            else
            {
                deactivated?.Invoke();
            }
        }

        public virtual void OnRemove()
        {
            viewBase.Destroy();
        }
    }
}
