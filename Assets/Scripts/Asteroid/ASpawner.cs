using System;
using UnityEngine;

namespace Asteroid.Asteroid
{
    public abstract class ASpawner : MonoBehaviour
    {
        public abstract void Spawn(Action<PoolItem> item);
    }
}