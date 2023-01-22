using System;
using System.Threading.Tasks;
using UnityEngine;
using YundosArrow.Scripts.Systems.Managers.Enemy;

namespace YundosArrow.Scripts.Enemy {
    [RequireComponent(typeof(AttachHealthBar))]
    [RequireComponent(typeof(BalloonEffect))]
    public class Health : MonoBehaviour {
        [SerializeField] private float amount;
        
        public event Action<float, float> OnHealthChanged;
        public event Action OnDeath;

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
            this.OnHealthChanged?.Invoke(this.CurrentHealth, this.MaxHealth);

            if (this.CurrentHealth <= 0) {
                while (this.GetComponent<AttachHealthBar>().healthBar.Image.fillAmount > 0) { await Task.Delay(25); }
                this.GetComponent<BalloonEffect>().Play();
                while (!this.GetComponent<BalloonEffect>().IsCompleted) { await Task.Delay(25); }
                EnemySpawnManager.Instance.StashEnemy(this.gameObject);
            }
        }
    }
}