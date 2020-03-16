using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Asteroid
{
    public class ButtonClickSound : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private AudioClip clickSound;

        public void OnPointerClick(PointerEventData eventData)
        {
            AudioManager.Instance.AudioSource.PlayOneShot(clickSound);
        }
    }
}