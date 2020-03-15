using System;
using UnityEngine;

namespace Asteroid
{
    public class HealthAbility : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private int initialHealth;

        public int CurrentHealth { get; private set; }

        public int InitialHealth => initialHealth;

        public void ResetHealth()
        {
            CurrentHealth = initialHealth;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;

            OnDamage?.Invoke(damage);

            if (CurrentHealth <= 0)
            {
                OnDied?.Invoke(this);
            }
        }

        public event Action<HealthAbility> OnDied;

        public static event Action<int> OnDamage;

        private void Awake()
        {
            ResetHealth();
        }
    }
}