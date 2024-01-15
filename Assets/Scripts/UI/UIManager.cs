using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Events;
using TMPro;

namespace GameUI
{
    public enum PanelType
    {
        StartPanel, InGamePanel, UpGradePanel
    }

    public class UIManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> panels;
        [SerializeField] private TextMeshProUGUI playerMoney;
        [SerializeField] private TextMeshProUGUI sellPriceText;
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private TextMeshProUGUI upGradeCostText;

        private UIChangePanelCommand _panelCommand;
        private int _money;

        private void Awake()
        {
            _panelCommand = new UIChangePanelCommand(ref panels);
        }

        private void OnEnable()
        {
           UpgradeEvent.OnUpgradeCoffee += UpgradeCoffee;
           UpgradeEvent.OnSellCoffeeCream += SellCoffee;
        }

        private void OnDisable()
        { 
           UpgradeEvent.OnUpgradeCoffee -= UpgradeCoffee;
           UpgradeEvent.OnSellCoffeeCream -= SellCoffee;
        }

        public void OpenStartPanel()
        {
            _panelCommand.Execute(PanelType.StartPanel);
        }

        public void OpenInGamePanel()
        {
            _panelCommand.Execute(PanelType.InGamePanel);
            SpawnEvent.OnSpawn();
        }

        public void OpenUpGradePanel()
        {
            _panelCommand.Execute(PanelType.UpGradePanel);

            sellPriceText.text = "Price : " + CoffeeUpgradeEvent.OnGetSellPrice(CoffeeType.Latte;
            timeText.text = "Time : " + CoffeeUpgradeEvent.OnGetManifactureTime(CoffeeType.Latte);
            upGradeCostText.text = "Cost : " + CoffeeUpgradeEvent.OnGetUpGradeCost(CoffeeType.Latte;
        }

        public void SellCoffee()
        {
            _money += CoffeeUpgradeEvent.OnGetSellPrice(CoffeeType.Latte);
            playerMoney.text = "Money : " + _money;
        }

        public void UpgradeCoffee()
        {
            int upgradeCost = CoffeeUpgradeEvent.OnGetUpGradeCost(CoffeeType.Latte);

            if (_money < upgradeCost) return;

            _money -= upgradeCost;

            CoffeeUpgradeEvent.OnIncreaseUpgradeCost(CoffeeType.Latte;

            sellPriceText.text = "Price : " + CoffeeUpgradeEvent.OnGetSellPrice(CoffeeType.Latte);
            timeText.text = "Time : " + CoffeeUpgradeEvent.OnGetManifactureTime(CoffeeType.Latte);
            upGradeCostText.text = "Cost : " + CoffeeUpgradeEvent.OnGetUpGradeCost(CoffeeType.Latte);
            playerMoney.text = "Money : " + _money;
        }
    }
}
