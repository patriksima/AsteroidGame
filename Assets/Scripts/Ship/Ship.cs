using UnityEngine;

namespace Asteroid
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(ShipHealth))]
    public class Ship : MonoBehaviour
    {
        private BoxCollider2D _collider;
        private ShipHealth _shipHealth;
        [SerializeField] private GameObject shipModel;

        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();

            _shipHealth = GetComponent<ShipHealth>();
            _shipHealth.OnDied += Death;

            GameManager.OnGameStarts += ShowModel;
            GameManager.OnGameOver += HideModel;
            GameManager.OnGameWin += HideModel;
        }

        private void Death()
        {
            GameManager.Instance.GameOver();
        }

        private void ShowModel()
        {
            _collider.enabled = true;
            shipModel.SetActive(true);
        }

        private void HideModel()
        {
            _collider.enabled = false;
            shipModel.SetActive(false);
        }

        private void OnDestroy()
        {
            GameManager.OnGameStarts -= ShowModel;
            GameManager.OnGameOver -= HideModel;
            GameManager.OnGameWin -= HideModel;
            _shipHealth.OnDied -= Death;
        }
    }
}