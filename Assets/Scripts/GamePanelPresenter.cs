using System.Collections.Generic;
using ClickerPrototype.Configs;
using ClickerPrototype.DataPersistence;
using UnityEngine;

namespace ClickerPrototype
{
    public class GamePanelPresenter
    {
        private GamePanelView _panelView;
        private List<BusinessPanelPresenter> _panelPresenters = new();
        
        public GamePanelPresenter(GamePanelView panelView)
        {
            _panelView = panelView;
        }

        public void Init(List<BusinessPanelData> panelDatas, List<BusinessPanelConfig> panelConfigs)
        {
            for (int i = 0; i < panelConfigs.Count; i++)
            {
                BusinessPanelPresenter panelPresenter = CreateBusinessPanel();
                panelPresenter.Init(panelDatas[i], panelConfigs[i]);
            }
        }

        public BusinessPanelPresenter CreateBusinessPanel()
        {
            BusinessPanelView businessPanelView = Object.Instantiate(_panelView.BusinessPanelPrefab,
                _panelView.BusinessPanelsContainer);
            BusinessPanelPresenter panelPresenter = new(businessPanelView);
            return panelPresenter;
        }
    }
}