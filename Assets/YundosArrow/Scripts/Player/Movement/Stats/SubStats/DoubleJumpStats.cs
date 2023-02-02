using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement.Stats.SubStats
{
	[System.Serializable]
	public class DoubleJumpStats {
        [SerializeField, Min(0.01f)] private float _force;
        [SerializeField, Range(0.2f, 3f)] private float _reactionGapTime;

        public float Force { get => _force; }
        public float ReactionGapTime { get => _reactionGapTime; }

        public DoubleJumpStats()
        {
            _force = 10f;
            _reactionGapTime = 0.4f;
        }
    }
}