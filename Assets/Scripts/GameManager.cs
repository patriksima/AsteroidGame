using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroid
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public static event Action OnGameStarts;
        public static event Action OnGameOver;

        private bool _paused;

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
                Application.Quit();
            }

            if (Input.GetKeyDown("space"))
            {
                _paused = !_paused;
                Time.timeScale = _paused ? 0f : 1f;
            }

            if (Input.GetKeyDown("return"))
            {
                ReloadGame();
            }
        }

        private void ReloadGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void GameStarts()
        {
            OnGameStarts?.Invoke();
        }

        public void GameOver()
        {
            OnGameOver?.Invoke();
        }
    }
}