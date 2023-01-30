using UnityEngine;
using TMPro;
using YundosArrow.Scripts.Systems.Managers;
using UnityEngine.UI;
using DG.Tweening;

namespace YundosArrow.Scripts.UI
{
    public class EnergyBar : MonoBehaviour
    {
        [SerializeField] private float duration = 1f;
        private Slider slider;

        private void Awake() {
            this.slider = this.GetComponent<Slider>();
            this.UpdateValue();
        }

        public void UpdateValue() {
            this.slider.DOValue(ComboManager.Instance.CurrentNumber, this.duration);
        }
    }
}
