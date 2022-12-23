using System;
using System.Collections.Generic;
using ClickerPrototype.Configs;

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
        }
    }
}
