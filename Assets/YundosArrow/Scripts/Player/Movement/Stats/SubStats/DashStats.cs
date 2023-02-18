using UnityEngine;
using UnityEngine.Events;

namespace Assets.YundosArrow.Scripts.Player.Movement.Stats.SubStats
{
	[System.Serializable]
	public class DashStats {
        [SerializeField, Min(0.01f)] private float _distance;
		[SerializeField, Range(0f, 3f)] private float _duration;
		[SerializeField, Range(0f, 3f)] private float _reactionGapTime;

		public UnityEvent OnStart;
		public UnityEvent OnExit;


        public float Distance => _distance;
        public float Duration => _duration;
        public float ReactionGapTime => _reactionGapTime;

        public DashStats()
        {
            _distance = 10f;
            _duration = 0.3f;
			_reactionGapTime = 0.4f;
        }
    }
}