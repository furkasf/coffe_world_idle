using Assets.States;
using UnityEngine;

namespace Assets.Scripts.States.BaristaStates
{
    public class WaitOrderState : IState
    {
        private readonly Barista _barista;
        private Vector3 _startPos;

        public WaitOrderState(Barista barista)
        {
            _barista = barista;
            _startPos = _barista.BaristaPos;
        }

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