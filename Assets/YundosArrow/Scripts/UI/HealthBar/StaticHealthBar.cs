using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace YundosArrow.Scripts.UI.HealthBars
{
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Slider))]
    public class StaticHealthBar : MonoBehaviour
    {
        [SerializeField] private float duration = 0.5f;

        private Slider slider;

        private void Awake()
        {
            this.slider = this.GetComponent<Slider>();
        }

        public void HandleHealthChanged(float currentHealth)
        {
            this.slider.DOValue(currentHealth, duration);
        }
    }
}
