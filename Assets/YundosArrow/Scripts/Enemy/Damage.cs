using UnityEngine;

namespace Assets.YundosArrow.Scripts.Enemy {
    public class Damage : MonoBehaviour, ISerializationCallbackReceiver {
        [SerializeField] private float _amount;
        [SerializeField] private LayerMask _layerMask;

        public float Amount { get; set; }

        private void OnCollisionEnter(Collision other) { 
            var health = other.gameObject.GetComponent<Player.Combat.Health>();
            if (health) {
                Debug.Log("Health: Collision" + health);
                health.Change(-(Amount));
            }
        }

        private void OnTriggerEnter(Collider other) {
            var health = other.GetComponent<Player.Combat.Health>();
            if (health) {
                Debug.Log("Health: Trigger" + health);
                health.Change(-(Amount));
            }
        }

        public void OnBeforeSerialize() {}

        public void OnAfterDeserialize()
        {
            Amount = _amount;
        }
    }
}