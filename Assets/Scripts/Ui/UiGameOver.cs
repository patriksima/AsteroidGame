﻿using UnityEngine;

namespace Asteroid.Ui
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