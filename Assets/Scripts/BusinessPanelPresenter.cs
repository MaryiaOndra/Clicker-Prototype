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

        public BusinessPanelPresenter(BusinessPanelView panelView)
        {
            _panelView = panelView;
        }
        
        public void Init(BusinessPanelData panelData, BusinessPanelConfig panelConfig )
        {
            _panelData = panelData;
            _panelConfig = panelConfig;
        }
    }
}
