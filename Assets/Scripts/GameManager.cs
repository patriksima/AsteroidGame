using System;
using System.Collections;
using UnityEngine;

namespace Asteroid
{
    public class GameManager : MonoBehaviour
    {
        private bool _paused;
        public static GameManager Instance { get; private set; }
        public static event Action OnGameStarts;
        public static event Action OnGameOver;
        public static event Action OnGameWin;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Cursor.visible = false;
        }

        private void Update()
        {
            if (Input.GetKey("escape"))
            {
                Quit();
            }
/*
            if (Input.GetKeyDown("space"))
            {
                _paused = !_paused;
                Time.timeScale = _paused ? 0f : 1f;
            }

            if (Input.GetKeyDown("return"))
            {
                ReloadGame();
            }
*/
        }

        public void Quit()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
        }

        private void ReloadGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene()
                .name);
        }

        public void GameStarts()
        {
            OnGameStarts?.Invoke();
        }

        public void GameOver()
        {
            OnGameOver?.Invoke();
            StartCoroutine(LoadMenu());
        }

        public void GameWin()
        {
            OnGameWin?.Invoke();
            StartCoroutine(LoadMenu());
        }

        private IEnumerator LoadMenu()
        {
            yield return new WaitUntil(() => Input.GetKeyDown("space"));
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
        }
    }
}