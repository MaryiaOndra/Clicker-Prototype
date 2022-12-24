using System.Threading.Tasks;
using ClickerPrototype.Configs;
using ClickerPrototype.DataPersistence;
using UnityEngine;

namespace ClickerPrototype
{
    public class SaveManager
    {
        private GameData _gameData;
        public GameData GameData => _gameData;
        private ISaveSystem _saveSystem;

        public SaveManager()
        {
            _saveSystem = new BinarySaveSystem();
        }

        public void NewGame()
        {
            Debug.Log("Create new game data!");
            _gameData = new GameData();
            SaveGame();
        }

        public void SaveGame()
        {
            _saveSystem.Save(_gameData);
        }

        public async Task LoadGame()
        {
            _gameData = await _saveSystem.Load();
        }

        public void UpdateGameData(GameData gameData)
        {
            _gameData = gameData;
        }
    }
}