using UnityEngine;
using UnityEngine.AI;

namespace Assets.YundosArrow.Scripts.Enemy.Movement.Decisions
{
	public class FallToRoamDecision : Decision {
		public override bool Decide(EnemyState currentState)
		{
			if(currentState.Stats.Agent.isOnNavMesh)
			// if(NavMesh.SamplePosition(currentState.transform.position, out var hit, 1.5f, NavMesh.AllAreas)) 
				return true;

			return false;
		}
	}
}
