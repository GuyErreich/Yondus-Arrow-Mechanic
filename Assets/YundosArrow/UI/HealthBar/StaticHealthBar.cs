using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace YundosArrow.Scripts.UI.HealthBars
{
    public class StaticHealthBar : MonoBehaviour
    {
        [SerializeField] private Image foregroundImage;
        [SerializeField] private float updateSpeedSeconds = 0.5f;

        public void HandleHealthChanged(float percentage)
        {
            StartCoroutine(this.ChangeToPercentage(percentage));
        }

        private IEnumerator ChangeToPercentage(float percentage)
        {
            float preChangePercentage = foregroundImage.fillAmount;
            float elapsed = 0f;

            while (elapsed < updateSpeedSeconds)
            {
                elapsed += Time.deltaTime;
                foregroundImage.fillAmount = Mathf.Lerp(preChangePercentage, percentage, elapsed / updateSpeedSeconds);
                yield return null;
            }

            foregroundImage.fillAmount = percentage;
        }
    }
}
