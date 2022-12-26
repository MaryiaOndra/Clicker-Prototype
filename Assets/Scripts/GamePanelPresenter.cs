using System;
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
        public event Action NeedToSave;
        
        public GameData GameData {
            get
            {
                for (int i = 0; i < _gameData.panelDatas.Count; i++)
                {
                    _gameData.panelDatas[i] = _panelPresenters[i].PanelData;
                }
                return _gameData;
            }
        }

        public int Balance
        {
            get => _gameData.balance;
            set
            {
                _panelView.Balance = value;
                _gameData.balance = value;
            }
        }

        public GamePanelPresenter(GamePanelView panelView)
        {
            _panelView = panelView;
        }

        public void Init(GameData gameData, List<BusinessPanelConfig> panelConfigs)
        {
            _gameData = gameData;
            InitPanels(panelConfigs);
            Balance = gameData.balance;
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
            panelPresenter.UpdateBalance += ChangeBalance;
            panelPresenter.LevelUpPressed += CheckBalanceToLevelUp;
            panelPresenter.NeedToUpgrade += CheckBalanceToUpgrade;
            return panelPresenter;
        }

        private void CheckBalanceToUpgrade(BusinessPanelPresenter panelPresenter, UpgradeButtonPresenter buttonPresenter)
        {
            if (Balance >= buttonPresenter.Price)
            {
                ChangeBalance(-buttonPresenter.Price);
                panelPresenter.UpgradePanel(buttonPresenter);
            }
        }


        private void CheckBalanceToLevelUp(int amount, BusinessPanelPresenter panelPresenter)
        {
            if (Balance >= amount)
            {
                ChangeBalance(-amount);
                panelPresenter.LevelUp();
            }
        }

        private void ChangeBalance(int income)
        {
            Balance += income;
            NeedToSave?.Invoke();
        }
    }
}