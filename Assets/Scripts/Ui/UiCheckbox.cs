using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Asteroid.Ui
{
    public class UiCheckbox : MonoBehaviour, IPointerClickHandler
    {
        private Image _image;
        private Sprite _origin;

        private bool _state;

        [Description("Checkbox ON sprite")] [SerializeField]
        private Sprite sprite;

        public void OnPointerClick(PointerEventData eventData)
        {
            _state = !_state;
            ToggleSprite();
        }

        public event Action<bool> OnChange;

        private void Awake()
        {
            _image = GetComponent<Image>();
            Assert.IsNotNull(_image);
            _origin = _image.sprite;
        }

        private void ToggleSprite()
        {
            _image.sprite = _state ? sprite : _origin;
            OnChange?.Invoke(_state);
        }

        public void SetState(bool state)
        {
            _state = state;
            ToggleSprite();
        }
    }
}