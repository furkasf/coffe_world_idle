﻿using GenericPoolSystem.PoolData;
using UnityEngine;

namespace GenericPoolSystem
{
    public class PoolController : MonoBehaviour
    {
        public PoolContainer PoolData;

        private ObjectPoolManager _poolManager;

        private void Awake()
        {
            GetPoolData();
            initializePool();
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            PoolSignals.onGetObjectFormPool += OnGetObjectFormPool;
            PoolSignals.onPutObjectBackToPool += OnPutObjectBackToPool;
            PoolSignals.onGetPoolCurrentSize += OnGetPoolCurrentSize;
            PoolSignals.onGetPoolIsDynamic += OnGetPoolIsDynamic;
        }

        private void UnSubscribe()
        {
            PoolSignals.onGetObjectFormPool -= OnGetObjectFormPool;
            PoolSignals.onPutObjectBackToPool -= OnPutObjectBackToPool;
            PoolSignals.onGetPoolCurrentSize -= OnGetPoolCurrentSize;
            PoolSignals.onGetPoolIsDynamic -= OnGetPoolIsDynamic;
        }

        private void OnDisable()
        {
            UnSubscribe();
        }



        private void GetPoolData() => PoolData = Resources.Load<PoolContainer>("PoolData/PoolContainer");

        private void initializePool()
        {
            _poolManager = new ObjectPoolManager();

            foreach (var pool in PoolData.Pools)
            {
                _poolManager.AddObjectPool(pool.PrefabFactory, pool.ActivatePrefab, pool.DeactivatePrefab, PutPoolObjectToHolder, pool.Key, pool.InitialSize, pool.IsExtensible);
            }
        }

        private void PutPoolObjectToHolder(GameObject gameObject) => gameObject.transform.parent = transform;

        private GameObject OnGetObjectFormPool(string poolKey)
        {
            return _poolManager.GetObject<GameObject>(poolKey);
        }

        private void OnPutObjectBackToPool(GameObject gameObject, string poolKey)
        {
            gameObject.transform.parent = transform;
            _poolManager.ReturnObject<GameObject>(gameObject, poolKey);
        }

        private int OnGetPoolCurrentSize(string poolKey)
        {
            return _poolManager.PoolCurrentSize(poolKey);
        }

        private bool OnGetPoolIsDynamic(string poolKey)
        {
            return _poolManager.PoolIsDynamic(poolKey);
        }
    }
}