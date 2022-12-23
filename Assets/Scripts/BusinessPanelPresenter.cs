using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClickerPrototype
{
    public class BusinessPanelPresenter
    {
        private BusinessPanelView _panelView;

        public BusinessPanelPresenter(BusinessPanelView panelView)
        {
            _panelView = panelView;
        }
    }
}
