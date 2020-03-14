using UnityEngine;

namespace Asteroid
{
    [RequireComponent(typeof(AudioSource))]
    public class AsteroidHitAudio : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Play()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.transform.CompareTag("Missile"))
            {
                return;
            }

            Play();
        }
    }
}