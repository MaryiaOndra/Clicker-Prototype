using System;
using ClickerPrototype.Configs;
using ClickerPrototype.DataPersistence;
using Unity.VisualScripting;
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

        private void OnApplicationPause() => SaveGame();

        private void InitGamePanel()
        {
            _gamePanelPresenter = new(gamePanelView);
            _gamePanelPresenter.Init(_saveManager.GameData, panelConfigs.Configs);
        }

        private void SaveGame()
        {
            if (_gamePanelPresenter != null)
            {
                _gamePanelPresenter.UpdatePanelData();
                _saveManager.UpdateGameData(_gamePanelPresenter.GameData);
            }
            _saveManager.SaveGame();
        }
    }
}