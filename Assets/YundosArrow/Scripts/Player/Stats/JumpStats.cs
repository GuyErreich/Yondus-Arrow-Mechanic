using UnityEngine;

namespace YundosArrow.Scripts.Player.Stats
{
	[System.Serializable]
	public class JumpStats {
		[Header("Move")]
		[SerializeField] private float jumpForce;
        [SerializeField] private float fallMultiplier;
        [SerializeField] private float jumpGracePeriod;
        [SerializeField] private bool usePhysics;

        public float JumpForce { get => this.jumpForce; }
        public float FallMultiplier { get => this.fallMultiplier; }
        public float JumpGracePeriod { get => this.jumpGracePeriod; }
        public bool UsePhysics { get => this.usePhysics; }

        public JumpStats()
        {
            this.jumpForce = 10f;
            this.fallMultiplier = 2.2f;
            this.jumpGracePeriod = 0.2f;
            this.usePhysics = true;
        }
    }
}