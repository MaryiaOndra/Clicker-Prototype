using System.Collections;
using System.Collections.Generic;
using ClickerPrototype.BusinessPanel;
using TMPro;
using UnityEngine;

namespace ClickerPrototype
{
    public class GamePanelView : MonoBehaviour
    {
        private const string PANEL_NAME = "BusinessPanel";
        
        [SerializeField] private TMP_Text balance;
        [SerializeField] private Transform businessPanelsContainer;
        [SerializeField] private GameObject businessPanelPrefab;

        public int Balance
        {
            set => balance.text = value.ToString();
        }
        
        public BusinessPanelView CreateBusinessPanelView()
        {
            var newPanel = Instantiate(businessPanelPrefab,
                businessPanelsContainer);
            newPanel.name = PANEL_NAME;
            return newPanel.GetComponent<BusinessPanelView>();
        }
    }
}
