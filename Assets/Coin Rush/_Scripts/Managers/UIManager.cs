using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CoinRush.Helpers;
using UnityEngine.UI;
using TMPro;
using System;
using CoinRush_Player;
using CoinRush.Enums;

namespace CoinRush.Managers
{
    public class UIManager : Singleton<UIManager>
    {

        [Header(" ELEMENTS ")]
        [SerializeField] private Slider progressBar;
        [SerializeField] private TextMeshProUGUI levelCompletedText;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI progBarCurrentLevelText;
        [SerializeField] private TextMeshProUGUI progBarNextLevelText;
        [SerializeField] private PlayerMovement player;
        [SerializeField] private Canvas panelCanvas;

        [Header("-> Panels")]
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject gamePanel;
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private GameObject levelComplatedPanel;
        [SerializeField] private GameObject gameOverPanel;

        List<GameObject> _panels = new List<GameObject>();
        private float _progress;
        private Transform _finishLine;


        private void Start()
        {
            _finishLine = ChunkManager.Instance.EndPosition();
            UpdateLevelText();
            PanelsOnCanvas();
        }

        private void LateUpdate()
        {
            UpdateProgressBar();
        }

        private void PanelsOnCanvas()
        {
            for (int i = 0; i < panelCanvas.transform.childCount; i++)
            {
                _panels.Add(panelCanvas.transform.GetChild(i).gameObject);
            }
        }
        public void PanelController(GameObject panel)
        {
            var activePanel = _panels.First(x => x.gameObject.activeInHierarchy);

            if (GameManager.Instance.GetGameState() == GameState.Paused && settingsPanel.activeInHierarchy)
            {
                activePanel.SetActive(false);
                _panels[2].SetActive(true);
            }
            else
            {
                activePanel.SetActive(false);
                panel.SetActive(true);
            }
        }

        public void PlayButtonPressed() => GameManager.Instance.SetGameState(GameState.Game);

        public void PauseButtonPressed() => GameManager.Instance.SetGameState(GameState.Paused);

        public void ResumeButtonPressed() => GameManager.Instance.SetGameState(GameState.Game);

        [ContextMenu("Reload Level")]
        public void RetryButtonPressed() => LevelManager.Instance.RetryLevel();

        public void NextLevelButtonPressed() => LevelManager.Instance.NextLevel();

        public void ShowGameOverPanel()
        {
            PanelController(gameOverPanel);
            int progress = Convert.ToInt32(_progress * 100);
            levelCompletedText.text = $"{progress}% \n COMPLETED!";
        }

        public void ShowLevelComplatedPanel() => PanelController(levelComplatedPanel);

        public void UpdateProgressBar()
        {
            _progress = player.transform.position.z / _finishLine.position.z;
            progressBar.value = _progress;
        }

        private void UpdateLevelText()
        {
            var currentLevel = LevelManager.Instance.CurrentLevel();
            levelText.text = $"LEVEL {currentLevel.ToString()}";
            progBarCurrentLevelText.text = currentLevel.ToString();
            progBarNextLevelText.text = (currentLevel + 1).ToString();
        }
    }
}

