using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

namespace Asteroid.Asteroid
{
    public class AsteroidSpawner : MonoBehaviour
    {
        private Vector2 _bounds;

        private Camera _camera;

        private int _level;

        [MinMaxSlider(-300f, 300f)] [SerializeField]
        private MinMax angularVelocity = new MinMax(-100f, 100f);

        [MinMaxSlider(.1f, 10f)] [SerializeField]
        private MinMax scale = new MinMax(1.5f, 2f);

        [MinMaxSlider(.1f, 10f)] [SerializeField]
        private MinMax spawnInterval = new MinMax(1f, 5f);

        public static AsteroidSpawner Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }

            Instance = this;

            _camera = Camera.main;
            Assert.IsNotNull(_camera);
            SetBounds();
        }

        private void SetBounds()
        {
            var bl = _camera.ScreenToWorldPoint(Vector3.zero);

            _bounds.x = -bl.x;
            _bounds.y = -bl.y;
        }

        public void Spawn(int level, int count)
        {
            _level = level;
            StartCoroutine(CoSpawn(count));
        }

        private IEnumerator CoSpawn(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var asteroid = AsteroidPool.Instance.Get();
                var rb = asteroid.GetComponent<Rigidbody2D>();

                SetPosition(asteroid);
                SetScale(asteroid);
                SetRotation(rb);
                SetVelocity(rb, asteroid.transform.position);

                yield return new WaitForSeconds(spawnInterval.RandomValue);
            }
        }

        private void SetVelocity(Rigidbody2D rb, Vector3 position)
        {
            var start = new Vector2(position.x, position.y);
            var end = Random.insideUnitCircle;
            var vec = (end - start).normalized;

            rb.velocity = vec * (1 + ((1 + _level) * .1f));
        }

        private void SetRotation(Rigidbody2D rb)
        {
            rb.angularVelocity = angularVelocity.RandomValue;
        }

        private void SetScale(PoolItem poolItem)
        {
            var localScale = scale.RandomValue;
            poolItem.transform.localScale = new Vector3(localScale, localScale, 0f);
        }

        private void SetPosition(PoolItem poolItem)
        {
            Vector3 pos;

            switch (Random.Range(0, 4))
            {
                case 0: //left
                    pos = new Vector3(-_bounds.x, Random.Range(-_bounds.y, _bounds.y), 0f);
                    break;
                case 1: //top
                    pos = new Vector3(Random.Range(-_bounds.x, _bounds.x), _bounds.y, 0f);
                    break;
                case 2: //right
                    pos = new Vector3(_bounds.x, Random.Range(-_bounds.y, _bounds.y), 0f);
                    break;
                case 3: //bottom
                    pos = new Vector3(Random.Range(-_bounds.x, _bounds.x), -_bounds.y, 0f);
                    break;
                default:
                    pos = Vector3.zero;
                    break;
            }

            poolItem.transform.position = pos;
        }
    }
}