using System;
using System.Collections;
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

        private void Update()
        {
            Debug.DrawRay(transform.position, _rigidbody.velocity * 10f, Color.green);
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
            model.gameObject.SetActive(true);
            _collider.enabled = true;
        }

        private void Death()
        {
            StartCoroutine(CoDeath());
        }

        private IEnumerator CoDeath()
        {
            ReturnToPool();
            yield return new WaitForSeconds(.1f);
            OnDestroyed?.Invoke();
        }

        private void ReturnToPool()
        {
            AsteroidSmallPool.Instance.Put(this);
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