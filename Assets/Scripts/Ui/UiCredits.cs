using System.Collections;
using UnityEngine;

namespace Asteroid
{
    public class UiCredits : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}