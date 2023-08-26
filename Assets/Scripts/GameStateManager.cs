using System;
using System.Collections.Generic;
using JueguitosPro.GameStates;

namespace JueguitosPro
{
    public class GameStateManager
    {
        private Stack<IGameState> gameStates = new();

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
