using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroid.Asteroid
{
    public class AsteroidSmallSpawner : ASpawner
    {
        public static event Action OnSpawn;
        
        [SerializeField] private APool pool;

        [MinMaxSlider(-300f, 300f)] [SerializeField]
        private MinMax angularVelocity = new MinMax(-100f, 100f);

        public override void Spawn(Action<PoolItem> item)
        {
            var asteroid = pool.Get();
            var rb = asteroid.GetComponent<Rigidbody2D>();
            SetRotation(rb);
            SetVelocity(rb, asteroid.transform.position);
            item?.Invoke(asteroid);
            OnSpawn?.Invoke();
        }

        private void SetVelocity(Rigidbody2D rb, Vector3 position)
        {
            var start = new Vector2(position.x, position.y);
            var end = Random.insideUnitCircle;
            var vec = (end - start).normalized;

            rb.velocity = vec;
        }

        private void SetRotation(Rigidbody2D rb)
        {
            rb.angularVelocity = angularVelocity.RandomValue;
        }
    }
}