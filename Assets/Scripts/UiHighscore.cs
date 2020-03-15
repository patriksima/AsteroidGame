using TMPro;
using UnityEngine;

namespace Asteroid
{
    public class UiHighscore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMesh;

        private void Awake()
        {
            UpdateHighscoreText();
            GameManager.OnGameStarts += UpdateHighscoreText;
        }

        private void UpdateHighscoreText()
        {
            textMesh.text = ScoreManager.Instance.Highscore.ToString("000000");
        }

        private void OnDestroy()
        {
            GameManager.OnGameStarts -= UpdateHighscoreText;
        }
    }
}