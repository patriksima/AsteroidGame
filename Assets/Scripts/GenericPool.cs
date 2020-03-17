using System.Collections.Generic;
using UnityEngine;

namespace Asteroid
{
    public abstract class GenericPool<T> : MonoBehaviour where T : PoolItem
    {
        private readonly Queue<T> _components = new Queue<T>();
        protected int InitialCount;
        [SerializeField] private T prefab;

        public static GenericPool<T> Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            Setup();
        }

        protected virtual void Setup()
        {
            InitialCount = 100;
        }

        public T Get()
        {
            if (_components.Count == 0)
            {
                AddComponent(InitialCount);
            }

            var component = _components.Dequeue();
            component.OnPoolOut();

            return component;
        }

        public void Put(T component)
        {
            component.OnPoolIn();
            _components.Enqueue(component);
        }

        private void AddComponent(int count)
        {
            for (var i = 0; i < count; i++)
            {
                Put(Instantiate(prefab));
            }
        }
    }
}