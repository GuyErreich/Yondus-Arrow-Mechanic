using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Assets.YundosArrow.Scripts.Systems.Managers.Enemy;

namespace Assets.YundosArrow.Scripts.Enemy {
    [RequireComponent(typeof(AttachHealthBar))]
    [RequireComponent(typeof(BalloonEffect))]
    public class Health : MonoBehaviour {
        [SerializeField] private float _amount = 100f;
        
        public event Action<float, float> OnHealthChanged;
        public UnityEvent OnDeath;

        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }

        private void Awake() {
            MaxHealth = _amount;
        }

        private void OnEnable() {
            CurrentHealth = MaxHealth;
			GetComponent<Collider>().enabled = true;
        }

        public async void Change(float amount) {
            CurrentHealth += amount;
            OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);

            if (CurrentHealth <= 0) {
				var healthBar = GetComponent<AttachHealthBar>().HealthBar;
				if (healthBar != null)
					while (healthBar.Image.fillAmount > 0) { await Task.Delay(25); }

				GetComponent<Collider>().enabled = false;

				var balloonEffect = GetComponent<BalloonEffect>();
				if (balloonEffect != null)
				{
	                GetComponent<BalloonEffect>().Play();
	                while (!GetComponent<BalloonEffect>().IsCompleted) { await Task.Delay(25); }
				}

                EnemySpawnManager.Instance.StashEnemy(gameObject);
                OnDeath?.Invoke();
            }
        }
    }
}