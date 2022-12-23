using UnityEngine;

namespace ClickerPrototype.Configs
{
    [CreateAssetMenu(fileName = "ImprovementConfig", menuName = "Configs/ImprovementConfig")]
    public class BusinessImprovementConfig : ScriptableObject
    {
        [SerializeField] private int price;
        [SerializeField] private int incomeMultiplier;
    }
}