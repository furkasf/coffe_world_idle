using UnityEngine;

namespace Assets.Scripts.Entitys
{
    public class Node : MonoBehaviour
    {
        private Barista _barista;
        private Customer _customer;
        private Vector3 _baristaWaypoint;
        private Vector3 _customerpoint;

        public Barista Barista => _barista;
        public Customer Customer => _customer;
        public Vector3 BaristaWaypoint => _baristaWaypoint;
        public Vector3 CustomerWaypoint => _customerpoint;

        public Node(Vector3 customerWaypoint, Vector3 baristaWaypoint)
        {
            _customerpoint = customerWaypoint;
            _baristaWaypoint = baristaWaypoint;
        }

        public void AddCustomer(Customer customer)
        {
            if (customer == null) return;
            _customer = customer;
        }

        public void AddBarista(Barista barista)
        {
            if (barista == null) return;
            _barista = barista;
        }

        public bool IsNodeAvaible() => _customer == null;
        public bool IsCustomerWaiting() => _customer != null && _barista == null;

        public void ResetNodes()
        {
            _barista = null;
            _customer = null;
        }
    }
}