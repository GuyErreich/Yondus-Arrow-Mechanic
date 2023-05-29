using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Assets.YundosArrow.Scripts.Systems.Managers.Enemy;
using System.Collections.Generic;

namespace Assets.YundosArrow.Scripts.Enemy {
    [RequireComponent(typeof(AttachHealthBar))]
    [RequireComponent(typeof(BalloonEffect))]
    public class Health : MonoBehaviour {
        [SerializeField] private List<Collider> _colliders;
        [SerializeField] private float _amount = 100f;

        private bool _isDead = false;
        
        public event Action<float, float> OnHealthChanged;
        public UnityEvent OnDeath;

        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }

        private void Awake() {
            MaxHealth = _amount;
        }

        private void OnEnable() {
            CurrentHealth = MaxHealth;
            _isDead = false;
			
            var colliders = GetComponentsInChildren<Collider>();
            foreach(var collider in colliders) { collider.enabled = false; }
        }

        public async void Change(float amount) {
            CurrentHealth += amount;
            OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);

            if (!_isDead && CurrentHealth <= 0) {
                _isDead = true;
				var healthBar = GetComponent<AttachHealthBar>().HealthBar;
				// if (healthBar != null)
				// 	while (healthBar.Image.fillAmount > 0) { await Task.Delay(1); }

                var colliders = GetComponentsInChildren<Collider>();
                foreach(var collider in colliders) { collider.enabled = false; }


				var balloonEffect = GetComponent<BalloonEffect>();
				if (balloonEffect != null)
				{
	                GetComponent<BalloonEffect>().Play();
	                while (!GetComponent<BalloonEffect>().IsCompleted) { await Task.Delay(10); }
				}

                EnemySpawnManager.Instance.StashEnemy(gameObject);
                OnDeath?.Invoke();
            }
        }
    }
}