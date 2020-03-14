﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Asteroid
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(HealthAbility))]
    public class Asteroid : MonoBehaviour
    {
        private HealthAbility _healthAbility;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _healthAbility = GetComponent<HealthAbility>();
            _healthAbility.OnDied += ability => { StartCoroutine(WaitForDeath()); };
        }

        private IEnumerator WaitForDeath()
        {
            yield return new WaitForSeconds(.1f);
            ReturnToPool();
        }

        private void Start()
        {
            Random r = new Random();

            var x = (float) r.NextDouble() + .5f;
            var y = (float) r.NextDouble() + .5f;
            var f = (float) r.NextDouble() * 30f + 60f;
            var d1 = (r.Next(0, 2) == 1) ? -1f : 1f;
            var d2 = (r.Next(0, 2) == 1) ? -1f : 1f;

            var velocity = new Vector2(x * d1, y * d2);

            _rigidbody.velocity = velocity;
            _rigidbody.angularVelocity = 1f + (float) r.NextDouble() * 100f * d1;
        }


        private void ReturnToPool()
        {
            AsteroidPool.Instance.Put(this);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                var damageable = other.GetComponent<ITakeDamage>();
                damageable?.TakeDamage(1);
            }
        }
    }
}