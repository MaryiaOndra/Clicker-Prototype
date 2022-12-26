using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ClickerPrototype.BusinessPanel
{
    public class UpgradeButtonView : MonoBehaviour
    {
        [SerializeField] private TMP_Text title;
        [SerializeField] private TMP_Text procent;
        [SerializeField] private TMP_Text price;
        [SerializeField] private GameObject priceComponent;
        [SerializeField] private GameObject isBoughtComponent;
        [SerializeField] private Button upgradeButton;

        public event Action OnUpgradeButtonPressed;

        private void OnEnable() => upgradeButton.onClick.AddListener(OnButtonClicked);
        private void OnDisable() => upgradeButton.onClick.RemoveListener(OnButtonClicked);
        private void OnButtonClicked() => OnUpgradeButtonPressed?.Invoke();

        public string Title
        {
            set => title.text = value;
        }
        
        public int Procent
        {
            set => procent.text = $"+ {value}%";
        }

        public int Price
        {
            set => price.text = $"{value}$" ;
        }

        public bool IsBought
        {
            set
            {
                priceComponent.SetActive(!value);
                isBoughtComponent.SetActive(value);
                upgradeButton.interactable = !value;
            }
        }
    }
}