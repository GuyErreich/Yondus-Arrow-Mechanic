using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats.SubStats
{
	[System.Serializable]
	public class GatlingArrow {
		[Header("References")]
		[SerializeField] private Transform _arrow;
		[SerializeField] private Transform _anchor;
		[Space]
		[Header("Parameters")]
		[SerializeField, Range(6, 64)] private int _amount;
		[SerializeField, Range(0.1f, 200f)] private float _speed;
		[SerializeField, Range(5f, 200f)] private float _range;
		[SerializeField, Range(0.001f, 5f)] private float _rateOfFire;
		[Space]
		[Header("Positioning")]
        [SerializeField, Range(0f, 10f)] private float _distance;
        [SerializeField, Range(0f, 10f)] private float _offsetZ;
        [SerializeField, Range(0.01f, 10f)] private float _duration;


		public Transform arrow => _arrow;
        public Transform anchor => _anchor;
		public int amount => _amount;
		public float speed => _speed;
		public float range => _range;
		public float rateOfFire => _rateOfFire;
        public float distance => _distance;
        public float offsetZ => _offsetZ;
        public float duration => _duration;

		public GatlingArrow()
        {
			_amount = 6;
			_speed = 1f;
			_range = 5f;
			_rateOfFire = 1f;
			_distance = 0.75f;
			_offsetZ = 0.5f;
			_duration = 0.5f;
		}
    }
}