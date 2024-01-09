using Assets.Scripts.Entitys;
using Assets.Scripts.Events;
using Assets.States;
using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.States.CustomerStates
{
    public class GoToCoffeeState : IState
    {
        private readonly Customer _customer;
        private Sequence _mySequence;


        public GoToCoffeeState(Customer customer)
        {
            _customer = customer;
        }
        public void OnEnter()
        {
            UnityEngine.Debug.Log("Customer Enter goto cofffee state");
            Node node = TradeEvent.OnGetEmptyCustomerNode();

            _customer.IsReadyToLeave = false;
            
            if (_customer.CustomerNode == null)
            {
                _customer.CustomerNode = node;
            }

            Transform customerTrans = _customer.transform;

            Vector3 lookDir = _customer.CustomerNode.CustomerWaypoint - customerTrans.position;
            Quaternion lookRot = Quaternion.LookRotation(lookDir);

            _mySequence = DOTween.Sequence();
            _mySequence.Append(customerTrans.DORotateQuaternion(lookRot, 0.1f));
            _mySequence.Append(customerTrans.DOMove(_customer.CustomerNode.CustomerWaypoint, 1.5f)); // fetch from data
            _mySequence.Append(customerTrans.DORotate(new Vector3(0, 180, 0), 0.1f));

            _mySequence.OnComplete(() =>
            {
                _customer.IsGoToCoffee = true;
                TradeEvent.OnAddcustomer(node, _customer);
            });
        }

        public void OnExit()
        {

        }

        public void Tick()
        {

        }
    }
}
