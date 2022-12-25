using System;
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

        public event Action<int> UpdateBalance;
        public event Action<int, BusinessPanelPresenter> LevelUpPressed;

        public BusinessPanelData PanelData
        {
            get
            {
                _panelData.level = _level;
                for (int i = 0; i < _panelData.isUpgradeBought.Count; i++)
                {
                    _panelData.isUpgradeBought[i] = _buttonPresenters[i].IsBought;
                }
                return _panelData;
            }
        }

        private int Level
        {
            get => _level;
            set
            {
                _level = value;
                _panelView.Level = value;
            }
        }

        private int Income
        {
            get => _income;
            set
            {
                _income = value;
                _panelView.Income = value;
            }
         }

        private int LevelUpPrice
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
            _panelView.LevelUpButton.onClick.AddListener(LevelUpButtonPressed);
        }

        private void LevelUpButtonPressed()
        {
            LevelUpPressed?.Invoke(_levelUpPrice, this);
        }

        private void CheckLevelForIncome(int level, float delay)
        {
            if (level > 0)
            {
                IncomeProgress progress = new IncomeProgress(ref _panelView.incomeProgress, delay);
                progress.IsTimeToIncome += ProgressIncomeTimesUp;
            }
        }

        private void ProgressIncomeTimesUp()
        {
            UpdateBalance?.Invoke(Income);
        }

        private void UpdateUpgradeButtons()
        {
            for (int i = 0; i < _panelView.UpgradeButtonViews.Count; i++)
            {               
                var buttonPresenter = new UpgradeButtonPresenter(_panelView.UpgradeButtonViews[i]);
                _buttonPresenters.Add(buttonPresenter);
                buttonPresenter.Init(_panelData.isUpgradeBought[i], _panelConfig.ImprovementConfigs[i]);
            }
        }

        private void UpdatePanelView()
        {
            Level = _panelData.level;
            Income = RecalculateIncome();
            LevelUpPrice = RecalculateLevelUpPrice();
            _panelView.Title = _panelConfig.Title;
        }

        private int RecalculateIncome()
        {
            int multiplier1 = _panelData.isUpgradeBought[0] ? _panelConfig.ImprovementConfigs[0].Multiplier : 0;
            int multiplier2 = _panelData.isUpgradeBought[1] ? _panelConfig.ImprovementConfigs[1].Multiplier : 0;
            int newIncome = Level * _panelConfig.BaseCost * (1 + multiplier1 + multiplier2);
            return newIncome;
        }

        private int RecalculateLevelUpPrice()
        {
            int income = (Level + 1) * _panelConfig.BaseCost;
            return income;
        }

        public void LevelUp()
        {
            Level++;
            Income = RecalculateIncome();
            LevelUpPrice = RecalculateLevelUpPrice();
        }
    }
}
