using System.Collections.Generic;
using ClickerPrototype.Configs;
using ClickerPrototype.DataPersistence;
using UnityEngine;

namespace ClickerPrototype.BusinessPanel
{
    public class BusinessPanelPresenter
    {
        private BusinessPanelView _panelView;
        private UpgradeButtonPresenter _firstButton;
        private UpgradeButtonPresenter _secondButton;
        private BusinessPanelData _panelData;
        private BusinessPanelConfig _panelConfig;
        private List<UpgradeButtonPresenter> _buttonPresenters = new();

        private int _income;
        private int _levelUpPrice;
        private int _level;
        
        public int Income
        {
            get => _income;
            set
            {
                _income = value;
                _panelView.Income = value;
            }
         }
        
        public int LevelUpPrice
        {
            get => _levelUpPrice;
            set
            {
                _levelUpPrice = value;
                _panelView.LevelUpPrice = value;
            }
        }
        
        public BusinessPanelPresenter(BusinessPanelView panelView)
        {
            _panelView = panelView;
        }
        
        public void Init(BusinessPanelData panelData, BusinessPanelConfig panelConfig )
        {
            _panelData = panelData;
            _panelConfig = panelConfig;
            UpdatePanelView();
            UpdateUpgradeButtons();
            CheckLevelForIncome(_panelData.level, _panelConfig.IncomeDelay);
        }

        private void CheckLevelForIncome(int level, float delay)
        {
            if (level > 0)
            {
                IncomeProgress progress = new IncomeProgress(ref _panelView.incomeProgress, delay);
            }
        }

        private void UpdateUpgradeButtons()
        {
            Debug.Log("UpdateUpgradeButtons");
            for (int i = 0; i < _panelView.UpgradeButtonViews.Count; i++)
            {               
                var buttonPresenter = new UpgradeButtonPresenter(_panelView.UpgradeButtonViews[i]);
                _buttonPresenters.Add(buttonPresenter);
                buttonPresenter.Init(_panelData.isUpgradeBought[i], _panelConfig.ImprovementConfigs[i]);
            }
        }

        private void UpdatePanelView()
        {
            _panelView.Level = _panelData.level;
            Income = RecalculateIncome();
            LevelUpPrice = RecalculateLevelUpPrice();
            _panelView.Title = _panelConfig.Title;
        }

        private int RecalculateIncome()
        {
            int multiplier1 = _panelData.isUpgradeBought[0] ? _panelConfig.ImprovementConfigs[0].Multiplier : 0;
            int multiplier2 = _panelData.isUpgradeBought[1] ? _panelConfig.ImprovementConfigs[1].Multiplier : 0;
            int newIncome = _panelData.level * _panelConfig.BaseCost * (1 + multiplier1 + multiplier2);
            return newIncome;
        }

        private int RecalculateLevelUpPrice()
        {
            int income = (_panelData.level + 1) * _panelConfig.BaseCost;
            return income;
        }
    }
}
