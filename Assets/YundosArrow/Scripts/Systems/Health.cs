using System;
using System.Threading.Tasks;
using UnityEngine;

namespace YundosArrow.Scripts.Systems {
    public class Health : MonoBehaviour {
        [SerializeField] private float amount;
        
        public event Action<float, float> OnHealthChanged;
        public event Action<GameObject> OnDeath;

        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }

        private void Awake() {
            this.MaxHealth = this.amount;
        }

        private void OnEnable() {
            this.CurrentHealth = this.MaxHealth;
            Debug.Log($"Current health: {this.CurrentHealth}");
        }

        public async void Change(float amount) {
            Debug.Log($"amount: {amount}");
            this.CurrentHealth += amount;
            Debug.Log($"amount after damage: {amount}");
            Debug.Log($"Current health after damage: {this.CurrentHealth}");
            OnHealthChanged?.Invoke(this.CurrentHealth, this.MaxHealth);

            if (this.CurrentHealth <= 0) {
                while (this.GetComponent<AttachHealthBar>().healthBar.Image.fillAmount > 0) { await Task.Delay(25); }
                OnDeath?.Invoke(this.gameObject);
            }
        }
    }
}