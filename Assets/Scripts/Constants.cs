using UnityEngine;

namespace JueguitosPro
{
    /// <summary>
    /// Static class containing constants used throughout the game.
    /// </summary>
    public static class Constants
    {
        // Score
        public static readonly int SLOW_DROP_POINTS_PER_CELL = 1; 
        public static readonly int HARD_DROP_POINTS_PER_CELL = 2;
        
        public static readonly int SINGLE_LINE_POINTS = 100;
        public static readonly int DOUBLE_LINE_POINTS = 300;
        public static readonly int TRIPLE_LINE_POINTS = 500;
        public static readonly int TETRIS_POINTS = 800;
        
        // Color used for displaying developer messages.
        public static Color ERROR_COLOR = Color.red;
        public static Color WARNING_COLOR = Color.yellow;
        public static Color LOG_COLOR = Color.white;
        
        // Path to the data file used in the game.
        public static readonly string DataFile = "GameData.txt";
        
        // Path to the view prefabs used in the user interface.
        public static readonly string LoadingView = "UI/Views/LoadingView";
        public static readonly string PopUpView = "UI/Views/PopUpView";
        public static readonly string MainMenuView = "UI/Views/MainMenuView";
        public static readonly string LeaderboardView = "UI/Views/LeaderboardView";
        public static readonly string SettingsView = "UI/Views/SettingsView";
        public static readonly string ScoreView = "UI/Views/ScoreView";
    }
}
