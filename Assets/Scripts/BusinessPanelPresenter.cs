using System.Collections;
using System.Collections.Generic;
using ClickerPrototype.Configs;
using ClickerPrototype.DataPersistence;
using UnityEngine;

namespace ClickerPrototype
{
    public class BusinessPanelPresenter
    {
        private BusinessPanelView _panelView;
        private UpgradeButtonPresenter _firstButton;
        private UpgradeButtonPresenter _secondButton;
        private BusinessPanelData _panelData;
        private BusinessPanelConfig _panelConfig;

        private int _income;
        private int _levelUpPrice;
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
            _panelView.Init(panelConfig);
            Income = RecalculateIncome();
            LevelUpPrice = RecalculateLevelUpPrice();
        }

        private int RecalculateIncome()
        {
            int multiplier1 = _panelData.isFirstUpgradeBought ? _panelConfig.FirstImprovementConfig.Multiplier : 0;
            int multiplier2 = _panelData.isSecondUpgradeBought ? _panelConfig.SecondImprovementConfig.Multiplier : 0;
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
