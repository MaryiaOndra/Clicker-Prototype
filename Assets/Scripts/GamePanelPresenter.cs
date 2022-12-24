using System.Collections.Generic;
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
            Debug.Log($" INIT  GamePanelPresenter");
            
            for (int i = 0; i < panelConfigs.Count; i++)
            {
                if (_gameData.panelDatas.Count <= i)
                {
                    _gameData.panelDatas.Add(new ());
                }
                var panel = CreateBusinessPanel();
                panel.Init(_gameData.panelDatas[i], panelConfigs[i]);
            }
        }

        public BusinessPanelPresenter CreateBusinessPanel()
        {
            var newPanelView = _panelView.CreateBusinessPanelView();
            BusinessPanelPresenter panelPresenter = new(newPanelView);
            _panelPresenters.Add(panelPresenter);
            return panelPresenter;
        }
    }
}