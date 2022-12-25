using System.Collections.Generic;
using UnityEngine;

namespace ClickerPrototype.Configs
{
    [CreateAssetMenu(fileName = "BusinessPanelConfig", menuName = "Configs/BusinessPanelConfig")]
    public class BusinessPanelConfig : ScriptableObject
    {
        [SerializeField] private string title;
        [SerializeField] private int incomeDelay;
        [SerializeField] private int baseCost;
        [SerializeField] private int baseIncome;
        [SerializeField] private List<BusinessImprovementConfig> improvementConfigs;

        public string Title => title;
        public int IncomeDelay => incomeDelay;
        public int BaseCost => baseCost;
        public int BaseIncome => baseIncome;
        public List<BusinessImprovementConfig> ImprovementConfigs => improvementConfigs;
    }
}