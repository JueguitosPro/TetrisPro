using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JueguitosPro
{
    /// <summary>
    /// Data that is saved in a json file
    /// </summary>
    public class GameData
    {
        public SettingsData SettingsData { get; set; }

        public GameData()
        {
            SettingsData = new SettingsData();
        }
    }
    
    /// <summary>
    /// Player's game settings
    /// </summary>
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
