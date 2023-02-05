using DG.Tweening;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity
{
    public partial class Actions {
		private static Tweener _tweener;
        public static void FloatAnimation() {
			_tweener = ArrowStats.Arrow.DOShakePosition(
				ArrowStats.IdleStats.Duration,
				ArrowStats.IdleStats.Strength,
				ArrowStats.IdleStats.Vibration,
				ArrowStats.IdleStats.Randomness,
				ArrowStats.IdleStats.Snapping,
				ArrowStats.IdleStats.FadeOut,
				ArrowStats.IdleStats.RandomnessMode
				).SetLoops(-1)
				.OnComplete(() =>
				{
					_tweener.Restart();
				});

        }
    }
}