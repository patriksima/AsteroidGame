using System;
using System.ComponentModel;
using UnityEngine;

namespace Asteroid.Ui
{
    public class UiMusicPreferences : MonoBehaviour
    {
        private UiCheckbox _checkbox;

        [Description("Music On/Off")] [SerializeField]
        private bool defaultMusicState;

        private bool _musicState;

        private void Awake()
        {
            _checkbox = GetComponent<UiCheckbox>();
            _checkbox.OnChange += ChangeMusicPreferences;

            var prefMusic = PlayerPrefs.GetString("Music");

            if (string.IsNullOrEmpty(prefMusic))
            {
                ChangeMusicPreferences(defaultMusicState);
            }
            else
            {
                _musicState = prefMusic == "On";
            }
        }

        private void Start()
        {
            _checkbox.SetState(_musicState);
        }

        private void ChangeMusicPreferences(bool state)
        {
            _musicState = state;
            PlayerPrefs.SetString("Music", _musicState ? "On" : "Off");
        }

        private void OnDestroy()
        {
            _checkbox.OnChange -= ChangeMusicPreferences;
        }
    }
}