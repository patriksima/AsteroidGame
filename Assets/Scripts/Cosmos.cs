using UnityEngine;

namespace Asteroid
{
    public class Cosmos : MonoBehaviour
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            var height = 2.0f * _camera.orthographicSize;
            var width = height * Screen.width / Screen.height;
            var scale = Mathf.Max(width, height);
            var localScale = new Vector3(scale / 10f, 1f, scale / 10f);

            transform.localScale = localScale;
        }
    }
}