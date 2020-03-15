using UnityEngine;

namespace Asteroid
{
    public class AsteroidHitVisual : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.transform.CompareTag("Missile"))
            {
                return;
            }

            foreach (var missileHit in other.contacts)
            {
                var hitPoint = missileHit.point;
                var explosion = AsteroidHitExplosionPool.Instance.Get();
                explosion.transform.position = new Vector3(hitPoint.x, hitPoint.y, 0);
                explosion.gameObject.SetActive(true);
                explosion.Play();
            }
        }
    }
}