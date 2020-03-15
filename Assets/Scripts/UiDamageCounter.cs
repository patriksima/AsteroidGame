using TMPro;
using UnityEngine;

namespace Asteroid
{
    public class UiDamageCounter : MonoBehaviour
    {
        private int _damage;

        [SerializeField] private TextMeshProUGUI textMesh;

        private void Awake()
        {
            HealthAbility.OnDamage += UpdateDamageText;
        }

        private void UpdateDamageText(int damage)
        {
            _damage += damage;
            textMesh.text = _damage.ToString("000000");
        }

        private void OnDestroy()
        {
            HealthAbility.OnDamage -= UpdateDamageText;
        }
    }
}