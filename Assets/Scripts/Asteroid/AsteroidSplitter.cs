using System;
using UnityEngine;

namespace Asteroid.Asteroid
{
    public class AsteroidSplitter : MonoBehaviour, ISplittable
    {
        private HealthAbility _healthAbility;


        [SerializeField] private ASpawner spawner;

        private void Awake()
        {
            _healthAbility = GetComponent<HealthAbility>();
            _healthAbility.OnDied += Split;
        }

        public void Split()
        {
            spawner.Spawn(item =>
            {
                item.transform.position = transform.position;
                item.transform.localScale = transform.localScale;
            });
            spawner.Spawn(item =>
            {
                item.transform.position = transform.position;
                item.transform.localScale = transform.localScale;
            });
        }

        private void OnDestroy()
        {
            _healthAbility.OnDied -= Split;
        }
    }
}