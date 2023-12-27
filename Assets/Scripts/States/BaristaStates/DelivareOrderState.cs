using Assets.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.States.BaristaStates
{
    public class DelivareOrderState : IState
    {
        public void OnEnter()
        {
            //exit from praper state
            //go to cutomer
            //wait delivery time is finish
            // go to return state
        }

        public void OnExit()
        {
        }

        public void Tick()
        {
        }
    }
}
