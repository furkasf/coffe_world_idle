using System;
using System.Collections.Generic;
using Assets.States;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.States.CustomerStates
{
    public class CustomerWaitState : IState
    {
        Customer _customer;
        public CustomerWaitState(Customer customer)
        {
            _customer = customer;
        }
        public void OnEnter()
        {
            UnityEngine.Debug.Log("Customer Enter wait state");
            //_customer.CoffeeSprite.SetActive(true);
        }

        public void OnExit()
        {
            //_customer.CoffeeSprite.SetActive(false);
        }

        public void Tick()
        {
            
        }
    }
}
