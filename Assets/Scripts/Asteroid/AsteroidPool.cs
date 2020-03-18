using System.Collections.Generic;
using UnityEngine;

namespace Asteroid.Asteroid
{
    public class AsteroidPool : MonoBehaviour
    {
        private readonly Queue<PoolItem> _components = new Queue<PoolItem>();
        private const int InitialCount = 10;
        private static readonly System.Random Rnd = new System.Random();

        [SerializeField] private List<PoolItem> prefabs;

        public static AsteroidPool Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public PoolItem Get()
        {
            if (_components.Count == 0)
            {
                AddRandomComponent(InitialCount);
            }

            var component = _components.Dequeue();
            component.OnPoolOut();

            return component;
        }

        public void Put(PoolItem component)
        {
            component.OnPoolIn();
            _components.Enqueue(component);
        }

        private void AddRandomComponent(int count)
        {
            for (var i = 0; i < count; i++)
            {
                Put(Instantiate(prefabs[Rnd.Next(prefabs.Count)]));
            }
        }
    }
}