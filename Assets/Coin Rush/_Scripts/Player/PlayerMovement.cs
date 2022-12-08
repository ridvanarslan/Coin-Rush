using CoinRush.Enums;
using CoinRush.Managers;
using UnityEngine;

namespace CoinRush_Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header(" SETTINGS ")]
        [SerializeField] private float forwardSpeed;
        [SerializeField] private float turnSpeed;

        private float _mouseX;
        private bool _canMove;

        private void OnEnable() => GameManager.onGameStateChangedHandler += GameStateChangedCallback;
        private void OnDisable() => GameManager.onGameStateChangedHandler -= GameStateChangedCallback;

        private void FixedUpdate()
        {
            if (!_canMove) return;         
            
            MoveForward();

            if (Input.GetMouseButton(0))
                SideMoves();

        }
        private void MoveForward() => transform.Translate(Vector3.forward * forwardSpeed * Time.fixedDeltaTime);
        private void SideMoves()
        {
            _mouseX += Input.GetAxis("Mouse X") * turnSpeed;
            _mouseX = Mathf.Clamp(_mouseX, -90, 90);

            var targetRotation = Quaternion.Euler(Vector3.up * _mouseX);
            transform.rotation = targetRotation;
        }
        private void GameStateChangedCallback(GameState gameState) => _canMove = gameState == GameState.Game;
    }
}

