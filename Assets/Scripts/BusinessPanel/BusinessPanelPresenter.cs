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
        private IncomeProgress _incomeProgress;
        private int _income;
        private int _levelUpPrice;
        private int _level;

        public event Action<int> UpdateBalance;
        public event Action<int, BusinessPanelPresenter> LevelUpPressed;
        public event Action<BusinessPanelPresenter, UpgradeButtonPresenter> NeedToUpgrade;

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
            UpdateUpgradeButtons();
            UpdatePanelView();
            CheckLevelForIncome(_panelData.level, _panelConfig.IncomeDelay);
            _panelView.LevelUpButton.onClick.AddListener(LevelUpButtonPressed);
        }

        private void LevelUpButtonPressed()
        {
            LevelUpPressed?.Invoke(_levelUpPrice, this);
        }

        private void CheckLevelForIncome(int level, float delay)
        {
            if (level > 0 && _incomeProgress == null)
            {
                _incomeProgress = new IncomeProgress(ref _panelView.incomeProgress, delay);
                _incomeProgress.IsTimeToIncome += ProgressIncomeTimesUp;
            }
        }

        private void ProgressIncomeTimesUp()
        {
            UpdateBalance?.Invoke(Income);
        }
        
        
        private void UpgradeButtonPressed(UpgradeButtonPresenter buttonPresenter)
        {
            NeedToUpgrade?.Invoke(this, buttonPresenter);
        }

        private void UpdateUpgradeButtons()
        {
            for (int i = 0; i < _panelView.UpgradeButtonViews.Count; i++)
            {               
                var buttonPresenter = new UpgradeButtonPresenter(_panelView.UpgradeButtonViews[i]);
                _buttonPresenters.Add(buttonPresenter);
                buttonPresenter.OnUpgradeButtonPressed += UpgradeButtonPressed;
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
            float multiplier1 = _buttonPresenters[0].IsBought ? _buttonPresenters[0].Procent / 100f : 0;
            float multiplier2 = _buttonPresenters[1].IsBought ? _panelConfig.ImprovementConfigs[1].Multiplier/100f : 0;
            int newIncome = (int)(Level * _panelConfig.BaseIncome * (1f + multiplier1 + multiplier2));
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
            CheckLevelForIncome(Level, _panelConfig.IncomeDelay);
        }

        public void UpgradePanel(UpgradeButtonPresenter buttonPresenter)
        {
            buttonPresenter.IsBought = true;
            Income = RecalculateIncome();
        }
    }
}
