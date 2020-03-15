using System.Collections;
using UnityEngine;

namespace Asteroid
{
    public class ShipDeadEffect : MonoBehaviour
    {
        private ShipHealth _shipHealth;

        private void Awake()
        {
            _shipHealth = GetComponent<ShipHealth>();
            _shipHealth.OnDied += Play;
        }

        private void Play()
        {
            var explosion = AsteroidExplosionPool.Instance.Get();
            var transform1 = explosion.transform;
            transform1.position = transform.position;
            transform1.rotation = transform.rotation;
            transform1.localScale = transform.localScale * .15f;
            explosion.Play();
        }

        private void OnDestroy()
        {
            _shipHealth.OnDied -= Play;
        }
    }
}