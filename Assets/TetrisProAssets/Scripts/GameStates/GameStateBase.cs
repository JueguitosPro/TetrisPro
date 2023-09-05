using System;
using Cysharp.Threading.Tasks;
using JueguitosPro.Views;

namespace JueguitosPro.GameStates
{
    /// <summary>
    /// Base class for defining game states. Game states manage the lifecycle and behavior of different game screens or states.
    /// </summary>
    public abstract class GameStateBase : IGameState
    {
        /// <summary>
        /// The path to the prefab associated with this game state.
        /// </summary>
        public string PrefabPath;

        /// <summary>
        /// Determines whether this game state allows overlapping with other states.
        /// </summary>
        public bool AllowOverlapping;
        
        private ViewBase viewBase;

        /// <summary>
        /// Asynchronously instantiates a view associated with this game state and invokes a callback with the created view.
        /// </summary>
        /// <typeparam name="T">The type of the view to instantiate, derived from ViewBase.</typeparam>
        /// <param name="canvasLayer">The canvas layer where the view should be placed.</param>
        /// <param name="callback">A callback function that receives the instantiated view.</param>
        protected async UniTask InstantiateView<T>(MainUI.CanvasLayer canvasLayer, Action<T> callback) where T : ViewBase
        {
            viewBase = await GameManager.Instance.ViewManager.InstantiateView<T>(PrefabPath, canvasLayer);
            callback?.Invoke((T)viewBase);
        }

        /// <inheritdoc/>
        public abstract void OnCreate(Action onCreated = null);

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public virtual void OnRemove()
        {
            viewBase.Destroy();
        }
    }
}
