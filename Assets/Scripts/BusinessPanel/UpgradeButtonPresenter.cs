using System;
using ClickerPrototype.Configs;
using UnityEngine;

namespace ClickerPrototype.BusinessPanel
{
    public class UpgradeButtonPresenter
    {
        private UpgradeButtonView _buttonView;
        private int _price;
        private bool _isBought;
        private int _procent;

        private int Price
        {
            set { _buttonView.Price = value;
                _price = value;
            }
        }

        private int Procent
        {
            set { _buttonView.Procent = value;
                _procent = value;
            }
        }

        private bool IsBought
        {
            set { _buttonView.IsBought = value;
                _isBought = value;
                if (value)
                {
                    _buttonView.OnUpgradeButtonPressed -= SendUpgradePrice;
                }
            }
        }

        public event Action<int, int> OnButtonPressed;
        
        public UpgradeButtonPresenter(UpgradeButtonView buttonView)
        {
            _buttonView = buttonView;
        }

        public void Init(bool isBought, BusinessImprovementConfig config)
        {
            _buttonView.OnUpgradeButtonPressed += SendUpgradePrice;
            UpdatePanelView(isBought, config);
        }

        private void UpdatePanelView(bool isBought, BusinessImprovementConfig config)
        {
            _buttonView.Title = config.Title;
            Procent = config.Multiplier;
            Price = config.Price ;
            IsBought = isBought;
        }

        private void SendUpgradePrice()
        {
            Debug.Log("SendUpgradePrice: " + _price);
           OnButtonPressed?.Invoke(_price, _procent);
        }
    }
}