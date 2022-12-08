using CoinRush.ASyncs;
using CoinRush.Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CoinRush.Managers
{
    public class LevelManager : Singleton<LevelManager>
    {
        [Header(" ELEMENTS ")]
        [SerializeField] private ASyncLoader asyncLevelLoader;

        
        private void Awake()
        {
            CreateLevelData();
        }

        public void NextLevel()
        {
            var currentLevel = CurrentLevel();
            PlayerPrefs.SetInt("level", currentLevel + 1);
            asyncLevelLoader.LoadLevelASync(SceneManager.GetActiveScene().buildIndex);
        }
        public void RetryLevel() => asyncLevelLoader.LoadLevelASync(SceneManager.GetActiveScene().buildIndex);
        public int CurrentLevel() => PlayerPrefs.GetInt("level");
        private void CreateLevelData()
        {
            if (!PlayerPrefs.HasKey("level"))
                PlayerPrefs.SetInt(("level"), 1);
        }
    }
}
