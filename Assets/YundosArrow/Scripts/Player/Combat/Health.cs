using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace YundosArrow.Scripts.Player.Combat {
    public class Health : MonoBehaviour {
        [SerializeField] private float amount;
        
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
            this.CurrentHealth += amount;
            this.OnHealthChanged?.Invoke(this.CurrentHealth);
        }
    }
}