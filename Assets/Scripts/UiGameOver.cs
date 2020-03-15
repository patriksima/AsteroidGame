using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace Asteroid
{
    public class UiGameOver : MonoBehaviour
    {
        [SerializeField] private GameObject panel;

        private void Awake()
        {
            GameManager.OnGameOver += Show;
        }

        private void Show()
        {
            panel.gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            GameManager.OnGameOver -= Show;
        }
    }
}