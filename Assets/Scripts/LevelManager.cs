using Asteroid.Asteroid;
using UnityEngine;

namespace Asteroid
{
    public class LevelManager : MonoBehaviour
    {
        private int _asteroidDestroyed;
        [SerializeField] private int asteroidCount;
        [SerializeField] private AsteroidSpawner spawner;

        private void Awake()
        {
            GameManager.OnGameStarts += LevelUp;
            Asteroid.Asteroid.OnDestroyed += CheckLevelCondition;
        }

        private void LevelUp()
        {
            spawner.Spawn(asteroidCount);
        }

        private void CheckLevelCondition()
        {
            _asteroidDestroyed++;
            if (_asteroidDestroyed >= asteroidCount)
            {
                GameManager.Instance.GameWin();
            }
        }

        private void OnDestroy()
        {
            GameManager.OnGameStarts -= LevelUp;
            Asteroid.Asteroid.OnDestroyed -= CheckLevelCondition;
        }
    }
}