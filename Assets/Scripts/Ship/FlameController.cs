using UnityEngine;

namespace Asteroid
{
    [RequireComponent(typeof(MoveController))]
    public class FlameController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem flame;

        private void Update()
        {
            if (MoveController.IsMoving && flame.isStopped)
            {
                flame.Play();
            }

            if (!MoveController.IsMoving && flame.isPlaying)
            {
                flame.Stop();
            }
        }
    }
}