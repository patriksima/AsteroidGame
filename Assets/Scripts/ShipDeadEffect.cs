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
            StartCoroutine(CoPlay());
        }

        private IEnumerator CoPlay()
        {
            var explosion = AsteroidExplosionPool.Instance.Get();
            var main = explosion.main;
            var transform1 = explosion.transform;
            transform1.position = transform.position;
            transform1.rotation = transform.rotation;
            transform1.localScale = transform.localScale * .15f;
            explosion.gameObject.SetActive(true);
            explosion.Play();

            // wait until particle effect finish and return to pool
            yield return new WaitForSeconds(main.duration + main.startLifetime.constantMax);

            explosion.gameObject.SetActive(false);
            AsteroidExplosionPool.Instance.Put(explosion);
        }

        private void OnDestroy()
        {
            _shipHealth.OnDied -= Play;
        }
    }
}