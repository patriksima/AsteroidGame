using System.Collections;
using UnityEngine;

namespace Asteroid
{
    public class AsteroidHitExplosion : MonoBehaviour
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
            gameObject.SetActive(true);

            foreach (var particle in _particles)
            {
                particle.Play();
            }

            yield return new WaitForSeconds(.1f);

            gameObject.SetActive(false);
            AsteroidHitExplosionPool.Instance.Put(this);
        }
    }
}