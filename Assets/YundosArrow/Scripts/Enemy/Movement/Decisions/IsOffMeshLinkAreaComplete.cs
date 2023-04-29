using UnityEngine;
using UnityEngine.AI;

namespace Assets.YundosArrow.Scripts.Enemy.Movement.Decisions
{
	public class IsOffMeshLinkAreaComplete : Decision {
		public override bool Decide(EnemyState currentState)
		{
			Debug.LogError($"Agent Pos: {currentState.Stats.Agent.transform.position}");
			Debug.LogError($"Link End Pos: {currentState.Stats.Agent.currentOffMeshLinkData.endPos}");
			if(Vector3.Distance(currentState.Stats.Agent.transform.position, currentState.Stats.Agent.currentOffMeshLinkData.endPos) <= 0.03f)
				return true;

			return false;
		}
	}
}
