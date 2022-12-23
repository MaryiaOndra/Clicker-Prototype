using System;
using ClickerPrototype.Configs;
using UnityEngine;

namespace ClickerPrototype
{
    public class GameLoader : MonoBehaviour
    {
        [SerializeField] private GamePanelView gamePanelView;
        [SerializeField] private BusinessPanelCollection _panelConfigs;

        private GamePanelPresenter _gamePanelPresenter;
        private SaveManager _saveManager;

        private async void Start()
        {
            _saveManager = new SaveManager();
            await _saveManager.LoadGame();
            
            //TODO: load data from save manager
            //if data = null
            //init default data
            //save it in save manager
            InitGamePanel();
        }

        private void InitGamePanel()
        {
            _gamePanelPresenter = new(gamePanelView);
            _gamePanelPresenter.Init(_saveManager.GameData.panelDatas, _panelConfigs.Configs);
        }

        private void OnApplicationQuit()
        {
            throw new NotImplementedException();
        }
    }
}