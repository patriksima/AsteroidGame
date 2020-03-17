using UnityEngine;

namespace Asteroid
{
    public class PreferencesManager : Singleton<PreferencesManager>
    {
        [SerializeField] private AudioSource musicAudioSource;

        protected override void Awake()
        {
            base.Awake();
            if (PlayerPrefs.GetString("Music") == "Off")
            {
                musicAudioSource.mute = true;
            }
        }
    }
}