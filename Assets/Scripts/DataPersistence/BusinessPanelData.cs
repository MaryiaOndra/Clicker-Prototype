using System;

namespace ClickerPrototype.DataPersistence
{
    [Serializable]
    public class BusinessPanelData
    {
        public float progress;
        public int level;
        public bool isFirstUpgradeBought;
        public bool isSecondUpgradeBought;
    }
}