using CoinRush.Abstracts;
using CoinRush.Helpers;
using CoinRush.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CoinRush.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header(" ELEMENTS ")]
        [SerializeField] PoolableObject coinPrefab;
        [SerializeField] Transform parent;
        
        private ObjectPool _coinPool;
        private List<PoolableObject> _collectedCoins = new List<PoolableObject>();

        private void Awake()
        {
            _coinPool = ObjectPool.CreateInstance(coinPrefab, 20, parent, false);
        }

        private void Start()
        {
            _coinPool = ObjectPool.CreateInstance(coinPrefab, 20, parent,false);
        }

        public void AddExtraCoin()
        {
            var collectedCoin = _coinPool.GetObjectFromPool();

            if (_collectedCoins.Count > 0)
            {
                var lastCollectedCoin = _collectedCoins.Last().transform;
                collectedCoin.SetPosition(lastCollectedCoin.position);
                collectedCoin.GetComponent<IFollow>().Follow(lastCollectedCoin);
            }
            else
            {
                collectedCoin.SetPosition(this.transform.position);
                collectedCoin.GetComponent<IFollow>().Follow(this.transform);
            }
            _collectedCoins.Add(collectedCoin);
            collectedCoin.AnimateObject();

        }
        public void AddExtraLife() => print("Added ExtraLife");
    }
}
