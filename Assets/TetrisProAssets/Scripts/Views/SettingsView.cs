using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JueguitosPro.Views
{
    /// <summary>
    /// Represents the view for managing game settings.
    /// </summary>
    public class SettingsView : ViewBase
    {
        [SerializeField] private Slider generalVolumeSlider;
        [SerializeField] private Slider musicVolumeSlider;
        [SerializeField] private Slider effectsVolumeSlider;
        [SerializeField] private Button backButton;

        /// <summary>
        /// Event triggered when the back button is clicked with updated settings data.
        /// </summary>
        public event Action<SettingsData> onBackButtonClicked;

        /// <inheritdoc/>
        public override void Show(Action onShow = null)
        {
            base.Show(onShow);
            backButton.onClick.AddListener(OnBackButtonClicked);
        }

        /// <inheritdoc/>
        public override void Hide(Action onHide = null)
        {
            base.Hide(onHide);
            backButton.onClick.RemoveListener(OnBackButtonClicked);
        }

        /// <summary>
        /// Sets the settings data on the view.
        /// </summary>
        /// <param name="settingsData">The settings data to display.</param>
        public void SetSettingsData(SettingsData settingsData)
        {
            generalVolumeSlider.value = settingsData.GeneralVolume;
            musicVolumeSlider.value = settingsData.MusicVolume;
            effectsVolumeSlider.value = settingsData.EffectsVolume;
        }

        private void OnDestroy()
        {
            onBackButtonClicked = null;
        }

        private void OnBackButtonClicked()
        {
            SettingsData settings = new SettingsData
            {
                GeneralVolume = generalVolumeSlider.value,
                MusicVolume = musicVolumeSlider.value,
                EffectsVolume = effectsVolumeSlider.value
            };
            
            onBackButtonClicked?.Invoke(settings);
        }
    }
}
