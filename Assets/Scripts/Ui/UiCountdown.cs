﻿using System.Collections;
using TMPro;
using UnityEngine;

namespace Asteroid.Ui
{
    [RequireComponent(typeof(AudioSource))]
    public class UiCountdown : MonoBehaviour
    {
        private AudioSource _audioSource;

        private int _countdownTime = 3;
        [SerializeField] private TextMeshProUGUI textMesh;

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
            gameObject.SetActive(true);

            _audioSource.Play();
            textMesh.text = "Get ready";
            yield return new WaitForSeconds(2f);

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