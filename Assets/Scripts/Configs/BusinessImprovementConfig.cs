using UnityEngine;

namespace ClickerPrototype.Configs
{
    public class BusinessImprovementConfig : ScriptableObject
    {
        [SerializeField] private int price;
        [SerializeField] private int incomeMultiplier;
    }
}