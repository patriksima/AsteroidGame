using System;
using UnityEngine;

namespace Asteroid.Ship
{
    public class ShipLevelSize : MonoBehaviour
    {
        private void Awake()
        {
            LevelManager.OnLevelUp += Grows;
        }

        private void Grows(int level)
        {
            var scale = 1 + (1 + level) * .1f;
            transform.localScale = new Vector3(scale, scale, 0f);
        }

        private void OnDestroy()
        {
            LevelManager.OnLevelUp -= Grows;
        }
    }
}