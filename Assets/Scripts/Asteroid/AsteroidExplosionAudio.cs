using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

namespace Asteroid.Asteroid
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(HealthAbility))]
    public class AsteroidExplosionAudio : MonoBehaviour
    {
        private AudioSource _audioSource;
        private HealthAbility _healthAbility;
        [SerializeField] private AudioClip audioClip;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            Assert.IsNotNull(_audioSource);
            _healthAbility = GetComponent<HealthAbility>();
            Assert.IsNotNull(_healthAbility);
            _healthAbility.OnDied += Play;
        }

        private void Play(HealthAbility unused)
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
            _healthAbility.OnDied -= Play;
        }
    }
}