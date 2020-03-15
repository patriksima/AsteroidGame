using System;
using UnityEngine;


namespace Asteroid
{
    public class SceneManager : Singleton<SceneManager>
    {
        [SerializeField] private UiCredits credits;

        private void Start()
        {
            Cursor.visible = true;
        }

        public void StartGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        }

        public void Credits()
        {
            credits.Show();
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}