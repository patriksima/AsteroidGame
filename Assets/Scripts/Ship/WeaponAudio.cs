using UnityEngine;

namespace Asteroid.Ship
{
    public class WeaponAudio : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void Play()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }
}