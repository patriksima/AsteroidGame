using System;
using UnityEngine;

namespace Asteroid
{
    public class ShipHealth : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private int initialHealth;

        public int CurrentHealth { get; private set; }

        public int InitialHealth => initialHealth;

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;

            if (CurrentHealth <= 0)
            {
                OnDied?.Invoke();
            }
        }

        public event Action OnDied;

        private void Awake()
        {
            CurrentHealth = initialHealth;
        }
    }
}