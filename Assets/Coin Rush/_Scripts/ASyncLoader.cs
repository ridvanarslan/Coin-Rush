using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CoinRush.ASyncs
{
    public class ASyncLoader : MonoBehaviour
    {
        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private Slider loadingSlider;

        public void LoadLevelASync(int levelIndex)
        {
            mainMenu.SetActive(false);
            loadingScreen.SetActive(true);
            StartCoroutine(LoadASync(levelIndex));
        }

        private IEnumerator LoadASync(int levelIndex)
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelIndex);
            while (!loadOperation.isDone)
            {
                float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
                loadingSlider.value= progressValue;
                yield return null;
            }
        }

    }
}
