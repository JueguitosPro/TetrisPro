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
        
        /// <summary>
        /// Gets or sets the game data. When getting, it loads the data if not already loaded.
        /// </summary>
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
        /// Saves the game data to a file in JSON format.
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
