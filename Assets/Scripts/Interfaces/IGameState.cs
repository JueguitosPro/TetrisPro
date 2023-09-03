using System;

namespace JueguitosPro.GameStates
{
    /// <summary>
    /// Interface representing a game state.
    /// </summary>
    public interface IGameState
    {
        /// <summary>
        /// Called when the game state is created.
        /// </summary>
        /// <param name="onCreated">Optional callback when the state is created.</param>
        public void OnCreate(Action onCreated = null);

        /// <summary>
        /// Called when the game state is activated.
        /// </summary>
        /// <param name="onActivated">Optional callback when the state is activated.</param>
        public void OnActivate(Action onActivated = null);

        /// <summary>
        /// Called when the game state is deactivated.
        /// </summary>
        /// <param name="onDeactivated">Optional callback when the state is deactivated.</param>
        public void OnDeactivate(Action onDeactivated = null);

        /// <summary>
        /// Called when the game state is removed.
        /// </summary>
        public void OnRemove();
    }
}
