using DG.Tweening;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity
{
    public partial class Actions {
		private static Tweener _tweener;
        public static void FloatAnimation() {
			_tweener = ArrowStats.Arrow.DOShakePosition(
				ArrowStats.IdleStats.ShakeAnimation.Duration,
				ArrowStats.IdleStats.ShakeAnimation.Strength,
				ArrowStats.IdleStats.ShakeAnimation.Vibration,
				ArrowStats.IdleStats.ShakeAnimation.Randomness,
				ArrowStats.IdleStats.ShakeAnimation.Snapping,
				ArrowStats.IdleStats.ShakeAnimation.FadeOut,
				ArrowStats.IdleStats.ShakeAnimation.RandomnessMode
				).SetLoops(-1)
				.OnComplete(() =>
				{
					_tweener.Restart();
				});

        }

		public static void FollowTarget(Vector3 position) {
			ArrowStats.Arrow.transform.DOMove(position, ArrowStats.IdleStats.FollowTarget.Duration);
		}
    }
}