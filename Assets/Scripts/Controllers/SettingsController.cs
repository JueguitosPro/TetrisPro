using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.Controllers
{
    /// <summary>
    /// Controller class responsible for managing settings-related interactions between the model and view.
    /// </summary>
    public class SettingsController : ControllerBase<SettingsModel,SettingsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsController"/> class.
        /// </summary>
        /// <param name="model">The settings model.</param>
        /// <param name="view">The settings view.</param>
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
