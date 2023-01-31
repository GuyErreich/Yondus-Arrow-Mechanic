using UnityEngine;
using YundosArrow.Scripts.Player.Stats.SubStats;

namespace YundosArrow.Scripts.Player.Stats
{
	[System.Serializable]
	public class JumpStats {
		[SerializeField, Min(0f)] private float jumpForce;
        [SerializeField, Range(0f, 10f)] private float fallMultiplier;
        [SerializeField, Range(0.2f, 3f)] private float jumpGracePeriod;
        [SerializeField] private bool usePhysics;
        [SerializeField] private DoubleJumpStats doubleJump;

        public float JumpForce { get => this.jumpForce; }
        public float FallMultiplier { get => this.fallMultiplier; }
        public float JumpGracePeriod { get => this.jumpGracePeriod; }
        public bool UsePhysics { get => this.usePhysics; }
        public DoubleJumpStats DoubleJump { get => this.doubleJump; }

        public JumpStats()
        {
            this.jumpForce = 10f;
            this.fallMultiplier = 2.2f;
            this.jumpGracePeriod = 0.2f;
            this.usePhysics = true;
            doubleJump = new DoubleJumpStats();
        }
    }
}