using Assets.Scripts.Entitys;
using Assets.Scripts.Events;
using Assets.States;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.States.BaristaStates
{
    public class DelivareOrderState : IState
    {
        private readonly Barista _barista;
        private Vector3 _destination;
        private Transform _transform;
        private Sequence _mySequence;
        public DelivareOrderState(Barista barista)
        {
            _barista = barista;
            _transform = _barista.transform;
        }
        public void OnEnter()
        {
            UnityEngine.Debug.Log("Barista enter delivare order state");

            _barista.IsCoffeeDelivered = false;


            _mySequence = DOTween.Sequence();

            _destination = _barista.BaristaNode.BaristaWaypoint;

            Vector3 lookDir = _destination - _transform.position;
            Quaternion lookRot = Quaternion.LookRotation(lookDir);

            _mySequence.Append(_transform.DORotateQuaternion(lookRot, 0.1f));
            _mySequence.Append(_transform.DOMove(_destination, 1f));
            _mySequence.Append(_transform.DORotate(Vector3.forward, 0.1f));

            _mySequence.OnComplete(delegate
            {
                _barista.BaristaNode.Customer.DeliveryTaken();

                _barista.BaristaNode?.ResetNodes();
                _barista.BaristaNode = null;

                _barista.IsCoffeeDelivered = true;
            });
        }

        public void OnExit()
        {
        }

        public void Tick()
        {

        }
    }
}
