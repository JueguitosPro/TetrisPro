using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace JueguitosPro
{
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
