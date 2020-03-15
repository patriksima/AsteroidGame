using UnityEngine;

namespace Asteroid
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private int asteroidCount;
        [SerializeField] private AsteroidSpawner spawner;

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
            asteroidCount--;
            if (asteroidCount <= 0)
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