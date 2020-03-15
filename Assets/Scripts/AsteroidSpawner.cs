using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

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

            GameManager.OnGameStarts += () => { StartCoroutine(Spawn()); };
        }

        private IEnumerator Spawn()
        {
            for (var i = 0; i < count; i++)
            {
                var asteroid = AsteroidPool.Instance.Get();
                asteroid.transform.position = new Vector3(_screenTopRight.x, _screenTopRight.y, 0f);
                //asteroid.transform.position = new Vector3(Random.Range(_screenBottomLeft.x - 2f, _screenTopRight.x + 2f),
                // _screenTopRight.y + 2f, 0f);
                var scale = .5f + Random.value * 1.2f;
                asteroid.transform.localScale = new Vector3(scale, scale, 0f);
                //asteroid.gameObject.SetActive(true);
                yield return new WaitForSeconds(Random.value * 3f);
            }
        }
    }
}