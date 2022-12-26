using System;
using ClickerPrototype.Configs;
using ClickerPrototype.DataPersistence;
using UnityEngine;

namespace ClickerPrototype
{
    public class GameLoader : MonoBehaviour
    {
        [SerializeField] private GamePanelView gamePanelView;
        [SerializeField] private BusinessPanelCollection panelConfigs;

        private GamePanelPresenter _gamePanelPresenter;
        private SaveManager _saveManager;

        private async void Start()
        {
            _saveManager = new SaveManager();
            await _saveManager.LoadGame();
            InitGamePanel();
        }

        private void InitGamePanel()
        {
            _gamePanelPresenter = new(gamePanelView);
            _gamePanelPresenter.Init(_saveManager.GameData, panelConfigs.Configs);
            _gamePanelPresenter.NeedToSave += SaveGame;
        }

        private void OnApplicationQuit()
        {
            SaveGame();
        }

        private void SaveGame()
        {
            _saveManager.UpdateGameData(_gamePanelPresenter.GameData);
            _saveManager.SaveGame();
        }

        private void OnDestroy()
        {
            _gamePanelPresenter.NeedToSave -= SaveGame;
        }
    }
}