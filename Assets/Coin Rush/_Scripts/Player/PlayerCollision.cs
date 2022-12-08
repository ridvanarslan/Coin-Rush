using UnityEngine;
using CoinRush.Managers;
using CoinRush.Abstracts;
using CoinRush.Enums;
using UnityEngine.Android;

namespace CoinRush.Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private PlayerController _player;

        private void Awake() => _player = GetComponent<PlayerController>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Bonus>(out var bonus))
            {
                bonus.GiveBonus(ref _player);
            }
            else if (other.CompareTag("Obstacle"))
            {
                GameManager.Instance.SetGameState(GameState.GameOver);
                //TODO: Use GetComponent<IObstacle> instead of ComporeTag
            }
            else if (other.CompareTag("FinishLine"))
            {
                GameManager.Instance.SetGameState(GameState.LevelCompleted);
            }
            else if (other.TryGetComponent<Stair>(out var stair))
            {
                //TODO: Make coins climb stairs
            }
        }
    }
}
