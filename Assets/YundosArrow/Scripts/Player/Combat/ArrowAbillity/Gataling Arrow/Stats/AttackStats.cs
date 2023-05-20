using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow.Stats
{
	[System.Serializable]
	public class AttackStats {
		[Header("References")]
		[SerializeField] private Transform _arrow;
		[SerializeField] private Transform _anchor;
		[Space]
		[Header("Parameters")]
		[SerializeField, Range(1, 128)] private int _amount;
		[SerializeField, Range(0.1f, 200f)] private float _speed;
		[SerializeField, Range(5f, 200f)] private float _range;
		[SerializeField, Range(0.001f, 5f)] private float _rateOfFire;
		[Space]
		[Header("Positioning")]
        [SerializeField] private bool _isSphere;
        [SerializeField, Range(0f, 10f)] private float _distance;
        [SerializeField, Range(0f, 10f)] private float _zOffset;
        [SerializeField, Range(0.01f, 10f)] private float _duration;
		[Space]
		[SerializeField] private SubStats.FollowTarget _followTarget;
		[Space]
        [SerializeField] private SubStats.MarkTargets _markTargets;

		public SubStats.FollowTarget followTarget => _followTarget;
		public SubStats.MarkTargets markTargets => _markTargets;

		public Transform arrow => _arrow;
        public Transform anchor => _anchor;
		public int amount => _amount;
		public float speed => _speed;
		public float range => _range;
		public float rateOfFire => _rateOfFire;
        public bool isSphere => _isSphere;
        public float distance => _distance;
        public float zOffset => _zOffset;
        public float duration => _duration;

		public AttackStats()
        {
			_amount = 6;
			_speed = 1f;
			_range = 5f;
			_rateOfFire = 1f;
			_isSphere = false;
			_distance = 0.75f;
			_zOffset = 0.5f;
			_duration = 0.5f;
			_followTarget = new SubStats.FollowTarget();
			_markTargets = new SubStats.MarkTargets();
		}
    }
}