using UnityEngine;

namespace Asteroid
{
    public abstract class PoolItem : MonoBehaviour
    {
        public virtual void OnPoolOut()
        {
            gameObject.SetActive(true);
        }

        public virtual void OnPoolIn()
        {
            gameObject.SetActive(false);
        }
    }
}