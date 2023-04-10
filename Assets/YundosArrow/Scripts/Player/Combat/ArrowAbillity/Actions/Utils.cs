using DG.Tweening;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity
{
    public partial class Actions {
		private static void FollowTarget(Transform transform, Vector3 position, Vector3 lookAt, float duration) {
			transform.DOMove(position, duration).SetUpdate(true);
			transform.DOLookAt(lookAt , duration).SetUpdate(true);
		}
    }
}