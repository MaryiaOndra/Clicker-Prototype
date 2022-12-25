using UnityEngine;

namespace ClickerPrototype.Configs
{
    [CreateAssetMenu(fileName = "ImprovementConfig", menuName = "Configs/ImprovementConfig")]
    public class BusinessImprovementConfig : ScriptableObject
    {
        [SerializeField] private string title;
        [SerializeField] private int price;
        [SerializeField] private int incomeMultiplier;

        public string Title => title;
        public int Price => price;
        public int Multiplier => incomeMultiplier;
    }
}