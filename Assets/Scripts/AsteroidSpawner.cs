using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

namespace Asteroid
{
    public class AsteroidSpawner : MonoBehaviour
    {
        private Camera _camera;
        private Vector3 _screenBottomLeft;
        private Vector3 _screenTopRight;
        [SerializeField] private int count = 5;

        private void Awake()
        {
            _camera = Camera.main;
            Assert.IsNotNull(_camera);

            _screenTopRight = _camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            _screenBottomLeft = _camera.ScreenToWorldPoint(Vector3.zero);

            GameManager.OnGameStarts += Spawn;
        }

        private void Spawn()
        {
            StartCoroutine(CoSpawn());
        }

        private IEnumerator CoSpawn()
        {
            for (var i = 0; i < count; i++)
            {
                var asteroid = AsteroidPool.Instance.Get();
                asteroid.transform.position = new Vector3(_screenTopRight.x, _screenTopRight.y, 0f);

                var scale = .5f + Random.value * 1.2f;
                asteroid.transform.localScale = new Vector3(scale, scale, 0f);

                yield return new WaitForSeconds(Random.value * 3f);
            }
        }

        private void OnDestroy()
        {
            GameManager.OnGameStarts -= Spawn;
        }
    }
}