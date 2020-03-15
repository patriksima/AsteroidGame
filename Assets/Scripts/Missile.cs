using UnityEngine;

namespace Asteroid
{
    public class Missile : MonoBehaviour
    {
        private const float Speed = 10f;
        private const float Lifetime = 5f;

        private float _lifeTimer;

        private void Awake()
        {
            gameObject.SetActive(true);
        }

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
            _lifeTimer = 0f;
            gameObject.SetActive(false);
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
    }
}