using System.Collections.Generic;
using UnityEngine;

namespace Asteroid
{
    public abstract class GenericPool<T> : MonoBehaviour where T : Component
    {
        private readonly Queue<T> _components = new Queue<T>();
        [SerializeField] private T prefab;

        public static GenericPool<T> Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public T Get()
        {
            if (_components.Count == 0)
            {
                AddComponent(1);
            }

            return _components.Dequeue();
        }

        public void Put(T component)
        {
            _components.Enqueue(component);
        }

        private void AddComponent(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var component = Instantiate(prefab);
                _components.Enqueue(component);
            }
        }
    }
}