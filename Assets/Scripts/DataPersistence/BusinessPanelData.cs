using System;
using System.Collections.Generic;

namespace ClickerPrototype.DataPersistence
{
    [Serializable]
    public class BusinessPanelData
    {
        public float progress;
        public int level;
        public List<bool> isUpgradeBought;
    }
}