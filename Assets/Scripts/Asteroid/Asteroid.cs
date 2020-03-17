using System;
using UnityEngine;
using Random = System.Random;

namespace Asteroid.Asteroid
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(HealthAbility))]
    public class Asteroid : PoolItem
    {
        private CapsuleCollider2D _collider;
        private HealthAbility _healthAbility;
        private Rigidbody2D _rigidbody;
        [SerializeField] private GameObject model;

        public static event Action OnDestroyed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _healthAbility = GetComponent<HealthAbility>();
            _collider = GetComponent<CapsuleCollider2D>();

            _healthAbility.OnDied += Death;
        }

        public override void OnPoolIn()
        {
            _healthAbility.ResetHealth();
            model.gameObject.SetActive(false);
            _collider.enabled = false;
        }

        public override void OnPoolOut()
        {
            _healthAbility.ResetHealth();
            Setup();
            model.gameObject.SetActive(true);
            _collider.enabled = true;
        }

        private void Setup()
        {
            var r = new Random();

            var x = (float) r.NextDouble() + .5f;
            var y = (float) r.NextDouble() + .5f;
            var f = (float) r.NextDouble() * 30f + 60f;
            var d1 = r.Next(0, 2) == 1 ? -1f : 1f;
            var d2 = r.Next(0, 2) == 1 ? -1f : 1f;

            var velocity = new Vector2(x * d1, y * d2);

            _rigidbody.velocity = velocity;
            _rigidbody.angularVelocity = 1f + (float) r.NextDouble() * 100f * d1;
        }

        private void Death(HealthAbility unused)
        {
            ReturnToPool();
            OnDestroyed?.Invoke();
        }

        private void ReturnToPool()
        {
            AsteroidPool.Instance.Put(this);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            var damageable = other.GetComponent<ITakeDamage>();
            damageable?.TakeDamage(1);
        }

        private void OnDestroy()
        {
            _healthAbility.OnDied -= Death;
        }
    }
}