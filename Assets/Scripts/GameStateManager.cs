using System;
using System.Collections.Generic;
using JueguitosPro.GameStates;

namespace JueguitosPro
{
    public class GameStateManager
    {
        private Stack<IGameState> _gameStates = new();

        public void AddState<T>(T gameState, Action activated = null) where T : GameStateBase
        {
            if (_gameStates.Count > 0)
            {
                IGameState currentGameState = _gameStates.Peek();
                // We did not remove anything maybe we need an Disable event
            }
            _gameStates.Push(gameState);
            gameState.OnCreate();
            gameState.OnActivate(activated);
        }

        public void PopState(Action deactivated = null)
        {
            if (_gameStates.Count > 0)
            {
                IGameState gameState = _gameStates.Pop();
                
                gameState.OnRemove();
            }

            if (_gameStates.Count > 0)
            {
                IGameState currentGameState = _gameStates.Peek();
            }
        }

        public void PopAllStates()
        {
            while (_gameStates.Count > 0)
            {
                IGameState gameState = _gameStates.Pop();
                gameState.OnRemove();
            }
        }
    }
}
