using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.Controllers
{
    /// <summary>
    /// Handles Settings Game State, interacts with <see cref="SettingsModel"/> and <see cref="SettingsView"/> to save
    /// and load player's preferences in a JSON file
    /// </summary>
    public class SettingsController : ControllerBase<SettingsModel,SettingsView>
    {
        /// <inheritdoc/>
        public SettingsController(SettingsModel model, SettingsView view) : base(model, view)
        {
            view.onBackButtonClicked += OnBackButtonClicked;
            view.SetSettingsData(model.GetSettingsData());
        }

        private void OnBackButtonClicked(SettingsData settingsData)
        {
            model.SaveSettingsData(settingsData);
            GameManager.Instance.GameStateManager.PopState();
        }
    }
}
