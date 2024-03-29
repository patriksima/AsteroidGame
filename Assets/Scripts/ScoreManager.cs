﻿using Asteroid.Asteroid;
using UnityEngine;

namespace Asteroid
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        private int _currentScore;
        public int Highscore { get; private set; }


        protected override void Awake()
        {
            base.Awake();
            LoadHighScore();

            HealthAbility.OnDamage += UpdateScore;

            GameManager.OnGameOver += CheckHighscore;
            GameManager.OnGameWin += CheckHighscore;
        }

        private void LoadHighScore()
        {
            Highscore = PlayerPrefs.GetInt("Highscore");
        }

        public void SetAndSaveHighScore(int highscore)
        {
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();
        }

        private void UpdateScore(int damage)
        {
            _currentScore += damage;
        }

        private void CheckHighscore()
        {
            if (_currentScore > Highscore)
            {
                SetAndSaveHighScore(_currentScore);
            }
        }

        private void OnDestroy()
        {
            HealthAbility.OnDamage -= UpdateScore;

            GameManager.OnGameOver -= CheckHighscore;
            GameManager.OnGameWin -= CheckHighscore;
        }
    }
}