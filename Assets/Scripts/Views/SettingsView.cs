using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JueguitosPro.Views
{
    public class SettingsView : ViewBase
    {
        [SerializeField] private Slider generalVolumeSlider;
        [SerializeField] private Slider musicVolumeSlider;
        [SerializeField] private Slider effectsVolumeSlider;
        [SerializeField] private Button backButton;

        public event Action<SettingsData> onBackButtonClicked;

        public override void Show(Action onShow = null)
        {
            base.Show(onShow);
            backButton.onClick.AddListener(OnBackButtonClicked);
        }

        public override void Hide(Action onHide = null)
        {
            base.Hide(onHide);
            backButton.onClick.RemoveListener(OnBackButtonClicked);
        }

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
