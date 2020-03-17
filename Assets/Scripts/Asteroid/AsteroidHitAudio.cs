using System.Collections;
using UnityEngine;

namespace Asteroid.Asteroid
{
    [RequireComponent(typeof(AudioSource))]
    public class AsteroidHitAudio : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private IEnumerator CoPlay()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            yield return new WaitForSeconds(_audioSource.clip.length);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.transform.CompareTag("Missile"))
            {
                return;
            }

            StartCoroutine(CoPlay());
        }
    }
}