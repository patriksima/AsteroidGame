using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

namespace Asteroid.Ship
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(ShipHealth))]
    public class ShipExplosionAudio : MonoBehaviour
    {
        private AudioSource _audioSource;
        private ShipHealth _shipHealth;
        [SerializeField] private AudioClip audioClip;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            Assert.IsNotNull(_audioSource);
            _shipHealth = GetComponent<ShipHealth>();
            Assert.IsNotNull(_shipHealth);
            _shipHealth.OnDied += Play;
        }

        private void Play()
        {
            StartCoroutine(CoPlay());
        }

        private IEnumerator CoPlay()
        {
            _audioSource.PlayOneShot(audioClip);
            yield return new WaitForSeconds(audioClip.length);
        }

        private void OnDestroy()
        {
            _shipHealth.OnDied -= Play;
        }
    }
}