using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoinRush.Abstracts;
using CoinRush.Helpers;
using CoinRush.Managers;
using CoinRush.Interfaces;
using CoinRush.Enums;

namespace CoinRush.Obstacle
{
    [RequireComponent(typeof(Rigidbody))]
    public class Axe : PoolableObject, IObstacle
    {
        private enum AxeVelocityDirection { LeftToRight = 1, RightToLeft = -1 }

        [Header(" SETTINGS ")]
        [SerializeField] AxeVelocityDirection axeVelocityDirection;
        [SerializeField] float forceAmount;
        [SerializeField] float lifeTime = 2f;

        private ObjectPool _poolInstance;
        private Rigidbody _rb;
        private float _currentTime;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void OnDisable()
        {

            _rb.velocity = Vector3.zero;
            SetPosition(Vector3.zero);
        }

        private void Update()
        {
            if (GameManager.Instance.GetGameState() != GameState.Game) return;
            _currentTime += Time.deltaTime;
            if (_currentTime > lifeTime)
            {
                ReturnObjectToPool();
                _currentTime = 0f;
            }

        }

        public override void GetPoolInstance(ObjectPool poolInstance) => _poolInstance = poolInstance;

        public override void OnSpawn() => _rb.velocity = Vector3.right * (int)axeVelocityDirection * forceAmount;

        public override void ReturnObjectToPool() => _poolInstance.ReturnObjectToPool(this);

        public override void SetPosition(Vector3 position) => transform.localPosition = position;

        public void ObstacleHit() => GameManager.Instance.SetGameState(GameState.GameOver);
    }

}