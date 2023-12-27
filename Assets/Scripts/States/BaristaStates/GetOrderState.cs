using Assets.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.States.BaristaStates
{
    public class GetOrderState: IState
    {

        private readonly Barista _barista;

        public GetOrderState(Barista barista)
        {
            _barista = barista;
        }

        public void OnEnter()
        {
            //exit from wait state
            //go customer
            //get order
            //exit from state
        }

        public void OnExit()
        {
        }

        public void Tick()
        {
        }
    }
}
