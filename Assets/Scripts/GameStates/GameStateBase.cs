using System;
using Cysharp.Threading.Tasks;
using JueguitosPro.Views;

namespace JueguitosPro.GameStates
{
    public abstract class GameStateBase : IGameState
    {
        public string PrefabPath;

        private ViewBase viewBase;

        protected async UniTask InstantiateView<T>(MainUI.CanvasLayer canvasLayer, Action<T> callback) where T : ViewBase
        {
            viewBase = await GameManager.Instance.ViewManager.InstantiateView<T>(PrefabPath, canvasLayer);
            callback?.Invoke((T)viewBase);
        }

        public abstract void OnCreate(Action onCreated = null);

        public virtual void OnActivate(Action onActivated = null)
        {
            if (viewBase != null)
            {
                viewBase.Show(onActivated);
            }
            else
            {
                onActivated?.Invoke();
            }
        }

        public virtual void OnDeactivate(Action onDeactivated = null)
        {
            if (viewBase != null)
            {
                viewBase.Hide(onDeactivated);
            }
            else
            {
                onDeactivated?.Invoke();
            }
        }

        public virtual void OnRemove()
        {
            viewBase.Destroy();
        }
    }
}
