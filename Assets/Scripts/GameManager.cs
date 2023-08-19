namespace JueguitosPro
{
    public class GameManager
    {
        public static GameManager Instance;

        public readonly GameModeManager GameModeManager;
        public readonly ViewManager ViewManager;

        public GameManager()
        {
            GameModeManager = new GameModeManager();
            ViewManager = new ViewManager();
        }
    }
}
