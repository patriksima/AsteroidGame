using System;
using System.Collections;
using Asteroid.Asteroid;
using UnityEngine;

namespace Asteroid
{
    public class LevelManager : MonoBehaviour
    {
        public static event Action<int> OnLevelUp;

        private int _asteroidDestroyed;
        private int _asteroidSpawned;
        private int _level;

        [SerializeField] private AsteroidSpawner spawner;

        [SerializeField] private int initialAsteroidCount = 10;

        private void Awake()
        {
            GameManager.OnGameStarts += LevelUp;
            Asteroid.Asteroid.OnDestroyed += CheckLevelCondition;
            AsteroidSmallSpawner.OnSpawn += RaiseCount;
        }

        private void RaiseCount()
        {
            _asteroidSpawned++;
        }

        private void LevelUp()
        {
            OnLevelUp?.Invoke(_level);
            StartCoroutine(CoLevelUp());
        }

        private IEnumerator CoLevelUp()
        {
            _asteroidDestroyed = 0;
            _asteroidSpawned = initialAsteroidCount + _level;
            yield return new WaitForSeconds(2f);

            spawner.Spawn(_level, _asteroidSpawned);
            _level++;
        }

        private void CheckLevelCondition()
        {
            _asteroidDestroyed++;
            if (_asteroidDestroyed >= _asteroidSpawned)
            {
                LevelUp();
            }
        }

        private void OnDestroy()
        {
            GameManager.OnGameStarts -= LevelUp;
            Asteroid.Asteroid.OnDestroyed -= CheckLevelCondition;
            AsteroidSmallSpawner.OnSpawn -= RaiseCount;
        }
    }
}