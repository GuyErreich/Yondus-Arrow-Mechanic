using DG.Tweening;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.Utils
{
    public class SpinArrow : MonoBehaviour, ISerializationCallbackReceiver
    {
        [SerializeField] private Vector3Int _axis;
        [SerializeField] private float _speed;

        private Vector3Int _clamped = new Vector3Int(0,0,0);

        private void Update()
        {
            transform.DOBlendableLocalRotateBy((Vector3)_axis * _speed * Time.unscaledDeltaTime, 0.5f).SetUpdate(true);
        }

        public void OnAfterDeserialize()
        {
            _clamped.x = Mathf.Clamp(_axis.x, 0, 1);
            _clamped.y = Mathf.Clamp(_axis.y, 0, 1);
            _clamped.z = Mathf.Clamp(_axis.z, 0, 1);
        }

        public void OnBeforeSerialize()
        {
            _axis = _clamped;
        }
    }
}
