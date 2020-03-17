using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid
{
    public class PreferencesManager : Singleton<PreferencesManager>
    {
        [SerializeField] private AudioSource musicAudioSource;

        private void Awake()
        {
            if (PlayerPrefs.GetString("Music") == "Off")
            {
                musicAudioSource.mute = true;
            }
        }
    }
}