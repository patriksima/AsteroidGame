using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroid
{
    public class GameManager : MonoBehaviour
    {
        private bool _paused = false;

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
                if (_paused)
                {
                    Time.timeScale = 0f;
                }
                else
                {
                    Time.timeScale = 1f;
                }
            }

            if (Input.GetKeyDown("return"))
            {
                Debug.Log("Reload");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}