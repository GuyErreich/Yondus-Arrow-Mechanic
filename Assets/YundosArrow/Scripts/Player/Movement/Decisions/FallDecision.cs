using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement.Decisions
{
	public class FallDecision : Decision {
		public override bool Decide(PlayerState currentState)
		{
//			Debug.Log($"Vertical velocity: {Actions.VerticalSpeed}");
			return Actions.VerticalSpeed < 0;
		}
	}
}
