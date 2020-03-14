using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid
{
    public abstract class GenericPool<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private T prefab;

        public static GenericPool<T> Instance { get; private set; }

        private readonly Queue<T> _components = new Queue<T>();

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
            component.gameObject.SetActive(false);
            _components.Enqueue(component);
        }

        private void AddComponent(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var component = Instantiate(prefab);
                component.gameObject.SetActive(false);
                _components.Enqueue(component);
            }
        }
    }
}