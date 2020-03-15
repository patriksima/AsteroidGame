using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Asteroid
{
    [RequireComponent(typeof(AudioSource))]
    public class ButtonHoverSound : MonoBehaviour, IPointerEnterHandler
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _audioSource.Play();
        }
    }
}