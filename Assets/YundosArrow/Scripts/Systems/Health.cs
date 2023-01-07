using System;
using UnityEngine;
using UnityEngine.Events;

namespace YundosArrow.Scripts.Systems {
    public class Health : MonoBehaviour, ISerializationCallbackReceiver {
        [SerializeField] private float amount;
        
        public event Action<float> OnHealthChanged;

        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }

        private void Awake() {
            this.MaxHealth = this.amount;
        }

        private void Start() {
            this.CurrentHealth = this.MaxHealth;
        }

        public void Change(float amount) {
            print(amount);
            this.CurrentHealth += amount;
            OnHealthChanged?.Invoke(amount);
        }

        public void OnBeforeSerialize()
        {
            return;
        }

        public void OnAfterDeserialize()
        {
            this.MaxHealth = this.amount;
        }
    }
}