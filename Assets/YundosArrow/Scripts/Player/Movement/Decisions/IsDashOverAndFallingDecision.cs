using Assets.YundosArrow.Scripts.Player.Movement.States;
using Assets.YundosArrow.Scripts.Player.Movement.Stats;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement.Decisions
{
	public class IsDashOverAndFallingDecision : Decision {
		public override bool Decide(PlayerState currentState)
		{
			var startTime = (currentState as Dash)?.StartTime;

			if (Time.unscaledTime - startTime >= PlayerStats.Movement.Dash.Duration)
				return new FallDecision().Decide(currentState);

			return false;
		}
	}
}
