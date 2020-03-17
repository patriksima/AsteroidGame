using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Asteroid
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : Singleton<AudioManager>
    {
        private AudioSource _audioSource;

        protected override void Awake()
        {
            base.Awake();
            _audioSource = GetComponent<AudioSource>();
            Assert.IsNotNull(_audioSource);
        }

        public AudioSource AudioSource => _audioSource;
    }
}