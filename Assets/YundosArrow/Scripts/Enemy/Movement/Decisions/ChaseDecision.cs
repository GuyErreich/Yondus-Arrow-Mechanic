using UnityEngine;

namespace Assets.YundosArrow.Scripts.Enemy.Movement.Decisions
{
	public class ChaseDecision : Decision {
		private float t = 0;
		public override bool Decide(EnemyState currentState)
		{
			var scanRadius = currentState.Stats.FollowStats.ScanRadius;
			var layerMask = currentState.Stats.FollowStats.LayerMask;
			var hits = Physics.OverlapSphere(currentState.transform.position, scanRadius, layerMask, QueryTriggerInteraction.Collide);
			foreach (var hit in hits) {
				if (hit.CompareTag("Player"))
				{
					return true;
				}
			}

			return false;
		}
	}
}
