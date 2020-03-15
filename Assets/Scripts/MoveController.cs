using UnityEngine;

namespace Asteroid
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MoveController : MonoBehaviour
    {
        private const float RotationSpeed = 90.0f;
        private const float ThrustForce = .9f;

        private Rigidbody2D _rigidbody;
        public static bool IsMoving { get; private set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");

            IsMoving = !(Mathf.Approximately(v, 0f) && Mathf.Approximately(h, 0f));

            // Rotate the ship if necessary
            transform.Rotate(0, 0, -h * RotationSpeed * Time.fixedDeltaTime);

            // Thrust the ship if necessary
            // ReSharper disable once Unity.InefficientPropertyAccess
            _rigidbody.AddForce(transform.up * (ThrustForce * v), ForceMode2D.Impulse);
        }
    }
}