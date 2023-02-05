using UnityEngine;
using UnityEngine.Events;

namespace Assets.YundosArrow.Scripts.Player.Combat {
    public class Health : MonoBehaviour {
        [SerializeField] private float _amount = 100f;
        [SerializeField, Range(0, 10)] private float _hitGracePeriod = 1f;

        private float? _lastHitTime;
        
        public UnityEvent<float> OnStart;
        public UnityEvent<float> OnHealthChanged;

        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }

        private void Awake() {
            MaxHealth = _amount;
        }

        private void Start() {
            OnStart?.Invoke(MaxHealth);
        }

        private void OnEnable() {
            CurrentHealth = MaxHealth;
        }

        public void Change(float amount) {
            if (_lastHitTime != null)
                if (Time.time - _lastHitTime <= _hitGracePeriod)
                    return;
                
            _lastHitTime = Time.time;
            
			CurrentHealth += amount;
            OnHealthChanged?.Invoke(CurrentHealth);
        }
    }
}