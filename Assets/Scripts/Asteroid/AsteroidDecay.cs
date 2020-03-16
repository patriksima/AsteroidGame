using System.Collections.Generic;
using UnityEngine;

namespace Asteroid
{
    [RequireComponent(typeof(HealthAbility))]
    public class AsteroidDecay : MonoBehaviour
    {
        private int _currentStage;
        private HealthAbility _healthAbility;

        private SpriteRenderer _spriteRenderer;
        [SerializeField] private GameObject model;
        [SerializeField] private List<Sprite> sprites;

        private void Awake()
        {
            _spriteRenderer = model.GetComponent<SpriteRenderer>();
            _healthAbility = GetComponent<HealthAbility>();
        }

        private void Update()
        {
            if (sprites.Count == 0 || _healthAbility.CurrentHealth <= 0)
            {
                return;
            }

            var stageSize = (float) _healthAbility.InitialHealth / sprites.Count;
            var newStage = (int) (sprites.Count - _healthAbility.CurrentHealth / stageSize);

            if (_currentStage == newStage)
            {
                return;
            }

            _spriteRenderer.sprite = sprites[newStage];
            _currentStage = newStage;
        }
    }
}