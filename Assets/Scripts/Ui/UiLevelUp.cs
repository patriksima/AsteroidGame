using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace Asteroid.Ui
{
    public class UiLevelUp : MonoBehaviour
    {
        [SerializeField] private GameObject panel;

        private TextMeshProUGUI _textMesh;

        private void Awake()
        {
            _textMesh = panel.GetComponentInChildren<TextMeshProUGUI>();
            Assert.IsNotNull(_textMesh);
            LevelManager.OnLevelUp += Show;
        }

        private void Show(int level)
        {
            StartCoroutine(CoShow(level));
        }

        private IEnumerator CoShow(int level)
        {
            _textMesh.text = $"Level {(level + 1)}";
            panel.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            panel.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            LevelManager.OnLevelUp -= Show;
        }
    }
}