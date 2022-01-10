using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProject2.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] float delayLevelTime = 1f;

        public static GameManager Instance { get; private set;}

        void Awake()
        {
            SingeltonThisGameObject();
        }

        private void SingeltonThisGameObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }


        public void LoadScene(int levelIndex = 0)
        {
            StartCoroutine(LoadSceneAsync(levelIndex));
        }

        private IEnumerator LoadSceneAsync(int levelIndex)
        {
            yield return new WaitForSeconds(delayLevelTime);
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + levelIndex);
        }

        public void LoadMenuScene()
        {
            StartCoroutine(LoadMenuSceneAsync());
        }

        private IEnumerator LoadMenuSceneAsync()
        {
            yield return new WaitForSeconds(delayLevelTime);
            yield return SceneManager.LoadSceneAsync("Menu");
        }

        public void ExitGame()
        {
            Debug.Log("Quit Game Triggered");
            Application.Quit();
        }
    }
}
