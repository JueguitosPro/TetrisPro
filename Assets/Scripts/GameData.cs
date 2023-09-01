using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JueguitosPro
{
    public class GameData
    {
        public SettingsData SettingsData { get; set; }

        public GameData()
        {
            SettingsData = new SettingsData();
        }
    }
    
    public class SettingsData
    {
        public float GeneralVolume { get; set; }
        public float MusicVolume { get; set; }
        public float EffectsVolume { get; set; }

        public SettingsData()
        {
            GeneralVolume = 1.0f;
            MusicVolume = 1.0f;
            EffectsVolume = 1.0f;
        }
    }
}
