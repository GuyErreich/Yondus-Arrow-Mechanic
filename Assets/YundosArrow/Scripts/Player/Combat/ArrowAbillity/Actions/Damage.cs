using UnityEngine;
using YundosArrow.Scripts.Enemy;
using YundosArrow.Scripts.Player.Combat.ArrowAbilities.Utils;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Actions {
    public class Damage : MonoBehaviour, ISerializationCallbackReceiver {
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
                    if (GlobalCollections.Targets.Contains(other.transform))
                        health.Change(-(this.Amount));
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