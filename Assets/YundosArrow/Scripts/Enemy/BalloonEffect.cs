using UnityEngine;
using DG.Tweening;

namespace Assets.YundosArrow.Scripts.Enemy
{
    public class BalloonEffect : MonoBehaviour
    {
        [SerializeField] private Material _balloonPop;
        [SerializeField] private float _startFrameAmount;
        [SerializeField] private float _endFrameAmount;
        [SerializeField] private float _duration;

        private Renderer _currentRenderer;

        public bool IsCompleted { get; private set; }

        private void Awake() {
            _currentRenderer = gameObject.GetComponent<Renderer>();
            _currentRenderer.material = _balloonPop;
        }

        private void OnEnable() {
            _currentRenderer.material.DOFloat(_startFrameAmount, "_Amount", 0);
            IsCompleted = false;
        }

        public void Play() {
            _currentRenderer.material.DOFloat(_endFrameAmount, "_Amount", _duration)
            .onComplete = () => {
				IsCompleted = true;
			};
        }
    }
}
