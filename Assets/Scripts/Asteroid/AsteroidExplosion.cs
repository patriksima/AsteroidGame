using System.Collections;
using UnityEngine;

namespace Asteroid.Asteroid
{
    public class AsteroidExplosion : PoolItem
    {
        [SerializeField] private ParticleSystem particle;

        public void Play()
        {
            StartCoroutine(CoPlay());
        }

        private IEnumerator CoPlay()
        {
            particle.Play();
            yield return new WaitForSeconds(particle.main.duration + particle.main.startLifetime.constantMax);
            AsteroidExplosionPool.Instance.Put(this);
        }
    }
}