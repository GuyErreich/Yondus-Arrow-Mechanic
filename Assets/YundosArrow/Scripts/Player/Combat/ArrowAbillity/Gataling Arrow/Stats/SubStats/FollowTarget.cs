using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow.Stats.SubStats
{
	[System.Serializable]
	public class FollowTarget {
        [SerializeField] private Transform _target;
        [SerializeField, Range(0.01f, 10)] private float _duration;

        public Transform target => _target;
        public float duration => _duration;
		
        public FollowTarget()
        {
            _duration = 0.5f;
        }
    }
}