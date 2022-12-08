using CoinRush.Abstracts;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CoinRush.Helpers
{
    public class ObjectPool
    {
        private ObjectPool _instance;
        private PoolableObject _objectPrefab;
        private Queue<PoolableObject> _pooledObjects;
        private Transform _poolParent;
        
        private int _poolSize;
        private bool _isPoolExpandable;

        private ObjectPool(PoolableObject prefab, int poolSize, Transform poolParent, bool isPoolExpandable)
        {
            _objectPrefab = prefab;
            _poolSize = poolSize;
            _poolParent = poolParent;
            _pooledObjects = new Queue<PoolableObject>();
            _isPoolExpandable = isPoolExpandable;
        }

        public static ObjectPool CreateInstance(PoolableObject prefab, int poolSize, Transform poolParent, bool isPoolExpandable)
        {
            ObjectPool objectPool = new ObjectPool(prefab, poolSize, poolParent, isPoolExpandable);
            objectPool.CreatePool(poolSize, poolParent);
            return objectPool;
        }

        private void CreatePool(int poolSize, Transform poolParent)
        {
            for (int i = 0; i < poolSize; i++)
            {
                var pooledObject = UnityEngine.Object.Instantiate(_objectPrefab, Vector3.zero, Quaternion.identity);
                pooledObject.transform.SetParent(poolParent, false);
                pooledObject.GetPoolInstance(this);
                pooledObject.gameObject.SetActive(false);
                _pooledObjects.Enqueue(pooledObject);
            }
        }

        public void ReturnObjectToPool(PoolableObject poolableObject)
        {
            _pooledObjects.Enqueue(poolableObject);
            poolableObject.gameObject.SetActive(false);
        }

        public PoolableObject GetObjectFromPool()
        {
            if (_pooledObjects.Count > 0)
            {
                var avaibleObject = AvaibleObjectInPool();
                return avaibleObject;
            }
            else if (_pooledObjects.Count == 0 && _isPoolExpandable)
            {
                CreatePool(_poolSize / 2, _poolParent);
                var avaibleObject = AvaibleObjectInPool();
                return avaibleObject;
            }
            return null;
        }

        private PoolableObject AvaibleObjectInPool()
        {
            var objectFromPool = _pooledObjects.Dequeue();
            objectFromPool.gameObject.SetActive(true);
            return objectFromPool;
        }
    }
}
