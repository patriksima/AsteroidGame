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

        private void Play(HealthAbility unused)
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
            _healthAbility.OnDied -= Play;
        }
    }
}