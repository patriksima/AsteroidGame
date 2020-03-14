using System.Collections;
using UnityEngine;

namespace Asteroid
{
    public class ShipDeadEffect : MonoBehaviour
    {
        private HealthAbility _healthAbility;

        private void Awake()
        {
            _healthAbility = GetComponent<HealthAbility>();
            _healthAbility.OnDied += ability => { StartCoroutine(Play()); };
        }

        private IEnumerator Play()
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
            AsteroidExplosionPool.Instance.Put(explosion);
        }
    }
}