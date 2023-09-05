using System;
using System.Collections.Generic;
using System.Linq;
using JueguitosPro.GameStates;

namespace JueguitosPro
{
    /// <summary>
    /// Manages the game state stack and transitions between different game states.
    /// </summary>
    public class GameStateManager
    {
        private Stack<IGameState> gameStates = new();

        /// <summary>
        /// Adds a new game state to the stack and activates it.
        /// </summary>
        /// <typeparam name="T">The type of the game state to add.</typeparam>
        /// <param name="gameState">The instance of the game state to add.</param>
        /// <param name="activated">An optional action to perform when the game state is activated.</param>
        /// <remarks>
        /// If the game state stack is not empty and the new game state does not allow overlapping,
        /// the currently active game state will be deactivated before adding the new one.
        /// </remarks>
        public void AddState<T>(T gameState, Action activated = null) where T : GameStateBase
        {
            if (gameStates.Count > 0 && !gameState.AllowOverlapping)
            {
                IGameState currentGameState = gameStates.Peek();
                currentGameState.OnDeactivate();
            }
            gameStates.Push(gameState);
            gameState.OnCreate(() => gameState.OnActivate(activated));
        }

        /// <summary>
        /// Pops the current game state from the stack and deactivates it.
        /// </summary>
        /// <param name="deactivated">An optional action to perform when the game state is deactivated.</param>
        public void PopState(Action deactivated = null)
        {
            if (gameStates.Count > 0)
            {
                IGameState gameState = gameStates.Pop();
                gameState.OnRemove();
            }

            if (gameStates.Count > 0)
            {
                IGameState currentGameState = gameStates.Peek();
                currentGameState.OnActivate();
            }
        }

        /// <summary>
        /// Pops all game states from the stack, deactivating each one.
        /// </summary>
        public void PopAllStates()
        {
            while (gameStates.Count > 0)
            {
                IGameState gameState = gameStates.Pop();
                gameState.OnRemove();
            }
        }

        /// <summary>
        /// Pops states from the stack until a state of type T is encountered.
        /// </summary>
        /// <typeparam name="T">The type of game state to find and stop at. Must implement <see cref="IGameState"/></typeparam>
        public void PopStatesUntil<T>() where T : IGameState
        {
            if (gameStates.Count == 0 || !Contains<T>())
            {
                return;
            }

            while (!(gameStates.Peek() is T) && gameStates.Count > 0)
            {
                PopState();
            }
        }

        private bool Contains<T>() where T : IGameState
        {
            return gameStates.Count != 0 && gameStates.OfType<T>().Any();
        }
    }
}
