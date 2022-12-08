using CoinRush.Abstracts;
using CoinRush.Helpers;
using CoinRush.Interfaces;
using UnityEngine;

namespace CoinRush.Player
{
    public class Coin : PoolableObject, IFollow
    {
        [Header(" SETTINGS ")]
        [SerializeField] private float followSpeed;
        [SerializeField] private Vector3 followOffset;

        private CoinAnimationController _coinAnim;
        private ObjectPool _objectPool;
        private Transform _followingTarget;
        private bool _canFollow;

        private void Awake()
        {
            _coinAnim = GetComponent<CoinAnimationController>();
        }
        private void FixedUpdate()
        {
            if (_canFollow)
            {
                transform.position = Vector3.Slerp(transform.position, _followingTarget.position + followOffset, followSpeed * Time.deltaTime);
                transform.LookAt(Vector3.up * _followingTarget.rotation.y);
            }

        }
        public override void GetPoolInstance(ObjectPool poolInstance) => _objectPool = poolInstance;
        public override void ReturnObjectToPool() => _objectPool.ReturnObjectToPool(this);
        public override void SetPosition(Vector3 position) => transform.position = new Vector3(position.x, position.y, position.z - .2f);
        [ContextMenu("Collect Anim")]
        public override void AnimateObject() => _coinAnim.CollectAnimation();
        public void Follow(Transform followTarget)
        {
            _followingTarget = followTarget;
            _canFollow = true;
        }

    }

}

