using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ClickerPrototype
{
    public class GamePanelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text balance;
        [SerializeField] private Transform businessPanelsContainer;
        [SerializeField] private BusinessPanelView businessPanelPrefab;

        public int Balance
        {
            set => balance.text = value.ToString();
        }

        public Transform BusinessPanelsContainer => businessPanelsContainer;
        public BusinessPanelView BusinessPanelPrefab => businessPanelPrefab;
    }
}
