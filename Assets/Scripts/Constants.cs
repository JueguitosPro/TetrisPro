using UnityEngine;

namespace JueguitosPro
{
    public static class Constants
    {
        // Developer Text Colors
        
        public static Color ERROR_COLOR = Color.red;
        public static Color WARNING_COLOR = Color.yellow;
        public static Color LOG_COLOR = Color.white;
        
        // Data Path
        public static readonly string DataFile = "GameData.txt";
        
        // Prefabs Path
        
        public static readonly string LoadingView = "UI/Views/LoadingView";
        public static readonly string PopUpView = "UI/Views/PopUpView";
        public static readonly string MainMenuView = "UI/Views/MainMenuView";
        public static readonly string LeaderboardView = "UI/Views/LeaderboardView";
        public static readonly string SettingsView = "UI/Views/SettingsView";
    }
}
