using System;
using CoinRush.Helpers;
using CoinRush.Enums;

namespace CoinRush.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        private GameState _gameState;

        public GameState GetGameState() => _gameState;
        public void SetGameState(GameState value)
        {
            if (_gameState == value) return;

            if (value == GameState.GameOver) UIManager.Instance.ShowGameOverPanel();
            else if (value == GameState.LevelCompleted) UIManager.Instance.ShowLevelComplatedPanel();
            _gameState = value;
            onGameStateChangedHandler(value);
        }

        public static Action<GameState> onGameStateChangedHandler;
    }
}
