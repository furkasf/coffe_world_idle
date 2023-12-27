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
        private readonly Barista _barista;

        public DelivareOrderState(Barista barista)
        {
            _barista = barista;
        }
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
