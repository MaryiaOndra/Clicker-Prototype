using System;
using System.Collections.Generic;

namespace ClickerPrototype.DataPersistence
{
    [Serializable]
    public class GameData
    {
        public int balance;
        public List<BusinessPanelData> panelDatas;
            
        public GameData()
        {
            balance = 0;
            panelDatas = new();
            var firstBusiness = new BusinessPanelData();
            firstBusiness.isUpgradeBought = new List<bool>{false, false}; 
            firstBusiness.level = 1;
            panelDatas.Add(firstBusiness);
        }
    }
}
