using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;
using System;

namespace YundosArrow.Scripts.Enemy
{
    public class BalloonEffect : MonoBehaviour
    {
        [SerializeField] private Material balloonPop;
        [SerializeField] private float startFrameAmount;
        [SerializeField] private float endFrameAmount;
        [SerializeField] private float duration;

        private int cached_amountProperty;
        private Renderer currentRenderer;

        public bool IsCompleted { get; private set; }

        private void Awake() {
            this.currentRenderer = this.gameObject.GetComponent<Renderer>();
            this.currentRenderer.material = this.balloonPop;
        }

        private void OnEnable() {
            this.currentRenderer.material.DOFloat(this.startFrameAmount, "_Amount", 0);
            this.IsCompleted = false;
        }

        public void Play() {
            this.currentRenderer.material.DOFloat(this.endFrameAmount, "_Amount", duration)
            .onComplete = () => {
                    this.IsCompleted = true;
                };
        }
    }
}
