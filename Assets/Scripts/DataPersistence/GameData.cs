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
            firstBusiness.level = 1;
            panelDatas.Add(firstBusiness);
        }
    }
}
