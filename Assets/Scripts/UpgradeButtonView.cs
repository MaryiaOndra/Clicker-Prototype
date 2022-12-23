using TMPro;
using UnityEngine;

namespace ClickerPrototype
{
    public class UpgradeButtonView : MonoBehaviour
    {
        [SerializeField] private TMP_Text title;
        [SerializeField] private TMP_Text procent;
        [SerializeField] private TMP_Text price;
        [SerializeField] private GameObject priceComponent;
        [SerializeField] private GameObject isBoughtComponent;

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
            }
        }
    }
}