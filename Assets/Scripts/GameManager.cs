
namespace JueguitosPro
{
    public class GameManager
    {
        public static GameManager Instance;

        public readonly GameStateManager GameStateManager;
        public readonly ViewManager ViewManager;
        public readonly DataManager DataManager;

        public GameManager()
        {
            GameStateManager = new GameStateManager();
            ViewManager = new ViewManager();
            DataManager = new DataManager();
        }
    }
}
