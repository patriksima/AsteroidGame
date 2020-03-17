using UnityEngine;
using UnityEngine.EventSystems;

namespace Asteroid.Ui
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