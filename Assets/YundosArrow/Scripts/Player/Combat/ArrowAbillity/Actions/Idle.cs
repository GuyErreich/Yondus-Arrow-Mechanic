using DG.Tweening;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity
{
    public partial class Actions {
        public static void FloatAnimation() {
			ArrowStats.Arrow.DOShakePosition(
				0f,
				ArrowStats.IdleStats.Strength,
				ArrowStats.IdleStats.Vibration,
				ArrowStats.IdleStats.Randomness,
				ArrowStats.IdleStats.Snapping,
				ArrowStats.IdleStats.FadeOut,
				ArrowStats.IdleStats.RandomnessMode
			);
        }
    }
}