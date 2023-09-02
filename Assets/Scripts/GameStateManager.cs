using System;
using System.Collections.Generic;
using JueguitosPro.GameStates;

namespace JueguitosPro
{
    /// <summary>
    /// Keeps track of the Game states, it can add, remove or hide and state
    /// </summary>
    public class GameStateManager
    {
        private Stack<IGameState> gameStates = new();

        /// <summary>
        /// Adds a new state into the stack, deactivate the current and activate the new one
        /// </summary>
        /// <param name="gameState">New game state to add and activate</param>
        /// <param name="activated">Callback after state activation</param>
        /// <typeparam name="T">The state must be an inheritor of <see cref="GameStateBase"/></typeparam>
        public void AddState<T>(T gameState, Action activated = null) where T : GameStateBase
        {
            if (gameStates.Count > 0 && !gameState.allowOverlaping)
            {
                IGameState currentGameState = gameStates.Peek();
                currentGameState.OnDeactivate();
            }
            gameStates.Push(gameState);
            gameState.OnCreate(()=>gameState.OnActivate(activated));
        }
        
        /// <summary>
        /// Removes one state from the stack and activate the next one if there is one
        /// </summary>
        /// <param name="deactivated">Callback after state deactivation</param>
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
        /// Clear the state stack
        /// </summary>
        public void PopAllStates()
        {
            while (gameStates.Count > 0)
            {
                IGameState gameState = gameStates.Pop();
                gameState.OnRemove();
            }
        }
    }
}
