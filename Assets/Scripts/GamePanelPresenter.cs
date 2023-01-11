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
        private GamePanelView _panelView;
        private List<BusinessPanelPresenter> _panelPresenters = new();

        public GameData GameData { get; private set; }

        public void UpdatePanelData()
        {
            for (int i = 0; i < GameData.panelDatas.Count; i++)
            {
                GameData.panelDatas[i] = _panelPresenters[i].PanelData;
            }
        }

        public int Balance
        {
            get => GameData.balance;
            set
            {
                _panelView.Balance = value;
                GameData.balance = value;
            }
        }

        public GamePanelPresenter(GamePanelView panelView)
        {
            _panelView = panelView;
        }

        public void Init(GameData gameData, List<BusinessPanelConfig> panelConfigs)
        {
            GameData = gameData;
            InitPanels(panelConfigs);
            Balance = gameData.balance;
        }

        private void InitPanels(List<BusinessPanelConfig> panelConfigs)
        {
            for (int i = 0; i < panelConfigs.Count; i++)
            {
                if (GameData.panelDatas.Count < panelConfigs.Count)
                {
                    var newPanelData = new BusinessPanelData();
                    newPanelData.isUpgradeBought = new List<bool> {false, false};
                    GameData.panelDatas.Add(newPanelData);
                }

                var panel = CreateBusinessPanel();
                panel.Init(GameData.panelDatas[i], panelConfigs[i]);
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

        private void CheckBalanceToUpgrade(BusinessPanelPresenter panelPresenter,
            UpgradeButtonPresenter buttonPresenter)
        {
            if (!IsEnoughMoneyToUpgrade(buttonPresenter.Price))
                return;

            ChangeBalance(-buttonPresenter.Price);
            panelPresenter.UpgradePanel(buttonPresenter);
        }

        private bool IsEnoughMoneyToUpgrade(float price) =>
            Balance >= price;

        private void CheckBalanceToLevelUp(int amount, BusinessPanelPresenter panelPresenter)
        {
            if (!IsEnoughBalance(amount))
                return;

            ChangeBalance(-amount);
            panelPresenter.LevelUp();
        }

        private bool IsEnoughBalance(int amount) =>
            Balance >= amount;

        private void ChangeBalance(int income) =>
            Balance += income;
    }
}