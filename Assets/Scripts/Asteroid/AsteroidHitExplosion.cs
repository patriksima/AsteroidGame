using System.Collections;
using UnityEngine;

namespace Asteroid
{
    public class AsteroidHitExplosion : PoolItem
    {
        private ParticleSystem[] _particles;

        private void Awake()
        {
            _particles = GetComponentsInChildren<ParticleSystem>();
        }

        public void Play()
        {
            StartCoroutine(CoPlay());
        }

        private IEnumerator CoPlay()
        {
            foreach (var particle in _particles)
            {
                particle.Play();
            }

            yield return new WaitForSeconds(.1f);

            AsteroidHitExplosionPool.Instance.Put(this);
        }
    }
}