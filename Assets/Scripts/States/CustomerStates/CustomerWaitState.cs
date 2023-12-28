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
            
        }

        public void OnExit()
        {
            
        }

        public void Tick()
        {
            
        }
    }
}
