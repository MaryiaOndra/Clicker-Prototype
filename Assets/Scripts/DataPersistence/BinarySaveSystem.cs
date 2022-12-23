using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;

namespace ClickerPrototype.DataPersistence
{
    public class BinarySaveSystem :ISaveSystem
    {
        private readonly string _filePath;
        
        public BinarySaveSystem()
        {
            _filePath = Application.persistentDataPath + "/Save.dat";
        }

        public void Save(GameData gameData)
        {
            using (FileStream file = File.Create(_filePath))
            {
                new BinaryFormatter().Serialize(file, gameData);
            }
        }

        public async Task<GameData> Load()
        {
            GameData gameData;
            await using FileStream file = File.Open(_filePath, FileMode.Open);
            object loadedFile = new BinaryFormatter().Deserialize(file);
            gameData = (GameData) loadedFile;
            return gameData;
        }
    }
}