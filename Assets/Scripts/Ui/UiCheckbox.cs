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
        public event Action<bool> OnChange;

        [Description("Checkbox ON sprite")] [SerializeField]
        private Sprite sprite;

        private bool _state;
        private Image _image;
        private Sprite _origin;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _origin = _image.sprite;
            ToggleSprite();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _state = !_state;
            ToggleSprite();
        }

        private void ToggleSprite()
        {
            Assert.IsNotNull(_image);
            Assert.IsNotNull(_image.sprite);
            _image.sprite =
                (_state) ?
                    sprite :
                    _origin;
            OnChange?.Invoke(_state);
        }

        public void SetState(bool state)
        {
            _state = state;
            ToggleSprite();
        }
    }
}