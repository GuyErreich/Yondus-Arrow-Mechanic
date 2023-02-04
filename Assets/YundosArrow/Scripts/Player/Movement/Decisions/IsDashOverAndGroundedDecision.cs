using Assets.YundosArrow.Scripts.Player.Movement.States;
using Assets.YundosArrow.Scripts.Player.Movement.Stats;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement.Decisions
{
	public class IsDashOverAndGroundedDecision : Decision {
		public override bool Decide(PlayerState currentState)
		{
			var startTime = (currentState as Dash)?.StartTime;

			if (Time.time - startTime >= PlayerStats.Movement.Dash.Duration)
				return new IsGroundedDecision().Decide(currentState);

			return false;
		}
	}
}
