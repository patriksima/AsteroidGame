using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

namespace Asteroid.Asteroid
{
    public class AsteroidEuclideanTorus : MonoBehaviour
    {
        private Camera _camera;
        private Rect _screenBounds;

        private void Awake()
        {
            _camera = Camera.main;
            Assert.IsNotNull(_camera);

            var colliderSize = GetComponent<CapsuleCollider2D>().size;
            var screenTopRight = _camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            var screenBottomLeft = _camera.ScreenToWorldPoint(Vector3.zero);

            _screenBounds = Rect.MinMaxRect(screenBottomLeft.x - colliderSize.x, screenBottomLeft.y - colliderSize.y,
                screenTopRight.x + colliderSize.x,
                screenTopRight.y + colliderSize.y);
        }

        private void Start()
        {
            StartCoroutine(DoCheck());
        }

        private IEnumerator DoCheck()
        {
            while (true)
            {
                if (transform.position.x < _screenBounds.xMin)
                {
                    transform.position = new Vector3(_screenBounds.xMax, transform.position.y, transform.position.z);
                }

                if (transform.position.x > _screenBounds.xMax)
                {
                    transform.position = new Vector3(_screenBounds.xMin, transform.position.y, transform.position.z);
                }

                if (transform.position.y < _screenBounds.yMin)
                {
                    transform.position = new Vector3(transform.position.x, _screenBounds.yMax, transform.position.z);
                }

                if (transform.position.y > _screenBounds.yMax)
                {
                    transform.position = new Vector3(transform.position.x, _screenBounds.yMin, transform.position.z);
                }

                yield return new WaitForSeconds(.1f);
            }
        }
    }
}