using System.Collections;
using UnityEngine;

namespace Asteroid
{
    public class ShipExplosionAudio : MonoBehaviour
    {
        private AudioSource _audioSource;
        private HealthAbility _healthAbility;
        [SerializeField] private AudioClip audioClip;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _healthAbility = GetComponent<HealthAbility>();
            _healthAbility.OnDied += ability => { StartCoroutine(CoPlay()); };
        }

        private IEnumerator CoPlay()
        {
            _audioSource.PlayOneShot(audioClip);
            yield return new WaitForSeconds(audioClip.length);
        }
    }
}