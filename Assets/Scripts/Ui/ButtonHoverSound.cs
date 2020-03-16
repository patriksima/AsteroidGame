using UnityEngine;
using UnityEngine.EventSystems;

namespace Asteroid
{
    public class ButtonHoverSound : MonoBehaviour, IPointerEnterHandler
    {
        [SerializeField] private AudioClip hoverSound;

        public void OnPointerEnter(PointerEventData eventData)
        {
            AudioManager.Instance.AudioSource.PlayOneShot(hoverSound);
        }
    }
}