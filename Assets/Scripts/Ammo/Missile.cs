using UnityEngine;

namespace Asteroid.Ammo
{
    public class Missile : PoolItem
    {
        private const float Speed = 10f;
        private const float Lifetime = 5f;

        private float _lifeTimer;

        private void Update()
        {
            if (_lifeTimer > Lifetime)
            {
                ReturnToPool();
            }

            transform.Translate(Vector3.up * (Speed * Time.deltaTime));
            _lifeTimer += Time.deltaTime;
        }

        private void ReturnToPool()
        {
            MissilePool.Instance.Put(this);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Asteroid"))
            {
                var damageable = other.collider.GetComponent<ITakeDamage>();
                damageable?.TakeDamage(1);
                ReturnToPool();
            }
        }

        public override void OnPoolIn()
        {
            base.OnPoolIn();
            _lifeTimer = 0f;
        }
    }
}