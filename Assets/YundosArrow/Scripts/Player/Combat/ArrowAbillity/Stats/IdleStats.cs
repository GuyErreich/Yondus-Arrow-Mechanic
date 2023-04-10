using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats
{
	[System.Serializable]
	public class IdleStats {
		// [SerializeField] private SubStats.ShakeAnimation _shakeAnimation;
        [Space]
        [SerializeField] private SubStats.FollowTarget _followTarget;

        // public SubStats.ShakeAnimation shakeAnimation => _shakeAnimation;
        public SubStats.FollowTarget followTarget => _followTarget;

        public IdleStats()
        {
            // _shakeAnimation = new SubStats.ShakeAnimation();
            _followTarget = new SubStats.FollowTarget();
        }
    }
}