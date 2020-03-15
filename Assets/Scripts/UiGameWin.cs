using UnityEngine;

namespace Asteroid
{
    public class UiGameWin : MonoBehaviour
    {
        [SerializeField] private GameObject panel;

        private void Awake()
        {
            GameManager.OnGameWin += Show;
        }

        private void Show()
        {
            panel.gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            GameManager.OnGameWin -= Show;
        }
    }
}