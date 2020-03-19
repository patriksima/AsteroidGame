using UnityEngine;

namespace Asteroid.Asteroid
{
    public class AsteroidDeadEffect : MonoBehaviour
    {
        private HealthAbility _healthAbility;

        private void Awake()
        {
            _healthAbility = GetComponent<HealthAbility>();
            _healthAbility.OnDied += Play;
        }

        private void Play()
        {
            var explosion = AsteroidExplosionPool.Instance.Get();
            explosion.transform.position = transform.position;
            explosion.transform.rotation = transform.rotation;
            // grow parent size doesnt work
            explosion.GetComponentInChildren<ParticleSystem>().transform.localScale *= transform.localScale.x;
            explosion.Play();
        }

        private void OnDestroy()
        {
            _healthAbility.OnDied -= Play;
        }
    }
}