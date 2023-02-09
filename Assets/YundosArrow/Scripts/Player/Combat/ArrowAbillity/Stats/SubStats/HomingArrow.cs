using DG.Tweening;
using UnityEngine;
using UnityEngine.VFX;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats.SubStats
{
	[System.Serializable]
	public class HomingArrow {

		[SerializeField] private Transform _arrow;
		[SerializeField] private Transform _startPoint;
		[SerializeField] private VisualEffect _haloVfx;
		[SerializeField, Range(0.1f, 50)] private float _speed;
        [SerializeField, Range(1, 10)] private float _force;
        [SerializeField, Range(1, 20)] private float _returnForce;
        [SerializeField, Range(1, 10)] private float _loopHoleForce;

		public Transform arrow => _arrow;
		public Transform startPoint => _startPoint;
		public VisualEffect haloVfx => _haloVfx;
		public float speed => _speed;
		public float force => _force;
        public float loopHoleForce => _loopHoleForce;
        public float returnForce => _returnForce;

		public HomingArrow()
        {
            _speed = 1f;
            _force = 1f;
            _returnForce = 5f;
            _loopHoleForce = 1f;
        }
    }
}