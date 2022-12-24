using ClickerPrototype.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ClickerPrototype
{
    public class BusinessPanelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text title;
        [SerializeField] private TMP_Text level;
        [SerializeField] private TMP_Text income;
        [SerializeField] private TMP_Text lvlUpValue;
        [SerializeField] private Slider incomeProgress;
        [SerializeField] private UpgradeButtonView firstUpgradeButtonView;
        [SerializeField] private UpgradeButtonView secondUpgradeButtonView;

        public int Income
        {
            set => income.text = value.ToString() + "$";
        }

        public int LevelUpPrice
        {
            set => lvlUpValue.text = value.ToString();
        }

        public void Init(BusinessPanelConfig config)
        {
            title.text = config.Title;
            Income = config.BaseIncome;
        }
    }
}
