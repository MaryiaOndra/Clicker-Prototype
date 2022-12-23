using System.Collections.Generic;
using UnityEngine;

namespace ClickerPrototype.Configs
{
    [CreateAssetMenu(fileName = "BusinessPanelCollection", menuName = "Configs/BusinessPanelCollection")]

    public class BusinessPanelCollection : ScriptableObject
    {
        [SerializeField] private List<BusinessPanelConfig> configs;

        public List<BusinessPanelConfig> Configs => configs;
    }
}