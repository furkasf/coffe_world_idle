using Assets.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.States.CustomerStates
{
    public class GoToCoffeeState : IState
    {
        Customer _customer;
        public GoToCoffeeState(Customer customer) 
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
