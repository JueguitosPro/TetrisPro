using System;
using System.Collections.Generic;
using JueguitosPro.GameModes;

namespace JueguitosPro
{
    public class GameModeManager
    {
        private Stack<IGameMode> _gameModes = new();

        public void Add<T>(T gameMode, Action activated = null) where T : GameModeBase
        {
            if (_gameModes.Count > 0)
            {
                IGameMode currentGameMode = _gameModes.Peek();
                // We did not remove anything maybe we need an Disable event
            }
            _gameModes.Push(gameMode);
            gameMode.OnCreate();
            gameMode.OnActivate(activated);
        }

        public void Pop(Action deactivated = null)
        {
            if (_gameModes.Count > 0)
            {
                IGameMode gameMode = _gameModes.Pop();
                
                gameMode.OnRemove();
            }

            if (_gameModes.Count > 0)
            {
                IGameMode currentGameMode = _gameModes.Peek();
            }
        }

        public void PopAll()
        {
            while (_gameModes.Count > 0)
            {
                IGameMode gameMode = _gameModes.Pop();
                gameMode.OnRemove();
            }
        }
    }
}
