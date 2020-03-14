using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(HealthAbility))]
    public class AsteroidDecay : MonoBehaviour
    {
        [SerializeField] private List<Sprite> sprites;
        private SpriteRenderer _spriteRenderer;
        private HealthAbility _healthAbility;
        private int _currentStage;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _healthAbility = GetComponent<HealthAbility>();
        }

        private void Update()
        {
            if (sprites.Count == 0 || _healthAbility.CurrentHealth <= 0)
            {
                return;
            }

            var stageSize = (float) _healthAbility.InitialHealth / sprites.Count;
            var newStage = (int) (sprites.Count - (_healthAbility.CurrentHealth / stageSize));

            if (_currentStage == newStage)
            {
                return;
            }

            _spriteRenderer.sprite = sprites[newStage];
            _currentStage = newStage;
        }
    }
}