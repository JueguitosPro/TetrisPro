using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace JueguitosPro
{
    /// <summary>
    /// Handles Save/Load <see cref="GameData"/>GameData from a json file
    /// </summary>
    public class DataManager
    {
        private readonly string filePath = Path.Combine(Application.dataPath, Constants.DataFile);
        private GameData gameData;
        
        public GameData GameData
        {
            get
            {
                if (gameData == null)
                {
                    LoadData();
                }

                return gameData;
            }

            private  set => gameData = value;
        }

        /// <summary>
        /// Saves the GameData into a file text called GameData.txt
        /// </summary>
        public void SaveData()
        {
            string json = JsonConvert.SerializeObject(gameData);

            try
            {
                File.WriteAllText(filePath, json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void LoadData()
        {
            if (!File.Exists(filePath))
            {
                GameData = new GameData();
                return;
            }
            
            try
            {
                string json = File.ReadAllText(filePath);

                GameData = JsonConvert.DeserializeObject<GameData>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
