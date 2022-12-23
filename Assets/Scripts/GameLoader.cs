using System;
using ClickerPrototype.Configs;
using UnityEngine;

namespace ClickerPrototype
{
    public class GameLoader : MonoBehaviour
    {
        [SerializeField] private BusinessPanelCollection _panelConfigs;

        private void Start()
        {
            //TODO: load data from save manager
            //if data = null
            //init default data
            //save it in save manager
        }
    }
}