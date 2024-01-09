using Assets.Scripts.Events;
using Assets.States;
using coffee_world_idle.Assets.Scripts.Events;
using DG.Tweening;
using GenericPoolSystem;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.States.CustomerStates
{
    public class LeaveCoffeeState : IState
    {
        private readonly Customer _customer;
        private Transform _spawnPoint;
        private Sequence _mySequence;
        public LeaveCoffeeState(Customer customer)
        {
            _customer = customer;
        }


        public void OnEnter()
        {

            UnityEngine.Debug.Log("Customer Enter coffee leave state");
            _spawnPoint = _customer.SpawnPoint; 
            Transform customerTrans = _customer.transform;

            //call payments

            Vector3 lookDir = _spawnPoint.position - customerTrans.position;
            Quaternion lookRot = Quaternion.LookRotation(lookDir);

            _mySequence = DOTween.Sequence();
            _mySequence.Append(customerTrans.DORotateQuaternion(lookRot, 0.1f));
            _mySequence.Append(customerTrans.DOMove(_spawnPoint.position, 1.5f)); //get from scriptable
            _mySequence.Append(customerTrans.DORotate(new Vector3(0, 180, 0), 0.1f));

            _mySequence.OnComplete(() => ReturnBackSpawnPoint());
        }

        public void OnExit()
        {

        }

        public void Tick()
        {

        }
        private void ReturnBackSpawnPoint()
        {
            

            _customer.transform.DOMove(_customer.SpawnPoint.position, 1.5f) // get from scriptable
                .OnComplete(() =>
                {
                    PoolSignals.onPutObjectBackToPool(_customer.gameObject, "CustomerPool");
                    if (!TradeEvent.OnIsAllNodesFul())
                    {
                        SpawnEvent.OnSpawn();
                    }
                }
                );
        }
    }
}
