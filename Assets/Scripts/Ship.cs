using System;
using UnityEngine;

namespace Asteroid
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(HealthAbility))]
    public class Ship : MonoBehaviour
    {
        private BoxCollider2D _collider;
        private HealthAbility _healthAbility;
        [SerializeField] private GameObject shipModel;

        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();

            _healthAbility = GetComponent<HealthAbility>();
            _healthAbility.OnDied += ability => { GameManager.Instance.GameOver(); };

            GameManager.OnGameStarts += ShowModel;
            GameManager.OnGameOver += HideModel;
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
        }
    }
}