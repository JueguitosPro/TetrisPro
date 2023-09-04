
namespace JueguitosPro
{
    
    /// <summary>
    /// Represents the game data container, including settings and other public members.
    /// </summary>
    public class GameData
    {
        /// <summary>
        /// Gets or sets the settings data for the game.
        /// </summary>
        public SettingsData SettingsData { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameData"/> class.
        /// </summary>
        public GameData()
        {
            SettingsData = new SettingsData();
        }
    }
    
    
    /// <summary>
    /// Represents settings data for managing general, music, and effects volume.
    /// </summary>
    public class SettingsData
    {
        /// <summary>
        /// Gets or sets the general volume level.
        /// </summary>
        public float GeneralVolume { get; set; }

        /// <summary>
        /// Gets or sets the music volume level.
        /// </summary>
        public float MusicVolume { get; set; }

        /// <summary>
        /// Gets or sets the effects volume level.
        /// </summary>
        public float EffectsVolume { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsData"/> class with default volume values.
        /// </summary>
        public SettingsData()
        {
            GeneralVolume = 1.0f;
            MusicVolume = 1.0f;
            EffectsVolume = 1.0f;
        }
    }

    /// <summary>
    /// Represents user data including their unique identifier and highest score.
    /// </summary>
    public class UserData
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the highest score achieved by the user.
        /// </summary>
        public int UserHighestScore { get; set; }
    }
}
