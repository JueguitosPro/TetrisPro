using System.Collections;
using System.Collections.Generic;
using JueguitosPro.Models;
using JueguitosPro.Views;
using UnityEngine;

namespace JueguitosPro.Controllers
{
    public class SettingsController : ControllerBase<SettingsModel,SettingsView>
    {
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
