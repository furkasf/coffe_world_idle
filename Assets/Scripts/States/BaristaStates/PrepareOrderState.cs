using Assets.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.States.BaristaStates
{
    public class PrepareOrderState : IState
    {
        private readonly Barista _barista;

        public PrepareOrderState(Barista barista)
        {
            _barista = barista;
        }
        public void OnEnter()
        {
            //exit from get order state 
            // go to coffee machine
            //praper order 
            //enter delivery state
        }

        public void OnExit()
        {
        }

        public void Tick()
        {
        }
    }
}
