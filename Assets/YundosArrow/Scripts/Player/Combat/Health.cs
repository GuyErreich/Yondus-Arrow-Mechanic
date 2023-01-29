using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace YundosArrow.Scripts.Player.Combat {
    public class Health : MonoBehaviour {
        [SerializeField] private float amount;
        [SerializeField, Range(0, 10)] private float hitGracePeriod = 1f;

        private float? lastHitTime;
        
        public UnityEvent<float> OnStart;
        public UnityEvent<float> OnHealthChanged;

        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }

        private void Awake() {
            this.MaxHealth = this.amount;
        }

        private void Start() {
            OnStart?.Invoke(this.MaxHealth);
        }

        private void OnEnable() {
            this.CurrentHealth = this.MaxHealth;
        }

        public void Change(float amount) {
            if (this.lastHitTime != null)
                if (Time.time - this.lastHitTime <= this.hitGracePeriod)
                    return;
                
            this.lastHitTime = Time.time;
            
            this.CurrentHealth += amount;
            this.OnHealthChanged?.Invoke(this.CurrentHealth);
        }
    }
}