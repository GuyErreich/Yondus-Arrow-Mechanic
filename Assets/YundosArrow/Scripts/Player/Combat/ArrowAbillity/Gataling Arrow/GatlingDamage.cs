using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat {
    public class GatlingDamage : MonoBehaviour, ISerializationCallbackReceiver {
        [SerializeField] private float _amount = 10f;
        [SerializeField] private LayerMask _layerMask;

        public float Amount { get; set; }

        /**
        TODO: confirm the current target is the next one in the list so the arrow want
        remove damage for accidentally colliding other targets on the way
        **/
		private void OnTriggerEnter(Collider other) {
            if (other.tag == "Enemy") {
                var hitBox = other.GetComponent<Enemy.HitBox>();
                if (hitBox) {
                        hitBox.Hit(-(Amount));
                }
            }
        }

        public void OnBeforeSerialize() {}

        public void OnAfterDeserialize()
        {
            Amount = _amount;
        }
    }
}