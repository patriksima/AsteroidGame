using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Asteroid
{
    [RequireComponent(typeof(AudioSource))]
    public class UiCountdown : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMesh;

        private AudioSource _audioSource;

        private int _countdownTime = 3;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            StartCoroutine(Countdown());
        }

        private IEnumerator Countdown()
        {
            while (_countdownTime > 0)
            {
                _audioSource.Play();
                textMesh.text = _countdownTime.ToString();
                yield return new WaitForSeconds(1f);
                _countdownTime--;
            }

            _audioSource.Play();
            textMesh.text = "GO!";

            yield return new WaitForSeconds(1f);
            gameObject.SetActive(false);

            GameManager.Instance.GameStarts();
        }
    }
}