using UnityEngine;
using UnityEngine.Assertions;

namespace Asteroid.Ui
{
    public class UiMusicPreferences : MonoBehaviour
    {
        private UiCheckbox _checkbox;
        private bool _musicState;

        private void Awake()
        {
            _checkbox = GetComponent<UiCheckbox>();
            Assert.IsNotNull(_checkbox);

            var prefMusic = PlayerPrefs.GetString("Music", "On");
            _musicState = prefMusic == "On";

            _checkbox.OnChange += ChangeMusicPreferences;
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