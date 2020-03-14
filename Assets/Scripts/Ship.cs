using System.Collections;
using UnityEngine;

namespace Asteroid
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(HealthAbility))]
    public class Ship : MonoBehaviour
    {
        [SerializeField] private GameObject shipModel;
        private HealthAbility _healthAbility;
        private BoxCollider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();
            _healthAbility = GetComponent<HealthAbility>();
            _healthAbility.OnDied += ability =>
            {
                _collider.enabled = false;
                shipModel.gameObject.SetActive(false);
                GetComponent<WeaponController>().enabled = false;
            };
        }
    }
}