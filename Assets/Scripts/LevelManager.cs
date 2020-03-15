using UnityEngine;

namespace Asteroid
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private int asteroidCount;
        [SerializeField] private AsteroidSpawner spawner;

        private int _asteroidDestroyed;

        private void Awake()
        {
            GameManager.OnGameStarts += LevelUp;
            Asteroid.OnDestroyed += CheckLevelCondition;
        }

        private void LevelUp()
        {
            spawner.Spawn(asteroidCount);
        }

        private void CheckLevelCondition()
        {
            _asteroidDestroyed++;
            Debug.Log($"Count: {asteroidCount}, Destroyed: {_asteroidDestroyed}");
            if (_asteroidDestroyed >= asteroidCount)
            {
                GameManager.Instance.GameWin();
            }
        }

        private void OnDestroy()
        {
            GameManager.OnGameStarts -= LevelUp;
            Asteroid.OnDestroyed -= CheckLevelCondition;
        }
    }
}