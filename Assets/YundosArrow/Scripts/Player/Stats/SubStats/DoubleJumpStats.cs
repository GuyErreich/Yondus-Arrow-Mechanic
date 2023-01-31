using UnityEngine;

namespace YundosArrow.Scripts.Player.Stats.SubStats
{
	[System.Serializable]
	public class DoubleJumpStats {
        [SerializeField, Min(0.01f)] private float force;
        [SerializeField, Range(0.2f, 3f)] private float reactionGapTime;
        
        public float Force { get => this.force; }
        public float ReactionGapTime { get => reactionGapTime; }

        public DoubleJumpStats()
        {
            this.force = 10f;
            this.reactionGapTime = 0.2f;
        }
    }
}