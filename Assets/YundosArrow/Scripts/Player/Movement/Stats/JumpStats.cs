using Assets.YundosArrow.Scripts.Player.Movement.Stats.SubStats;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement.Stats
{
	[System.Serializable]
	public class JumpStats {
		[SerializeField, Min(0f)] private float _jumpForce;
        [SerializeField, Range(0f, 10f)] private float _fallMultiplier;
        [SerializeField, Range(0.2f, 3f)] private float _gracePeriod;
        [SerializeField] private bool _usePhysics;
        [SerializeField] private DoubleJumpStats _doubleJump;

        public float JumpForce { get => _jumpForce; }
        public float FallMultiplier { get => _fallMultiplier; }
        public float GracePeriod { get => _gracePeriod; }
        public bool UsePhysics { get => _usePhysics; }
        public DoubleJumpStats DoubleJump { get => _doubleJump; }

        public JumpStats()
        {
            _jumpForce = 10f;
            _fallMultiplier = 2.2f;
            _gracePeriod = 0.2f;
            _usePhysics = true;
            _doubleJump = new DoubleJumpStats();
        }
    }
}