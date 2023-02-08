using DG.Tweening;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity
{
    public partial class Actions {
		public static void IdleFollow()
		{
			FollowTarget(ArrowStats.attackStats.homingArrow.arrow, ArrowStats.attackStats.homingArrow.startPoint.position, GetHitMarkPoint(), ArrowStats.idleStats.followTarget.duration);

			if (_gatlingArrows != null && _gatlingArrows.Count > 0)
			{
				GatlingFollowMainArrow();
			}
		}

		private static void FollowTarget(Transform transform, Vector3 position, Vector3 lookAt, float duration) {
			transform.DOMove(position, duration);
			transform.DOLookAt(lookAt , duration);
		}
    }
}