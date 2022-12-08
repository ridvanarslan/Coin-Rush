using CoinRush.Enums;
using CoinRush.Interfaces;
using CoinRush.Managers;
using UnityEngine;

namespace CoinRush.Obstacle
{
    public class Door : MonoBehaviour, IObstacle
    {
        public void ObstacleHit() => GameManager.Instance.SetGameState(GameState.GameOver);

    }
}
