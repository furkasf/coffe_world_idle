using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Assets.Scripts.Entitys
{
    public class TradeStand : MonoBehaviour
    {
        private List<Node> _nodes = new List<Node> ();

        [SerializeField] Transform[] _baristaPoints = new Transform[3];
        [SerializeField] Transform[] _customerPoints = new Transform[3];

        private void Awake()
        {
            for (int i = 0; i < 3; i++)
            {
                Node node = new Node(_customerPoints[i].position, _baristaPoints[i].position);
                _nodes.Add(node);
            }
        }

        private void OnEnable()
        {
            TradeEvent.OnGetAvailableCustomerAtShopNode += GetAvailableCustomerAtShopNode;
            TradeEvent.OnGetEmptyCustomerNode += GetEmptyNode;
            TradeEvent.OnAddcustomer += AddCustomer;
            TradeEvent.OnIsAllNodesFull += IsAllNodesFull;
        }

        private void OnDisable()
        {
            
        }

        private void AddCustomer(Node node, Customer customer)
        {
            node.AddCustomer(customer);
        }

        private Node GetEmptyNode()
        {
            Node sNode = null;

            foreach (Node node in _nodes)
            {
                if (node.IsNodeAvaible())
                {
                    sNode = node;
                }
            }
            return sNode;
        }

        private bool IsAllNodesFull()
        {
            bool isFull = true;

            foreach (Node node in _nodes)
            {
                if (node.IsNodeAvaible())
                {
                    isFull = false;
                    break;
                }
            }
            return isFull;
        }
        private Node GetAvailableCustomerAtShopNode()
        {
            Node sNode = null;

            foreach (Node node in _nodes)
            {
                if (node.IsCustomerWaiting())
                {
                    sNode = node;
                    return sNode;
                }
            }

            return sNode;
        }
    }
}