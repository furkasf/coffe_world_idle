using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.States;
using System.Threading.Tasks;

namespace Assets.Scripts.States.BaristaStates
{
    public class WaitOrderState : IState
    {
        public void OnEnter()
        {
            //reset delivery state
            //enter idle state
        }

        public void OnExit()
        {
        }

        public void Tick()
        {
            //cheach order is given by custuer
        }
    }
}
