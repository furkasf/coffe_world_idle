using Assets.Scripts.Entitys;
using Assets.Scripts.Events;
using DG.Tweening;
using Assets.States;
using UnityEngine;

namespace Assets.Scripts.States.BaristaStates
{
    public class WaitOrderState : IState
    {
        private readonly Barista _barista;
        private float _timer;
        private float _checkTIme = 1.5f;

        private Vector3 _startPos;

        public WaitOrderState(Barista barista)
        {
            _barista = barista;
            _startPos = _barista.BaristaPos;
            _startPos = _barista.transform.position;
        }

        public void OnEnter()
        {
            if(_barista.BaristaNode != null)
            {
                _barista.BaristaNode.ResetNodes();
                _barista.BaristaNode = null;
            }
            //enter idle state
            _barista.IsCoffeeDelivered = false;
            _barista.transform.DOMove(_startPos, 1.45f);
        }

        public void OnExit()
        {
        }

        public void Tick()
        {
            if (_timer < _checkTIme)
            {
                _timer += Time.deltaTime;

                if (_timer > _checkTIme)
                {
                    Node shopNode = TradeEvent.OnGetAvailableCustomerAtShopNode();

                    if (shopNode != null)
                    {
                        _barista.BaristaNode = shopNode;
                    }
                    else
                    {
                        _timer = 0f;
                    }
                }
            }
        }
    }
}