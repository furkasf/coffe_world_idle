using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events
{
    public static class UpgradeEvent
    {
        public static Action OnSellCoffeeCream;
        public static Action OnUpgradeCoffee;
    }
}