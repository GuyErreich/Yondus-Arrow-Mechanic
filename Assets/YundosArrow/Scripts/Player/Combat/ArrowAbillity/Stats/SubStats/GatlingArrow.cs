using DG.Tweening;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats.SubStats
{
	[System.Serializable]
	public class GatlingArrow {
		[SerializeField] private Transform _arrow;
		[SerializeField, Range(6, 64)] private int _amount;
		[SerializeField, Range(0.1f, 200f)] private float _speed;
		[SerializeField, Range(5f, 200f)] private float _range;
		[SerializeField, Range(0.001f, 5f)] private float _rateOfFire;

		public Transform arrow => _arrow;
		public int amount => _amount;
		public float speed => _speed;
		public float range => _range;
		public float rateOfFire => _rateOfFire;

		public GatlingArrow()
        {
			_amount = 6;
			_speed = 1f;
			_range = 5f;
			_rateOfFire = 1f;
		}
    }
}