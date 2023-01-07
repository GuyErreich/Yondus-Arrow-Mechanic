using System.Collections.Generic;
using UnityEngine;

namespace YundosArrow.Scripts.Systems {
    [RequireComponent(typeof(Collider))]
    public class Damage : MonoBehaviour, ISerializationCallbackReceiver {
        [SerializeField] private float amount;
        [SerializeField] private List<string> tagsToHit;

        public float Amount { get; set; }

        private void Awake() {
            this.Amount = this.amount;
        }

        private void OnTriggerEnter(Collider other) {
            print(amount);
            foreach (string tag in tagsToHit) {
                var health = other.GetComponent<Health>();
                if (health) {
                    health.Change(this.Amount);
                }
            }
        }

        private void OnCollisionEnter(Collision other) {
            print("1" + amount);
            foreach (string tag in tagsToHit) {
                var health = other.gameObject.GetComponent<Health>();
                if (health) {
                    health.Change(this.Amount);
                }
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