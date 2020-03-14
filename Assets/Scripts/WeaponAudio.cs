using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid
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