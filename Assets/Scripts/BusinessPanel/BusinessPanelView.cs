using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ClickerPrototype.BusinessPanel
{
    public class BusinessPanelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text title;
        [SerializeField] private TMP_Text level;
        [SerializeField] private TMP_Text income;
        [SerializeField] private TMP_Text lvlUpValue;
        [SerializeField] public Slider incomeProgress;
        [SerializeField] private List<UpgradeButtonView> upgradeButtonViews;

        public List<UpgradeButtonView> UpgradeButtonViews => upgradeButtonViews;

        public Slider ProgressSlider => incomeProgress;

        public int Progress
        {
            set => incomeProgress.value = value;
        }

        public int Income
        {
            set => income.text = value.ToString() + "$";
        }

        public int LevelUpPrice
        {
            set => lvlUpValue.text = value.ToString();
        }

        public int Level
        {
            set => level.text = value.ToString();
        }

        public string Title
        {
            set => title.text = value;
        }
    }
}
