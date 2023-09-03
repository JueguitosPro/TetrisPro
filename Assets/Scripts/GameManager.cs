
namespace JueguitosPro
{
    /// <summary>
    /// Manages the game's core functionality and serves as a singleton instance.
    /// </summary>
    public class GameManager
    {
        /// <summary>
        /// Gets the singleton instance of the GameManager.
        /// </summary>
        public static GameManager Instance;

        /// <summary>
        /// Gets the GameStateManager responsible for managing the game's state.
        /// </summary>
        public readonly GameStateManager GameStateManager;

        /// <summary>
        /// Gets the ViewManager responsible for managing game views.
        /// </summary>
        public readonly ViewManager ViewManager;

        /// <summary>
        /// Gets the DataManager responsible for handling game data.
        /// </summary>
        public readonly DataManager DataManager;

        /// <summary>
        /// Initializes a new instance of the GameManager class and initializes its components.
        /// </summary>
        public GameManager()
        {
            GameStateManager = new GameStateManager();
            ViewManager = new ViewManager();
            DataManager = new DataManager();
        }
    }

}
