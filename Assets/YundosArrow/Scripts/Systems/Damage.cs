using UnityEngine;
using YundosArrow.Scripts.Enemy;

namespace YundosArrow.Scripts.Systems {
    public class Damage : MonoBehaviour, ISerializationCallbackReceiver {
        [System.Serializable]
        private struct col {
            [SerializeField] public Vector3 center;
            [SerializeField] public float radius;
        }

        [SerializeField] private new col collider;
        [SerializeField] private float amount;
        [SerializeField] private LayerMask layerMask;

        public float Amount { get; set; }

        private void Awake() {
            this.Amount = this.amount;
        }

        private void OnTriggerEnter(Collider other) {
            print(amount);
            if (other.tag == "Enemy") {
                var health = other.GetComponent<Health>();
                if (health) {
                    health.Change(-(this.Amount));
                }
            }
        }

        private void OnDrawGizmosSelected() {

            Gizmos.matrix = this.transform.localToWorldMatrix;
            Gizmos.color = Color.green;
            // var pos = this.transform.right * this.collider.center.x + this.transform.up * this.collider.center.y + this.transform.forward * this.collider.center.z;
            Gizmos.DrawWireSphere(this.collider.center, this.collider.radius);
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