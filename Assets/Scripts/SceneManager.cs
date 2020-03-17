using System.Collections;
using Asteroid.Ui;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroid
{
    public class SceneManager : Singleton<SceneManager>
    {
        [SerializeField] private UiCredits uiCredits;
        [SerializeField] private UiSettings uiSettings;

        private void Start()
        {
            Cursor.visible = true;
        }

        public void StartGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }

        public void Credits()
        {
            uiCredits.Show();
        }

        public void Settings()
        {
            uiSettings.Show();
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}