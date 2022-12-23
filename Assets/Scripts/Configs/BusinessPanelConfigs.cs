using System.Collections.Generic;
using UnityEngine;

namespace ClickerPrototype.Configs
{
    
    public class BusinessPanelConfigs : ScriptableObject
    {
        [SerializeField] private List<BusinessPanelConfig> configs;

        public List<BusinessPanelConfig> Configs => configs;
    }
}