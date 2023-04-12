using UnityEngine;
using UnityEngine.AI;

namespace Assets.YundosArrow.Scripts.Enemy.Movement.Decisions
{
	public class FallDecision : Decision {
		public override bool Decide(EnemyState currentState)
		{
			if(!currentState.Stats.Agent.isOnNavMesh)
			// if(!NavMesh.SamplePosition(currentState.Stats.Agent.transform.position, out var hit, 3f, NavMesh.AllAreas))
				return true;

			return false;
		}
	}
}
