using System;
using UnityEngine;

namespace Asteroid
{
    public class HealthAbility : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private int initialHealth;

        public int CurrentHealth { get; private set; }

        public int InitialHealth => initialHealth;

        public event Action<HealthAbility> OnDied;

        private void Awake()
        {
            CurrentHealth = initialHealth;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;

            if (CurrentHealth <= 0)
            {
                OnDied?.Invoke(this);
            }
        }
    }
}