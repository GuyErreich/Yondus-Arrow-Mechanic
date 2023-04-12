using Assets.YundosArrow.Scripts.Systems.Managers.Enemy;
using UnityEngine;
using YundosArrow.Scripts.UI.HealthBars;

namespace Assets.YundosArrow.Scripts.Enemy
{
    public class AttachHealthBar : MonoBehaviour
    {
        public DynamicHealthBar HealthBar { get; private set; }
        private Health _healthScript;

        private void Awake() {
            _healthScript = GetComponent<Health>();
        }

        private void OnEnable() {
            HealthBar = EnemyManager.Instance.HealthBar;
            HealthBar.Target = transform;
            _healthScript.OnHealthChanged += HealthBar.HandleHealthChanged;
            HealthBar.gameObject.SetActive(true);
        }

        private void OnDisable() {
            HealthBar.Target = null;
            _healthScript.OnHealthChanged -= HealthBar.HandleHealthChanged;
            HealthBar.gameObject.SetActive(false);
            EnemyManager.Instance.HealthBar = HealthBar;
        }
    }
}
