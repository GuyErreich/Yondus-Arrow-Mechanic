using UnityEngine;

namespace YundosArrow.Scripts.Enemy {
    public class Damage : MonoBehaviour, ISerializationCallbackReceiver {
        [SerializeField] private float amount;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask layerMask;

        public float Amount { get; set; }

        private void Awake() {
            this.Amount = this.amount;
        }

        // private void FixedUpdate() {
        //     var hits = Physics.OverlapSphere(this.transform.position, radius, layerMask, QueryTriggerInteraction.Collide);
        //     if (hits.Length > 0) {
        //         foreach (var hit in hits) {
        //             var health = hit.GetComponent<Player.Combat.Health>();
        //             if (health) {
        //                 if (Vector3.Distance(hit.ClosestPoint(this.transform.position), this.transform.position) < 0.7f) {
        //                     Debug.Log("Health: Collision" + health);
        //                     health.Change(-(this.Amount));
        //                 }
        //             }
        //         }
        //     }
        // }

        private void OnCollisionEnter(Collision other) { 
            var health = other.gameObject.GetComponent<Player.Combat.Health>();
            if (health) {
                Debug.Log("Health: Collision" + health);
                health.Change(-(this.Amount));
            }
        }

        private void OnTriggerEnter(Collider other) { 
            var health = other.GetComponent<Player.Combat.Health>();
            if (health) {
                Debug.Log("Health: Trigger" + health);
                health.Change(-(this.Amount));
            }
        }

        // private void OnDrawGizmos() {
        //     Gizmos.matrix = this.transform.localToWorldMatrix;
        //     Gizmos.DrawWireSphere(Vector3.zero, radius);
        // }

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