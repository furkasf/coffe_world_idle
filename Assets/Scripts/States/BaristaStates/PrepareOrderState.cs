using Assets.States;
using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.States.BaristaStates
{
    public class PrepareOrderState : IState
    {
        private readonly Barista _barista;
        private readonly SpriteRenderer _spriteRenderer;

        private Vector3 _destination;
        private Transform _transform;
        private Sequence _mySequence;

        public PrepareOrderState(Barista barista, SpriteRenderer spriteRenderer)
        {
            _barista = barista;
            _spriteRenderer = spriteRenderer;
        }
        public void OnEnter()
        {
            //exit from get order state 
            _barista.IsOrdertaken = false;

            // go to coffee machine
            //praper order 
            //enter delivery state

            _destination = _barista.CoffeMachineTrans.position;

            _spriteRenderer.gameObject.SetActive(true);

            float upgradeTime = 1.5f; // get from event

            _mySequence = DOTween.Sequence();

            Vector3 lookDir = _destination - _transform.position;
            Quaternion lookRot = Quaternion.LookRotation(lookDir);
            Vector3 standLookDir;

            _mySequence.Append(_transform.DORotateQuaternion(lookRot, 0.1f));
            _mySequence.Append(_transform.DOMove(_destination, 1f));
            _mySequence.AppendCallback(delegate
            {
                standLookDir = _destination - _transform.position;
                lookRot = Quaternion.LookRotation(standLookDir);
            });
            _mySequence.Append(_transform.DORotate(new Vector3(0, 180, 0), 0.1f));
            _mySequence.OnComplete(() =>
            {
                _spriteRenderer.material.DOFloat(360, "_Arc1", upgradeTime)
                .OnComplete(() =>
                {
                    _spriteRenderer.gameObject.SetActive(true);
                    _barista.IsCoffeePrepared = true;
                });
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
