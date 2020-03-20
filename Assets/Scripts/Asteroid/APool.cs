using System;
using UnityEngine;

namespace Asteroid.Asteroid
{
    public abstract class APool : MonoBehaviour
    {
        public abstract PoolItem Get();
        public abstract void Put(PoolItem item);
        public abstract Type GetItemType();
    }
}