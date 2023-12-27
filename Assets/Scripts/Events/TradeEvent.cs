using Assets.Scripts.Entitys;
using System;

namespace Assets.Scripts.Events
{
    public static class TradeEvent
    {
        public static Func<Node> OnGetAvailableCustomerAtShopNode;
        public static Func<Node> OnGetEmptyCustomerNode;
        public static Action<Node, Customer> OnAddcustomer;
        public static Func<bool> OnIsAllNodesFul;
    }
}