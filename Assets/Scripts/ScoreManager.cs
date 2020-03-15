using UnityEngine;

namespace Asteroid
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        private int _currentScore;
        public int Highscore { get; private set; }

        private void Awake()
        {
            LoadHighScore();

            HealthAbility.OnDamage += UpdateScore;

            GameManager.OnGameStarts += LoadHighScore;
            GameManager.OnGameOver += CheckHighscore;
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
            GameManager.OnGameStarts -= LoadHighScore;
            GameManager.OnGameOver -= CheckHighscore;
        }
    }
}