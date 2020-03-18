using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Asteroid.Asteroid
{
    public class AsteroidSpawner : MonoBehaviour
    {
        private Camera _camera;
        private Vector3 _screenBottomLeft;
        private Vector3 _screenTopRight;

        private void Awake()
        {
            _camera = Camera.main;
            Assert.IsNotNull(_camera);

            _screenTopRight = _camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            _screenBottomLeft = _camera.ScreenToWorldPoint(Vector3.zero);
        }

        public void Spawn(int count)
        {
            StartCoroutine(CoSpawn(count));
        }

        private IEnumerator CoSpawn(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var asteroid = AsteroidPool.Instance.Get();
                var rigidbody = asteroid.GetComponent<Rigidbody2D>();

                Vector3 pos;
                var side = Random.Range(0, 3);
                switch (side)
                {
                    case 0: //left
                        pos = new Vector3(_screenBottomLeft.x, Random.Range(_screenBottomLeft.y, _screenTopRight.y),
                            0f);
                        break;
                    case 1: //top
                        pos = new Vector3(Random.Range(_screenBottomLeft.x, _screenTopRight.x), _screenTopRight.y, 0f);
                        break;
                    case 2: //right
                        pos = new Vector3(_screenTopRight.x, Random.Range(_screenBottomLeft.y, _screenTopRight.y), 0f);
                        break;
                    case 3: //bottom
                        pos = new Vector3(Random.Range(_screenBottomLeft.x, _screenTopRight.x), _screenBottomLeft.y,
                            0f);
                        break;
                    default:
                        pos = Vector3.zero;
                        break;
                }

                asteroid.transform.position = pos;

                // Random scale
                var scale = 1f + Random.value * 1.3f;
                asteroid.transform.localScale = new Vector3(scale, scale, 0f);

                // rotation
                rigidbody.angularVelocity = Random.Range(-100f, 100f);

                var start = new Vector2(pos.x, pos.y);
                var end = Random.insideUnitCircle;
                var vec = (end - start).normalized;
                // direction
                rigidbody.velocity = vec;

                // Random wait to spawn another
                yield return new WaitForSeconds(1f + Random.value * 3f);
            }
        }
    }
}