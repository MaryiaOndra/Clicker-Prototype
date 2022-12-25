using System.Collections.Generic;
using ClickerPrototype.BusinessPanel;
using ClickerPrototype.Configs;
using ClickerPrototype.DataPersistence;
using UnityEngine;

namespace ClickerPrototype
{
    public class GamePanelPresenter
    {
        private GameData _gameData;
        private GamePanelView _panelView;
        private List<BusinessPanelPresenter> _panelPresenters = new();

        public GameData GameData => _gameData;
        
        public GamePanelPresenter(GamePanelView panelView)
        {
            _panelView = panelView;
        }

        public void Init(GameData gameData, List<BusinessPanelConfig> panelConfigs)
        {
            _gameData = gameData;
            InitPanels(panelConfigs);
            _panelView.Balance = _gameData.balance;
        }

        private void InitPanels( List<BusinessPanelConfig> panelConfigs)
        {
            for (int i = 0; i < panelConfigs.Count; i++)
            {
                if (_gameData.panelDatas.Count < panelConfigs.Count)
                {
                    var newPanelData = new BusinessPanelData();
                    newPanelData.isUpgradeBought = new List<bool> {false, false};
                    _gameData.panelDatas.Add(newPanelData);
                }
                var panel = CreateBusinessPanel();
                panel.Init(_gameData.panelDatas[i], panelConfigs[i]);
            }
        }

        private BusinessPanelPresenter CreateBusinessPanel()
        {
            var newPanelView = _panelView.CreateBusinessPanelView();
            BusinessPanelPresenter panelPresenter = new(newPanelView);
            _panelPresenters.Add(panelPresenter);
            return panelPresenter;
        }
    }
}