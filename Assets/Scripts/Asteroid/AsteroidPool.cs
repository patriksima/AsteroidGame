using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Asteroid.Asteroid
{
    public class AsteroidPool : APool
    {
        
        private static readonly Random Rnd = new Random();
        private readonly Queue<PoolItem> _components = new Queue<PoolItem>();

        [Range(1, 100)] [SerializeField] private int initialCount = 10;

        [SerializeField] private List<PoolItem> prefabs;

        public static AsteroidPool Instance { get; private set; }

        public override PoolItem Get()
        {
            if (_components.Count == 0)
            {
                AddRandomComponent(initialCount);
            }

            var component = _components.Dequeue();
            component.OnPoolOut();

            return component;
        }

        public override void Put(PoolItem item)
        {
            item.OnPoolIn();
            _components.Enqueue(item);
        }

        public override Type GetItemType()
        {
            return prefabs.GetType().GetGenericArguments().Single();
        }
        
        private void Awake()
        {
            Instance = this;
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