using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JueguitosPro.Models
{
    public class SettingsModel : ModelBase
    {
        public void SaveSettingsData(SettingsData settingsData)
        {
            GameManager.Instance.DataManager.GameData.SettingsData = settingsData;
            
            GameManager.Instance.DataManager.SaveData();
        }

        public SettingsData GetSettingsData()
        {
            return GameManager.Instance.DataManager.GameData.SettingsData;
        }
    }
}
