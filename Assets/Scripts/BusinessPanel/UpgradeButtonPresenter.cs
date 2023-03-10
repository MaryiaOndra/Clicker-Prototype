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
        public event Action<UpgradeButtonPresenter> OnUpgradeButtonPressed;

        public int Price
        {
            get => _price;
            set { _buttonView.Price = value;
                _price = value;
            }
        }

        public int Procent
        {
            get => _procent;
            set { _buttonView.Procent = value;
                _procent = value;
            }
        }

        public bool IsBought
        {
            get => _isBought;
            set { _buttonView.IsBought = value;
                _isBought = value;
                if (value)
                {
                    _buttonView.OnUpgradeButtonPressed -= SendUpgradePrice;
                }
            }
        }
       
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
           OnUpgradeButtonPressed?.Invoke(this);
        }
    }
}