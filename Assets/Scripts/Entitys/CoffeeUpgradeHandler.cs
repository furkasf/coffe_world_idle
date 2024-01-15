using UnityEngine;
using Model;

namespace Entitys
{
    public class CoffeeUpgradeHandler : MonoBehaviour
    {
        [SerializeField] private CoffeeData latte;
        [SerializeField] private CoffeeData espresso;

        private void Awake()
        {
            coffeeData.ResetUpgrade();
        }

        private void OnEnable()
        {
            CoffeeUpgradeEvent.OnGetUpGradeCost += GetUpgradeCost;
            CoffeeUpgradeEvent.OnGetSellPrice += GetSellPrice;
            CoffeeUpgradeEvent.OnGetManifactureTime += GetManifactureTime;
            CoffeeUpgradeEvent.OnCanUpGrade += CanUpgrade;
            CoffeeUpgradeEvent.OnIncreaseUpgradeCost += IncreaseUpgradeCost;
        }

        private void OnDisable()
        {
            CoffeeUpgradeEvent.OnGetUpGradeCost -= GetUpgradeCost;
            CoffeeUpgradeEvent.OnGetSellPrice -= GetSellPrice;
            CoffeeUpgradeEvent.OnGetManifactureTime -= GetManifactureTime;
            CoffeeUpgradeEvent.OnCanUpGrade -= CanUpgrade;
            CoffeeUpgradeEvent.OnIncreaseUpgradeCost -= IncreaseUpgradeCost;
        }


        private int GetUpgradeCost(CoffeeType coffeeType)
        {
            CoffeeData coffee = GetCoffeeData(coffeeType);

            return coffee.GetUpgradeCost();
        }

        private int GetSellPrice(CoffeeType coffeeType)
        {
            CoffeeData coffee = GetCoffeeData(coffeeType);

            return coffee.GetSellPrice();
        }

        private float GetManifactureTime(CoffeeType coffeeType)
        {
            CoffeeData coffee = GetCoffeeData(coffeeType);

            return coffee.GetManufactureTime();
        }

        private bool CanUpgrade(CoffeeType coffeeType)
        {
            CoffeeData coffee = GetCoffeeData(coffeeType);

            return coffee.CanUpgrade();
        }

        private void IncreaseUpgradeCost(CoffeeType coffeeType)
        {
            CoffeeData coffee = GetCoffeeData(coffeeType);

            coffee.IncreaseUpGradeCost();
        }

        public CoffeData GetCoffeeData(CoffeeType coffeeType)
        {
            switch (coffeeType)
            {
                case CoffeeType.Latte:
                    return latte;

                case CoffeeType.Espresso:
                    return espresso;

                default: return null;
            }
        }
    }
}
