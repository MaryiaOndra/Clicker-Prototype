using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace ClickerPrototype
{
    public class UpgradeButtonPresenter
    {
        private UpgradeButtonView _buttonView;
        private int _price;

        public event Action<int> OnButtonPressed;
        
        public UpgradeButtonPresenter(UpgradeButtonView buttonView)
        {
            _buttonView = buttonView;
        }

        public void Init()
        {
            _buttonView.OnUpgradeButtonPressed += SendUpgradePrice;
        }

        public void ChangeButtonState(bool isBought)
        {
            _buttonView.IsBought = isBought;
        }

        private void SendUpgradePrice()
        {
            Debug.Log("SendUpgradePrice: " + _price);
           OnButtonPressed?.Invoke(_price);
        }
    }
}