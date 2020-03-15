using UnityEngine;
using UnityEngine.EventSystems;

namespace Asteroid
{
    [RequireComponent(typeof(AudioSource))]
    public class ButtonHoverSound : MonoBehaviour, IPointerEnterHandler
    {
        private AudioSource _audioSource;

        public void OnPointerEnter(PointerEventData eventData)
        {
            _audioSource.Play();
        }

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
    }
}