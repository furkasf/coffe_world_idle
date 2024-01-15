using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events
{
    public static class CoffeeUpgradeEvent
    {
        public static Action<CoffeeType> IncreaseUpgradeCost;
        public static Func<CoffeeType, int> GetUpgradeCost;
        public static Func<CoffeeType, int> GetSellPrice;
        public static Func<CoffeeType, float> GetManifactureTime;
        public static Func<CoffeeType, bool> CanUpgrade;
    }
}