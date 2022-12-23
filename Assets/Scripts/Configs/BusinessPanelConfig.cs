using UnityEngine;

namespace ClickerPrototype.Configs
{
    public class BusinessPanelConfig : ScriptableObject
    {
        [SerializeField] private string title;
        [SerializeField] private int incomeDelay;
        [SerializeField] private int baseCost;
        [SerializeField] private int baseIncome;
        [SerializeField] private BusinessImprovementConfig firstImprovementConfig;
        [SerializeField] private BusinessImprovementConfig secondImprovementConfig;

        public string Title => title;
        public int IncomeDelay => incomeDelay;
        public int BaseCost => baseCost;
        public int BaseIncome => baseIncome;
        public BusinessImprovementConfig FirstImprovementConfig => firstImprovementConfig;
        public BusinessImprovementConfig SecondImprovementConfig => secondImprovementConfig;
    }
}