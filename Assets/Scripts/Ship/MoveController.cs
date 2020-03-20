using UnityEngine;

namespace Asteroid.Ship
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MoveController : MonoBehaviour
    {
        private const float RotationSpeed = 50.0f;
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

            // Linear rotation (slow at small pressure, faster at bigger pressure)
            const float t = .4f;
            const float a = RotationSpeed - 10f / (1f - t);
            const float b = RotationSpeed - a;

            var speed = b / (1f - t) * h;
            if (h <= -t)
            {
                speed = a * h - b;
                speed *= 1 + Mathf.Abs(v);
            }

            if (h >= t)
            {
                speed = a * h + b;
                speed *= 1 + Mathf.Abs(v);
            }

            transform.Rotate(0, 0, -speed * Time.fixedDeltaTime);

            // Thrust the ship if necessary
            // ReSharper disable once Unity.InefficientPropertyAccess
            _rigidbody.AddForce(transform.up * (ThrustForce * v), ForceMode2D.Impulse);
        }
    }
}