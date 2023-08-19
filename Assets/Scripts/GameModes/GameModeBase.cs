using System;
using JueguitosPro.Views;

namespace JueguitosPro.GameModes
{
    public abstract class GameModeBase : IGameMode
    {
        public string ViewPrefabPath;

        private ViewBase _viewBase;
        private bool _isActive = false;

        public void CreateView<T>(RootUI.CanvasLayer canvasLayer, Action<T> callback) where T : ViewBase
        {
            _viewBase = GameManager.Instance.ViewManager.CreateView<T>(ViewPrefabPath, canvasLayer, callback);
        }

        public abstract void OnCreate();

        public virtual void OnActivate(Action enabled = null)
        {
            _isActive = true;

            if (_viewBase != null)
            {
                _viewBase.Open(enabled);
            }
            else
            {
                enabled?.Invoke();
            }
        }

        public virtual void OnRemove()
        {
            _viewBase.Destroy();
        }
    }
}
