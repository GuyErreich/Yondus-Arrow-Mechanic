using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YundosArrow.Scripts.Systems;
using YundosArrow.Scripts.Systems.Managers.Enemy;
using YundosArrow.Scripts.UI.HealthBars;

namespace YundosArrow.Scripts.Enemy
{
    public class AttachHealthBar : MonoBehaviour
    {
        public DynamicHealthBar healthBar { get; private set; }
        private Health healthScript;

        private void Awake() {
            this.healthScript = this.GetComponent<Health>();
        }

        private void OnEnable() {
            this.healthBar = EnemyManager.Instance.HealthBar;
            this.healthBar.Target = this.transform;
            this.healthScript.OnHealthChanged += this.healthBar.HandleHealthChanged;
            this.healthBar.gameObject.SetActive(true);
        }

        private void OnDisable() {
            this.healthBar.Target = null;
            this.healthScript.OnHealthChanged -= this.healthBar.HandleHealthChanged;
            this.healthBar.gameObject.SetActive(false);
            EnemyManager.Instance.HealthBar = this.healthBar;
        }
    }
}
