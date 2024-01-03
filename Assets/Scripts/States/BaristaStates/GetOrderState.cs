using Assets.States;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.States.BaristaStates
{
    public class GetOrderState : IState
    {

        private readonly Barista _barista;
        private readonly SpriteRenderer _spriteRenderer;
        private Transform _baristaTrans;
        private Transform _customerTrans;
        private Vector3 _destination;
        private Sequence _mySequence;
        public GetOrderState(Barista barista, SpriteRenderer spriteRenderer)
        {
            _barista = barista;
            _spriteRenderer = spriteRenderer;
        }

        public void OnEnter()
        {
            _mySequence = DOTween.Sequence();

            //go customer
            _baristaTrans = _barista.transform;
            _customerTrans = _barista.BaristaNode.Customer.transform;
            _destination = _barista.BaristaNode.BaristaWaypoint;

            Vector3 lookDir = _customerTrans.position - _baristaTrans.position;
            Quaternion lookRot = Quaternion.LookRotation(lookDir);
            float upgradeTime = 1.5f; //Get it From event


            _mySequence.Append(_barista.transform.DORotateQuaternion(lookRot, 0.1f));
            _mySequence.Append(_barista.transform.DOMove(_destination, 1f));
            _mySequence.Append(_barista.transform.DORotate(new Vector3(0, 90, 0f), 0.1f));
            _mySequence.OnComplete(() =>
            {
                _spriteRenderer.gameObject.SetActive(true);
                _spriteRenderer.material.DOFloat(360, "_Arc1", upgradeTime)
                .OnComplete(() => _barista.IsOrdertaken = true);
            });
           
        }

        public void OnExit()
        {
            _spriteRenderer.material.SetFloat("_Arc1", 0);
            _spriteRenderer.gameObject.SetActive(false);
        }

        public void Tick()
        {
        }
    }
}
