using UnityEngine;
using UnityEngine.AI;

namespace Assets.YundosArrow.Scripts.Enemy.Movement.Decisions
{
	public class IsOnOffMeshLinkArea_Jump : Decision {
		public override bool Decide(EnemyState currentState)
		{
			if(currentState.Stats.Agent.isOnOffMeshLink &&
				currentState.Stats.Agent.currentOffMeshLinkData.offMeshLink.area == NavMesh.GetAreaFromName("Jump"))
				return true;

			return false;
		}
	}
}
