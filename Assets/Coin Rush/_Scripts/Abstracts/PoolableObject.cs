using UnityEngine;
using CoinRush.Helpers;
using System.Collections.Generic;

namespace CoinRush.Abstracts
{
    public abstract class PoolableObject : MonoBehaviour
    {
        public abstract void GetPoolInstance(ObjectPool poolInstance);
        public abstract void ReturnObjectToPool();
        public abstract void SetPosition(Vector3 position);
        public virtual void OnSpawn() { }
        public virtual void AnimateObject() { }

    }
}
