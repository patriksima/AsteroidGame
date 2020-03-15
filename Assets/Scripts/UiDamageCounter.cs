using TMPro;
using UnityEngine;

namespace Asteroid
{
    public class UiDamageCounter : MonoBehaviour
    {
        private int _damage;
        private TextMeshProUGUI _textMesh;

        private void Awake()
        {
            _textMesh = GetComponentInChildren<TextMeshProUGUI>();
            HealthAbility.OnDamage += damage =>
            {
                _damage += damage;
                _textMesh.text = _damage.ToString("000000");
            };
        }
    }
}