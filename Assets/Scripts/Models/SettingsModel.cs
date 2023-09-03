
namespace JueguitosPro.Models
{
    /// <summary>
    /// A model class responsible for managing game settings data.
    /// </summary>
    public class SettingsModel : ModelBase
    {
        /// <summary>
        /// Saves the provided settings data.
        /// </summary>
        /// <param name="settingsData">The settings data to be saved.</param>
        public void SaveSettingsData(SettingsData settingsData)
        {
            GameManager.Instance.DataManager.GameData.SettingsData = settingsData;
            GameManager.Instance.DataManager.SaveData();
        }

        /// <summary>
        /// Retrieves the current settings data.
        /// </summary>
        /// <returns>The current settings data.</returns>
        public SettingsData GetSettingsData()
        {
            return GameManager.Instance.DataManager.GameData.SettingsData;
        }
    }
}
