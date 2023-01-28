using UnityEngine;

namespace YundosArrow.Scripts.Enemy {
    public class Damage : MonoBehaviour, ISerializationCallbackReceiver {
        [SerializeField] private float amount;
        [SerializeField] private LayerMask layerMask;

        public float Amount { get; set; }

        private void Awake() {
            this.Amount = this.amount;
        }

        private void OnCollisionEnter(Collision other) { 
            var health = other.gameObject.GetComponent<Player.Combat.Health>();
            Debug.Log("Health: Collision" + health);
            if (health) {
                health.Change(-(this.Amount));
            }
        }

        private void OnTriggerEnter(Collider other) { 
            var health = other.GetComponent<Player.Combat.Health>();
            Debug.Log("Health: Trigger" + health);
            if (health) {
                health.Change(-(this.Amount));
            }
        }

        public void OnBeforeSerialize()
        {
            return;
        }

        public void OnAfterDeserialize()
        {
            this.Amount = this.amount;
        }
    }
}